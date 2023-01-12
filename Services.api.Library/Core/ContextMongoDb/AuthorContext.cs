using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.api.Library.Core.Entities;

namespace Services.api.Library.Core.ContextMongoDb;

public class AuthorContext : IAuthorContext
{
    private readonly IMongoDatabase _db;

    public AuthorContext(IOptions<MongoSettings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _db = client.GetDatabase(options.Value.Database);
    }

    public IMongoCollection<Author> Authors => _db.GetCollection<Author>("Author");
}