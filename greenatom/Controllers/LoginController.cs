using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/")]
    public class LoginControler : ControllerBase
    {
        List<User> people = new List<User>
        {
            new User("tom@gmail.com", "12345"),
            new User("bob@gmail.com", "55555")
        };

        private readonly ILogger<LoginControler> _logger;

        public LoginControler(ILogger<LoginControler> logger)
        {
            _logger = logger;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return this.Content(System.IO.File.ReadAllText("wwwroot/login.html"), "text/html");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            
            User? user = people.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                Console.WriteLine("Logging in...");
                await Authenticate(model.Email); // аутентификация
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
    }

    public record class LoginModel(string Email, string Password);

    public record class User(string Email, string Password);
}