using System.Collections.Generic;
using System.Threading.Tasks;
using LastWork.Models.BindingTargets;

namespace LastWork.Models.Instructions
{
    public interface IInstructionRepository
    {
        Task<IEnumerable<Instruction>> GetAllInstructions();
        Task<Instruction> FindInstructionByIdAsync(string instructionId);
        Task<long> CreateInstruction(InstructionData data);
        Task<IEnumerable<Instruction>> SearchInstructions(string searchString);
        Task DeleteInstruction(long id);
    }
}