using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LastWork.Models.Users
{
    public class DataUserRepository : IUserRepository
    {
        private readonly DataContext identityDataContext;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> role;


        public DataUserRepository(DataContext context,UserManager<User> userManager,RoleManager<IdentityRole> role)
        {
            identityDataContext = context;
            this.userManager = userManager;
            this.role = role;
        }
        public async Task DeleteUserAsync(long id)
        {
           var user = await userManager.FindByIdAsync(id.ToString());
           await userManager.DeleteAsync(user);
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {        
            var k =await userManager.FindByEmailAsync("kolyamyalik0@gmail.com");
            return await userManager.GetUsersInRoleAsync("user");
        }

        public async Task<IList<User>> GetAllAdminsAsync()
        {
            return await userManager.GetUsersInRoleAsync("administrator");
        }

        
        public async Task GiveAdminToUser(long id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            await userManager.AddToRoleAsync(user, "administrator");
        }

        public async Task<User> FindUserById(string id)
        {
            var k = await userManager.FindByIdAsync(id);
            return await userManager.FindByIdAsync(id);
        }
    }
}