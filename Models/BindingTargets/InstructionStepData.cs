using System.ComponentModel.DataAnnotations;
using LastWork.Models.InstructionSteps;

namespace LastWork.Models.BindingTargets
{
    public class InstructionStepData
    {
        [Required]
        public string StepName { get; set; }
        [Required]
        public string StepDescription { get; set; }
        public InstructionStep GetInstructionStep()
        {
            return new InstructionStep
            {
                StepName = StepName,
                StepDescription = StepDescription
            };
        }
    }
}