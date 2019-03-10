using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LastWork.Models.Instructions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LastWork.Models.Users
{
    public class DataUserRepository : IUserRepository
    {
        private readonly DataContext context;
        private UserManager<User> userManager;

        public DataUserRepository(DataContext context,
        UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task DeleteUserAsync(string id)
        {
            var takeUser = await FindUserById(id);
            if (takeUser != null)
            {
                await userManager.DeleteAsync(takeUser);
            }

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
            var takeUser = await userManager.FindByIdAsync(id);
            if (takeUser != null)
            {
                await userManager.RemoveFromRoleAsync(takeUser, "user");
                await userManager.AddToRoleAsync(takeUser, "administrator");
            }
        }

        public async Task<User> FindUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                context.Entry(user).Collection(x => x.Instructions).Load();
                AvoidRelatedUserData(user);
            }
            user.Instructions.Reverse();
            return user;
        }

        public static void AvoidRelatedUserData(User user)
        {
            if (user != null)
            {
                if (user.Instructions != null)
                {
                    user.Instructions.Select(x => x.User = null).ToList();
                }
            }
        }

        public async Task PickUpAdminAsync(string id)
        {
            var takeUser = await userManager.FindByIdAsync(id);
            if (takeUser != null)
            {
                await userManager.RemoveFromRoleAsync(takeUser, "administrator");
                await userManager.AddToRoleAsync(takeUser, "user");
            }
        }

        public async Task BlockUserAsync(string id)
        {
            var takeUser = await userManager.FindByIdAsync(id);
            if (takeUser != null)
            {
                if (takeUser.IsBlocked)
                {
                    takeUser.IsBlocked = false;
                }
                else takeUser.IsBlocked = true;
            }
            await context.SaveChangesAsync();
        }
    }
}