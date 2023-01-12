using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.api.Library.Core.Entities;

public class Author
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")] public string? Name { get; set; }
    [BsonElement("lastname")] public string? LastName { get; set; }
    [BsonElement("degree")] public string? Degree { get; set; }
}