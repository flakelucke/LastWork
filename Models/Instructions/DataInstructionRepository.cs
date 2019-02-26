using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LastWork.Models.InstructionSteps;
using LastWork.Models.BindingTargets;

namespace LastWork.Models.Instructions
{
    public class DataInstructionRepository: IInstructionRepository
    {
         private readonly DataContext context;

         public DataInstructionRepository(DataContext context) 
         {
             this.context = context;
         }

        public Task<Instruction> FindInstructionByIdAsync(string instructionId)
        {
             return  context.Instructions
                .Include(p => p.Steps)
                .SingleOrDefaultAsync(p => Convert.ToString(p.InstructionId) == instructionId);
        }

        public async Task<IEnumerable<Instruction>> GetAllInstructions()
        {
            return await context.Instructions
            .Include(p => p.Steps)
            .ToListAsync();
        }

        public async Task<long> CreateInstruction(InstructionData data)
        {
            Instruction i = data.GetInsruction();
            await context.AddAsync(i);
            await context.SaveChangesAsync();
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