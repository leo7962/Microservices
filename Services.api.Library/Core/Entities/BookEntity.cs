using MongoDB.Bson.Serialization.Attributes;

namespace Services.api.Library.Core.Entities;

[BsonCollection("Book")]
public class BookEntity : Document
{
    [BsonElement("title")] public string? Title { get; set; }
    [BsonElement("description")] public string? Description { get; set; }
    [BsonElement("price")] public int Price { get; set; }
    [BsonElement("`publicationDate")] public DateTime? PublicationDate { get; set; }
    [BsonElement("author")] public AuthorEntity? Author { get; set; }
}