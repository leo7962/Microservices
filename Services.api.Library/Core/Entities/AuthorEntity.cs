using MongoDB.Bson.Serialization.Attributes;

namespace Services.api.Library.Core.Entities;

[BsonCollection("Author")]
public class AuthorEntity : Document
{
    [BsonElement("name")] public string? Name { get; set; }
    [BsonElement("lastname")] public string? LastName { get; set; }
    [BsonElement("degree")] public string? Degree { get; set; }
}