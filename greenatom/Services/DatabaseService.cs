using greenatom.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace greenatom.Services ;

    public class DatabaseService
    {
        private readonly IMongoCollection<UserModel> _usersCollection;

        public DatabaseService(IOptions<DatabaseConfig> config)
        {
            MongoClient client = new MongoClient(config.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(config.Value.DatabaseName);
            _usersCollection = database.GetCollection<UserModel>(config.Value.CollectionName);
        }

        public async Task AddUser(UserModel user)
        {
            await _usersCollection.InsertOneAsync(user);
        }

        public async Task<bool> FindUser(string username)
        {
            var user = await _usersCollection.Find(user => user.Username == username).FirstOrDefaultAsync();
            return user is not null;
        }

        public async Task<bool> CheckPassword(string username, string password)
        {
            var user =
                await _usersCollection.Find(user => user.Username == username && user.Password == password)
                    .FirstOrDefaultAsync();
            return user is not null;
        }
    }