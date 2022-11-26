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
    [Route("/oauth")]
    public class OAuthController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public OAuthController(DatabaseService dbService)
        {
            _databaseService = dbService;
        }

        [HttpGet("google")]
        public async Task GoogleOAuth()
        {
            await HttpContext.ChallengeAsync("google");
        }
    }
}