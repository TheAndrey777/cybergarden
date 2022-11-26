using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace greenatom.Models;

public class QuizModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("problems")]
    public List<Problem> Problems { get; set; }
}

public class Problem
{
    [BsonElement("question")]
    public string Question { get; set; }

    [BsonElement("answers")]
    public List<string> Answers { get; set; }
}

