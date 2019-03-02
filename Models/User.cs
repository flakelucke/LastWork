using Microsoft.AspNetCore.Identity;

namespace LastWork.Models
{
    public class User : IdentityUser
    {
        public bool IsBlocked {get;set;}
    }
}