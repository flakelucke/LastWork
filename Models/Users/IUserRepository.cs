using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LastWork.Models.Users 
{
    public interface IUserRepository
    {
        Task DeleteUserAsync(string id);
        Task<IList<User>> GetAllUsersAsync(); 
        Task<IList<User>> GetAllAdminsAsync(); 
        Task<User> FindUserById(string id);
        Task GiveAdminToUser(string id);
        Task PickUpAdminAsync(string id);
        Task BlockUserAsync(string id);
    }
}