using System.ComponentModel.DataAnnotations;

namespace LastWork.Models.BindingTargets
{
    public class InstuctionData
    {
        [Required]
        public string InsructionName { get; set; }
        [Required]
        public string Description { get; set; }
        public Insruction Insruction => new Insruction {
        InsructionName = InsructionName, Description = Description
        };
    }
}