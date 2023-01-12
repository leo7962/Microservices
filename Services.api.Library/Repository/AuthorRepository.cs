using MongoDB.Driver;
using Services.api.Library.Core.ContextMongoDb;
using Services.api.Library.Core.Entities;

namespace Services.api.Library.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly IAuthorContext _authorContext;

    public AuthorRepository(IAuthorContext authorContext)
    {
        _authorContext = authorContext;
    }

    public async Task<IEnumerable<Author>> GetAuthors()
    {
        return await _authorContext.Authors.Find(x => true).ToListAsync();
    }
}