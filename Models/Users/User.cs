using System.Collections.Generic;
using LastWork.Models.Instructions;
using Microsoft.AspNetCore.Identity;

namespace LastWork.Models.Users
{
    public class User : IdentityUser
    {
        public bool IsBlocked {get;set;}
        public List<Instruction> Instructions {get; set;}
    }
}