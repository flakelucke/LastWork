using System.ComponentModel.DataAnnotations;

namespace LastWork.Models.Users
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}