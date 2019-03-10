using System.Collections.Generic;
using System.Linq;
using LastWork.Models.Instructions;

namespace LastWork.Models.Representation
{
    public class InstructionsRepresentation
    {
        public long InstructionId {get; set; }
        public string InstructionName { get; set; }
        public string Description { get; set; }
        public IEnumerable<StepRepresentation> Steps { get; set; }
        
        public InstructionsRepresentation(Instruction instruction) {
            InstructionId = instruction.InstructionId;
            InstructionName = instruction.InstructionName;
            Description = instruction.Description;
            Steps = instruction.Steps.Select(x=>new StepRepresentation(x));
        }
    }
}