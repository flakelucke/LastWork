using System.Collections.Generic;
using System.Threading.Tasks;

namespace LastWork.Models.Instructions
{
    public interface IInstructionRepository
    {
        Task<IEnumerable<Instruction>> GetAllInstructions();
        Task<Instruction> FindInstructionByIdAsync(string instructionId);
        Task AddInstructionAsync(Instruction instruction);
    }
}