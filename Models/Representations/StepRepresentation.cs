using System.Collections.Generic;
using LastWork.Models.InstructionSteps;

namespace LastWork.Models.Representation
{
    public class StepRepresentation
    {
        public long InstructionStepId {get; set; }
        public string StepName { get; set; }
        public string StepDescription { get; set; }

        public StepRepresentation(InstructionStep instructionStep) {
            InstructionStepId = instructionStep.InstructionStepId;
            StepName = instructionStep.StepName;
            StepDescription = instructionStep.StepDescription;
        }

    }
}