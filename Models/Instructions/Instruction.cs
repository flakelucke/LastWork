using System.Collections.Generic;
using LastWork.Models.InstructionSteps;

namespace LastWork.Models.Instructions
{
    public class Instruction
    {
        public long InstructionId {get; set; }
        public string InstructionName { get; set; }
        public string Description { get; set; }
        public List<InstructionStep> Steps { get; set; }

    }
}