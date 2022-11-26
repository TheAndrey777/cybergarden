using greenatom.Services;
using greenatom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers;

[ApiController]
[Route("/api")]
public class QuizController : ControllerBase
{
    private readonly DatabaseService _databaseService;

    public QuizController(DatabaseService dbService)
    {
        _databaseService = dbService;
    }

    [HttpPost("/quiz/add")]
    public async Task<IActionResult> Add([FromBody] QuizModel quiz)
    {
        await _databaseService.AddQuiz(quiz);
        return Ok();
    }

    [HttpPost("/quiz/get")]
    public async Task<QuizModel> Get([FromBody] string name)
    {
        return await _databaseService.GetQuiz(name);
    }

    /*[HttpPost("/quiz/answers")]
    public async Task<IActionResult> Answers([FromBody] )
    {

    }*/
}
