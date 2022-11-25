using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllersz
{
    [ApiController]
    [Route("/login")]
    public class LoginControler : ControllerBase
    {
        private readonly ILogger<LoginControler> _logger;

        public LoginControler(ILogger<LoginControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ContentResult Index() 
        {
            return base.Content("<div>Hello</div>", "text/html");
        }
    }
}