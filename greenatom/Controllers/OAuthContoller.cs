using AspNet.Security.OAuth.Discord;
using AspNet.Security.OAuth.Vkontakte;
using greenatom.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/")]
    public class OAuthController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public OAuthController(DatabaseService dbService)
        {
            _databaseService = dbService;
        }

        [HttpGet("/oauth/google")]
        public async Task GoogleOAuth()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = "/google-response",
            });
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            Console.WriteLine();
            Console.WriteLine($"Google:");
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            foreach (var pair in result.Ticket.Properties.Items)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            if (result.Succeeded)
                return Redirect("/");
            return Redirect("/login");
        }

        [HttpGet("/oauth/vk")]
        public async Task VkontakteOAuth()
        {
            await HttpContext.ChallengeAsync(VkontakteAuthenticationDefaults.AuthenticationScheme,
                new AuthenticationProperties()
                {
                    RedirectUri = "/vk-response"
                });
        }

        [HttpGet("vk-response")]
        public async Task<IActionResult> VkontakteResponse()
        {
            Console.WriteLine();
            Console.WriteLine($"VK:");
            var result = await HttpContext.AuthenticateAsync(VkontakteAuthenticationDefaults.AuthenticationScheme);

            foreach (var pair in result.Ticket.Properties.Items)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            if (result.Succeeded)
                return Redirect("/");
            return Redirect("/login");
        }

        [HttpGet("/oauth/discord")]
        public async Task DiscordOAuth()
        {
            await HttpContext.ChallengeAsync(DiscordAuthenticationDefaults.AuthenticationScheme,
                new AuthenticationProperties()
                {
                    RedirectUri = "/discord-response"
                });
        }

        [HttpGet("discord-response")]
        public async Task<IActionResult> DiscordResponse()
        {
            Console.WriteLine();
            Console.WriteLine($"Discord:");
            var result = await HttpContext.AuthenticateAsync(DiscordAuthenticationDefaults.AuthenticationScheme);

            foreach (var pair in result.Ticket.Properties.Items)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            if (result.Succeeded)
                return Redirect("/");
            return Redirect("/login");
        }
    }
}