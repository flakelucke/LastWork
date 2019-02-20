using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LastWork.Models.InstructionSteps;

namespace LastWork.Models.Instructions
{
    public class DataInstructionRepository: IInstructionRepository
    {
         private readonly DataContext context;

         public DataInstructionRepository(DataContext context) 
         {
             this.context = context;
         }

        public Task AddInstructionAsync(Instruction instruction)
        {
            throw new System.NotImplementedException();
        }

        public Task<Instruction> FindInstructionByIdAsync(string instructionId)
        {
#region Avoid Circular References
            // Instruction result = context.Instructions
            //     .Include(p => p.Steps)
            //     .SingleOrDefaultAsync(p => Convert.ToString(p.InstructionId) == instructionId);

            //  if (result != null) {
            //     if (result.Steps != null) {
            //     result.Steps.Instructions = null;
            //     }
            //  }
            //  return result;
    #endregion
    
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
    }
}