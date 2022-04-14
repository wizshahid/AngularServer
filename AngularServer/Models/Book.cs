using MongoDB.Bson.Serialization.Attributes;

namespace AngularServer.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string BookName { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int Price { get; set; }
}
