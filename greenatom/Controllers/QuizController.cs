using greenatom.Services;
using greenatom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

    [HttpPost("/quiz/answers")]
    public async Task<IActionResult> Answers([FromBody] List<List<string>> answers, string name)
    {
        int res = 0;
        float points;
        var correctAns = await _databaseService.GetAnswers(name);
        int total = correctAns.Count();

        foreach (var ans in correctAns.Zip(answers, (x, y) => (x, y)))
            if (ans.x.Intersect(ans.y).Count() == ans.x.Count())
                res++;

        points = (float)res / (float)total * 100;

        Console.WriteLine($"Res: {res}. Points: {points}");
        return Ok(new QuizResultModel { QuizName = name, Correct = res, Total = total, Points = (int)points});
    }
}
