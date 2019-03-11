using System.Collections.Generic;
using System.Threading.Tasks;
using LastWork.Models.BindingTargets;
using LastWork.Models.Users;

namespace LastWork.Models.Instructions
{
    public interface IInstructionRepository
    {
        Task<IEnumerable<Instruction>> GetAllInstructions(string category);
        Task<Instruction> FindInstructionByIdAsync(long instructionId);
        Task<long> CreateInstruction(InstructionData data, User currentUser);
        Task<IEnumerable<Instruction>> SearchInstructions(string searchString);
        Task DeleteInstruction(Instruction instruction);
    }
}