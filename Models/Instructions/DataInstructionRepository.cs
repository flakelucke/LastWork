using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
             return  context.Instructions.Where(x => Convert.ToString(x.InstructionId) == instructionId)
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Instruction>> GetAllInstructions()
        {
            return await context.Instructions.ToListAsync();
        }
    }
}