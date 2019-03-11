using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LastWork.Models.InstructionSteps;
using LastWork.Models.BindingTargets;
using Microsoft.AspNetCore.Identity;
using LastWork.Models.Users;

namespace LastWork.Models.Instructions
{
    public class DataInstructionRepository : IInstructionRepository
    {
        private readonly DataContext context;
        private UserManager<User> userManager;

        public DataInstructionRepository(DataContext context)
        {
            this.context = context;
        }

        public Task<Instruction> FindInstructionByIdAsync(long instructionId)
        {
            Task<Instruction> result = context.Instructions
               .Include(p => p.Steps)
               .Include(x => x.User)
               .FirstOrDefaultAsync(p => p.InstructionId == instructionId);

            return result;
        }

        public async Task<IEnumerable<Instruction>> GetAllInstructions(string category)
        {
            var result = await context.Instructions
            .ToListAsync();
             if (category!="null") {
                string catLower = category.ToLower();
                result = result.Where(p => p.Category.ToLower().Contains(catLower)).ToList();
            }

            result.Reverse();

            return result;
        }

        public async Task<long> CreateInstruction(InstructionData data,User user)
        {
            Instruction i = data.GetInstruction();
            i.User = user;
            await context.AddAsync(i);
            await context.SaveChangesAsync();
            return i.InstructionId;
        }

        public async Task DeleteInstruction(Instruction instruction)
        {
            context.Instructions.Remove(instruction);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Instruction>> SearchInstructions(string searchString)
        {
            var result = await context.Instructions
            .Where(x => x.Description.Contains(searchString) ||
                x.InstructionName.Contains(searchString)) 
            .ToListAsync();
            
            return result;
        }

        public static void AvoidReference(List<Instruction> list)
        {
            if (list != null)
            {
                foreach (var i in list)
                    if (i.User != null)
                    {
                        i.User.Instructions = null;
                    }
            }
        }
    }
}