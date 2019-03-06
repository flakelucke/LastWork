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

        public Task<Instruction> FindInstructionByIdAsync(string instructionId)
        {
            return context.Instructions
               .Include(p => p.Steps)
               .Include(x => x.User)
               .SingleOrDefaultAsync(p => Convert.ToString(p.InstructionId) == instructionId);
        }

        public async Task<IEnumerable<Instruction>> GetAllInstructions()
        {
            var result = await context.Instructions
            .Include(p => p.Steps)
            .Include(p => p.User).ThenInclude(s => s.Instructions)
            .ToListAsync();

            if (result != null)
            {
                foreach (var i in result)
                {
                    if (i.User != null)
                    {
                        i.User.Instructions = i.User.Instructions.Select(p=>
                        new Instruction {
                            InstructionId=p.InstructionId,
                            InstructionName = p.InstructionName,
                            Description = p.Description
                        }).ToList();
                    }
                }
            }
            return result;
        }

        public async Task<long> CreateInstruction(InstructionData data)
        {
            Instruction i = data.GetInsruction();
            context.Attach(i.User);
            // var user = await context.Users.FirstOrDefaultAsync(x=>x.Id==i.User.Id);
            await context.AddAsync(i);
            await context.SaveChangesAsync();
            // user.Instructions.Add(i);
            // await context.SaveChangesAsync();
            return i.InstructionId;
        }

        public async Task DeleteInstruction(long id)
        {
            var instructionForDelete = await FindInstructionByIdAsync(id.ToString());
            context.Remove(instructionForDelete);
            await context.SaveChangesAsync();
        }
    }
}