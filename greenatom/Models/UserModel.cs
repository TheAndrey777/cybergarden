using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace greenatom.Models ;

    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("formData")]
        public FormDataModel Form { get; set; }

        [BsonElement("roles")]
        public string Roles { get; set; }

        [BsonElement("readyTask")]
        public List<TestHeader> ReadyTask { get; set; }

        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
            Form = new FormDataModel();
            ReadyTask = new();
        }
    }