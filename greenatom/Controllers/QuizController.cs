using greenatom.Models;
using greenatom.Services;
using greenatom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace greenatom.Controllers ;

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
        [Authorize]
        public async Task<IActionResult> Answers([FromBody] AnswerViewModel viewModel)
        {
            var dbU = await _databaseService.FindUser(User.Identity.Name);
            if (dbU == null)
            {
                Console.WriteLine("User Not Found");
                return NotFound();
            }
            int res = 0;
            float points;
            var correctAns = await _databaseService.GetAnswers(viewModel.TestName);
            int total = correctAns.Count();

            foreach (var ans in correctAns.Zip(viewModel.Answers, (x, y) => (x, y)))
                if (ans.x.Intersect(ans.y).Count() == ans.x.Count())
                    res++;

            points = (float)res / (float)total * 100;

            Console.WriteLine($"Res: {res}. Points: {points}");
            dbU.ReadyTask.RemoveAll(t => t.Name == viewModel.TestName);
            dbU.ReadyTask.Add(new TestHeader() { Name = viewModel.TestName, Wins = res });
            await _databaseService.Updateuser(dbU);
            return
                Ok(new QuizResultModel
                {
                    QuizName = viewModel.TestName,
                    Correct = res,
                    Total = total,
                    Points = (int)points
                });
        }

        [HttpGet("/quiz/gettests")]
        public async Task<AllTests> GetTests()
        {
            var res = await _databaseService.GetAllTests();
            return new AllTests() { tests = res };
        }

        [HttpPost("/quiz/setready")]
        [Authorize]
        public async Task<IActionResult> SetReady([FromBody] TaskReadyViewModel readyViewModel)
        {
            var dbU = await _databaseService.FindUser(User.Identity.Name);
            if (dbU == null)
            {
                Console.WriteLine("User Not Found");
                return NotFound();
            }
            if (dbU.ReadyTask == null)
                dbU.ReadyTask = new();
            dbU.ReadyTask.RemoveAll(t => t.Name == readyViewModel.TaskName);
            dbU.ReadyTask.Add(new TestHeader() { Name = readyViewModel.TaskName, Wins = readyViewModel.Wins });
            await _databaseService.Updateuser(dbU);
            Console.WriteLine($"ADD: {(readyViewModel.TaskName, readyViewModel.Wins)}");
            return Ok();
        }

        [HttpPost("/quiz/getready")]
        [Authorize]
        public async Task<TaskReadyViewModel> GetReady([FromBody] TaskNameViewModel taskName)
        {
            var fal = new TaskReadyViewModel() { Ready = false, TaskName = taskName.Name, Wins = 0 };
            var dbU = await _databaseService.FindUser(User.Identity.Name);
            if (dbU == null)
            {
                Console.WriteLine("User Not Found");
                return fal;
            }
            if (dbU.ReadyTask == null)
            {
                dbU.ReadyTask = new();
                await _databaseService.Updateuser(dbU);
            }

            var has = dbU.ReadyTask.Any(t => t.Name == taskName.Name);
            if (has == false)
                return fal;
            var find = dbU.ReadyTask.Find(t => t.Name == taskName.Name);
            return new TaskReadyViewModel() { Ready = true, TaskName = taskName.Name, Wins = find.Wins };
        }
    }