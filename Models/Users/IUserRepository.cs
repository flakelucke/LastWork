using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LastWork.Models.Users 
{
    public interface IUserRepository
    {
        Task DeleteUserAsync(long id);
        Task<IList<User>> GetAllUsersAsync(); 
        Task<IList<User>> GetAllAdminsAsync(); 
        Task GiveAdminToUser(long id);
    }
}