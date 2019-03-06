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
    [Authorize(Roles = "administrator")]
    public class UserController : Controller
    {
        private IUserRepository repository;

        public UserController(IUserRepository repository) {
            this.repository = repository;
        }
        [HttpGet("users")]
        public async Task<IList<User>> GetAllUsersAsync()
        {
            return await repository.GetAllUsersAsync();
        }
        [HttpGet("admins")]
        public async Task<IList<User>> GetAllAdminsAsync() {
            return await repository.GetAllAdminsAsync();
        }
        
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUserAsync(string id) {
            await repository.DeleteUserAsync(Convert.ToInt64(id));
            return Ok();
        }
    }
}