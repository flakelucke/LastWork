using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LastWork.Models.Users
{
    public class DataUserRepository : IUserRepository
    {
        private readonly DataContext identityDataContext;
        private UserManager<User> userManager;


        public DataUserRepository(DataContext context,UserManager<User> userManager)
        {
            identityDataContext = context;
            this.userManager = userManager;
        }
        public async Task DeleteUserAsync(long id)
        {
           var user = await userManager.FindByIdAsync(id.ToString());
           await userManager.DeleteAsync(user);
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            return await userManager.GetUsersInRoleAsync("administrator");
        }

        public async Task GiveAdminToUser(long id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            await userManager.AddToRoleAsync(user, "administrator");
        }
    }
}