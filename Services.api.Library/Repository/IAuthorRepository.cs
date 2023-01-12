using Services.api.Library.Core.Entities;

namespace Services.api.Library.Repository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAuthors();
}