namespace LastWork.Models.BindingTargets
{
    public class InstructionStepData
    {
        [Required]
        public string StepName { get; set; }
        [Required]
        public string StepDescription { get; set; }
        public InstructionStep InstructionStep => new InstructionStep {
        StepName = StepName, StepDescription = StepDescription
        };
    }
}