using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LastWork.Models.Instructions;
using LastWork.Models.InstructionSteps;
using LastWork.Models.Users;

namespace LastWork.Models.BindingTargets
{
    public class InstructionData
    {
        [Required]
        public string InstructionName { get; set; }
        [Required]
        public string Description
        {
            get; set;
        }
        [Required]
        public string Category { get; set;}
        public List<InstructionStepData> Steps { get; set; }

        public Instruction GetInstruction() => new Instruction()
        {
            InstructionName = InstructionName,
            Description = Description,
            Category = Category,
            Steps = Steps?.Select(s => s.GetInstructionStep()).ToList() ?? null
        };
    }
}