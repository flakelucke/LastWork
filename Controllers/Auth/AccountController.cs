using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using LastWork.Models;
using LastWork.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LastWork.Auth.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMrg,
                                    SignInManager<User> signInMgr)
        {
            userManager = userMrg;
            signInManager = signInMgr;
        }

        [HttpPost("/api/account/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel creds)
        {
            User user = await userManager.FindByNameAsync(creds.Name);
            if (ModelState.IsValid && await DoLogin(creds))
            {
                if (await userManager.IsEmailConfirmedAsync(user)&& user.IsBlocked != true)
                {
                    if (await userManager.IsInRoleAsync(user, "administrator"))
                    {
                        return Ok($"admin+{user.Id}");
                    }
                    else return Ok($"user +{user.Id}");
                }
                else
                    BadRequest("confim");
            }
            return BadRequest(ModelState);
        }
        [HttpPost("/api/account/logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("/api/account/register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel creds)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = creds.Email, UserName = creds.Email };
                IdentityResult result = await userManager.CreateAsync(user, creds.Password);
                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = user.Id, code = code },
                    protocol: HttpContext.Request.Scheme);

                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(user.Email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по <a href='{callbackUrl}'>ссылке</a>");

                    await userManager.AddToRoleAsync(user, "user");
                    return Ok();
                }
                return BadRequest(result);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest();
            }
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectPermanent("/login");
            else
                return BadRequest();
        }

        private async Task<bool> DoLogin(LoginViewModel creds)
        {
            User user = await userManager.FindByNameAsync(creds.Name);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await signInManager.PasswordSignInAsync(user, creds.Password,
                        true, false);
                return result.Succeeded;
            }
            return false;
        }
    }
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}