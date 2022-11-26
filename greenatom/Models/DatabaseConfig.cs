namespace greenatom.Models ;

    public class DatabaseConfig
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string UsersCollectionName { get; set; } = "";
        public string PollsCollectionName { get; set; } = "";
    }