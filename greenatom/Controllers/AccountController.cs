using System.Security.Claims;
using greenatom.Models;
using greenatom.Services;
using greenatom.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/")]
    public class AccountController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public AccountController(DatabaseService dbService)
        {
            _databaseService = dbService;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("login")]
        public IActionResult Login()
        {
            return this.Content(System.IO.File.ReadAllText("wwwroot/login.html"), "text/html");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (await _databaseService.CheckPassword(viewModel.Email, viewModel.Password))
            {
                await Authenticate(viewModel.Email);
                return Redirect("/");
            }
            return Redirect("/login");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/login");
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("recovery")]
        public IActionResult Recovery()
        {
            return this.Content(System.IO.File.ReadAllText("wwwroot/recovery.html"), "text/html");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("register")]
        public IActionResult Register()
        {
            return this.Content(System.IO.File.ReadAllText("wwwroot/register.html"), "text/html");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel viewModel)
        {
            await _databaseService.AddUser(new UserModel(viewModel.Email, viewModel.Password));
            await Authenticate(viewModel.Email);
            return Redirect("/");
        }
    }
}