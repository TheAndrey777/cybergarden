﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace greenatom.Models;

public class UserModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";

    [BsonElement("username")]
    public string Username { get; set; }

    [BsonElement("password")]
    public string Password { get; set; }

    public UserModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}