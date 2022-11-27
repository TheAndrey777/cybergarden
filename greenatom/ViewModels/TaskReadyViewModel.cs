namespace greenatom.ViewModels ;

    public record TaskReadyViewModel
    {
        public string TaskName { get; set; }
        public bool Ready { get; set; }

        public int Wins { get; set; }
    }