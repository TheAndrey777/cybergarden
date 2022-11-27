using greenatom.Services;
using greenatom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers
{
    [ApiController]
    [Route("/form")]
    [Authorize]
    public class FormController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public FormController(DatabaseService dbService)
        {
            _databaseService = dbService;
        }

        [HttpGet]
        public IActionResult GetHtml()
        {
            return Content(System.IO.File.ReadAllText("wwwroot/form.html"), "text/html");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostForm([FromBody] FormViewModel formData)
        {
            var dbUser = await _databaseService.FindUser(User.Identity.Name);
            var formDataModel = dbUser.Form;
            formDataModel.FullName = formData.FullName;
            formDataModel.Occupation = formData.Occupation;
            formDataModel.DateBirth = formData.DateBirth;
            formDataModel.FamiliarWithProgramming = formData.FamiliarWithProgramming;
            formDataModel.MajorCommercialProjects = formData.MajorCommercialProjects;
            formDataModel.IsSet = true;
            dbUser.Form = formDataModel;
            await _databaseService.AddUser(dbUser);
            Console.WriteLine($"Data: {formData}");
            return Redirect("/");
        }
    }
}