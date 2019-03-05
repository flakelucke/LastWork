using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using LastWork.Models;
using LastWork.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LastWork.Controllers.Users
{
    [Route("api/users")]
    [Authorize(Roles = "administrator")]
    public class UserController : Controller
    {
        private IUserRepository repository;

        public UserController(IUserRepository repository) {
            this.repository = repository;
        }
        public async Task<IList<User>> GetAllUsersAsync()
        {
            return await repository.GetAllUsersAsync();;
        }

    }
}