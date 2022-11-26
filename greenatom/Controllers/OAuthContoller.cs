using AspNet.Security.OAuth.Vkontakte;
using greenatom.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                RedirectUri = Url.Action("GoogleResponse")
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> GoogleResponse()
        {
            Console.WriteLine($"Callback");
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal?.Identities.FirstOrDefault()?
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            Console.WriteLine($"Logged In: {result}");
            return new JsonResult(claims);
        }

        [HttpGet("/oauth/vk")]
        public async Task VkontakteOAuth()
        {
            await HttpContext.ChallengeAsync(VkontakteAuthenticationDefaults.AuthenticationScheme,
                new AuthenticationProperties()
                {
                    RedirectUri = Url.Action("VkontakteResponse")
                });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> VkontakteResponse()
        {
            Console.WriteLine($"Callback");
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = result.Principal?.Identities.FirstOrDefault()?
                .Claims.Select(claim => new
                {
                    claim.Issuer,
                    claim.OriginalIssuer,
                    claim.Type,
                    claim.Value
                });
            Console.WriteLine($"Logged In: {result}");
            return new JsonResult(claims);
        }
    }
}