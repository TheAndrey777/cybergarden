using greenatom.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace greenatom.Services ;

    public class DatabaseService
    {
        private readonly IMongoCollection<UserModel> _usersCollection;
        private readonly IMongoCollection<QuizModel> _pollsCollection;

        public DatabaseService(IOptions<DatabaseConfig> config)
        {
            MongoClient client = new MongoClient(config.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(config.Value.DatabaseName);
            _usersCollection = database.GetCollection<UserModel>(config.Value.UsersCollectionName);
            _pollsCollection = database.GetCollection<QuizModel>(config.Value.PollsCollectionName);
        }

        public async Task AddUser(UserModel user)
        {
            await _usersCollection.ReplaceOneAsync(u => u.Id == user.Id, user, new ReplaceOptions { IsUpsert = true });
        }

        public async Task<bool> UserExist(string username)
        {
            var user = await _usersCollection.Find(user => user.Username == username).FirstOrDefaultAsync();
            return user is not null;
        }

        public async Task<UserModel> FindUser(string username)
        {
            var user = await _usersCollection.Find(user => user.Username == username).FirstOrDefaultAsync();
            return user;
        }

        public async Task<UserModel> FindUserById(string id)
        {
            var user = await _usersCollection.Find(user => user.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<bool> CheckPassword(string username, string password)
        {
            var user =
                await _usersCollection.Find(user => user.Username == username && user.Password == password)
                    .FirstOrDefaultAsync();
            return user is not null;
        }

        public async Task<QuizModel> GetQuiz(string name)
        {
            var data = await _pollsCollection.Find(poll => poll.Name == name).FirstOrDefaultAsync();
            if (data is not null)
                data.correctAnswers = null;

            return data;
        }

        public async Task AddQuiz(QuizModel quiz)
        {
            await _pollsCollection.InsertOneAsync(quiz);
        }

        public async Task<List<List<string>>> GetAnswers(string name)
        {
            var data = await _pollsCollection.Find(poll => poll.Name == name).FirstOrDefaultAsync();
            return data.correctAnswers;
        }
    }