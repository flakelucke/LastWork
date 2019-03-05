using Microsoft.AspNetCore.Identity;

namespace LastWork.Models.Users
{
    public class User : IdentityUser
    {
        public bool IsBlocked {get;set;}
    }
}