namespace greenatom.ViewModels ;

    public record AnswerViewModel
    {
        public string TestName { get; set; }
        public List<List<string>> Answers { get; set; }
    }