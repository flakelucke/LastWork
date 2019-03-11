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
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(IUserRepository repository,
        SignInManager<User> signInManager)
        {
            this.repository = repository;
            this.signInManager = signInManager;
        }
        [HttpGet]
        [Authorize(Roles = "administrator")]
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
            var user = await repository.FindUserById(id);
            user.Instructions = null;
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAsync(string id, [FromBody] User user)
        {
            // if (user.Id == id || await userManager.IsInRoleAsync(user, "administrator"))
            // {
                await repository.DeleteUserAsync(id);
                return Ok();
            // }
            // return BadRequest();
        }
        [HttpPost("{id}")]
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> GiveAdminToUser([FromRoute] string id)
        {
            await repository.GiveAdminToUser(id);
            return Ok();
        }

        [HttpPost("pick/{id}")]
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> PickUpAdminAsync([FromRoute] string id)
        {
            await repository.PickUpAdminAsync(id);
            return Ok();
        }

        [HttpPost("block/{id}")]
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> BlockUserAsync([FromRoute] string id)
        {
            await repository.BlockUserAsync(id);
            return Ok();
        }
    }
}