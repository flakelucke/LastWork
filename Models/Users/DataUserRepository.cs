using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LastWork.Models.Users
{
    public class DataUserRepository : IUserRepository
    {
        private readonly DataContext context;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> role;


        public DataUserRepository(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> role)
        {
            this.context = context;
            this.userManager = userManager;
            this.role = role;
        }
        public async Task DeleteUserAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user!=null)
            await userManager.DeleteAsync(user);
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            var result = await userManager.GetUsersInRoleAsync("user");
            foreach (var i in result)
            {
                context.Entry(i).Collection(x => x.Instructions).Load();
                AvoidRelatedUserData(i);
            }
            return result;
        }

        public async Task<IList<User>> GetAllAdminsAsync()
        {
            var result = await userManager.GetUsersInRoleAsync("administrator");
            foreach (var i in result)
            {
                context.Entry(i).Collection(x => x.Instructions).Load();
                AvoidRelatedUserData(i);
            }

            return result;
        }


        public async Task GiveAdminToUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, "administrator");
        }

        public async Task<User> FindUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            context.Entry(user).Collection(x => x.Instructions).Load();
            AvoidRelatedUserData(user);
            return user;
        }

        public void AvoidRelatedUserData(User user) {
            if (user != null)
            {
                if (user.Instructions != null)
                {
                    user.Instructions.Select(x=>x.User = null).ToList();
                }
            }
        }
    }
}