using System;
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
    public class UserController : Controller
    {
        private IUserRepository repository;
        private SignInManager<User> signInManager;

        public UserController(IUserRepository repository,
        SignInManager<User> signInManager)
        {
            this.repository = repository;
            this.signInManager = signInManager;
        }
        [HttpGet]
        [Authorize]
        public async Task<IList<User>> GetAllUsersAsync()
        {
            return await repository.GetAllUsersAsync();
        }
        [HttpGet("admins")]
        [Authorize(Roles = "administrator")]
        public async Task<IList<User>> GetAllAdminsAsync()
        {
            return await repository.GetAllAdminsAsync();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> FindUserById(string id)
        {   
            return Ok(await repository.FindUserById(id));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAsync(string id,[FromBody] User user)
        {
            if (user.Id == id)
            {
                await repository.DeleteUserAsync(id);
                return Ok("myself");
            }
            else
            {
                await repository.DeleteUserAsync(id);
            }
            return Ok("delete");
        }
    }
}