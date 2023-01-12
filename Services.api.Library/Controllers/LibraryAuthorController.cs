using Microsoft.AspNetCore.Mvc;
using Services.api.Library.Core.Entities;
using Services.api.Library.Repository;

namespace Services.api.Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryAuthorController : ControllerBase
{
    private readonly IMongoRepository<AuthorEntity> _authorGenericRepository;

    public LibraryAuthorController(IMongoRepository<AuthorEntity> authorGenericRepository)
    {
        _authorGenericRepository = authorGenericRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorEntity>>> Get()
    {
        return Ok(await _authorGenericRepository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorEntity>> GetById(string id)
    {
        var author = await _authorGenericRepository.GetById(id);
        return Ok(author);
    }

    [HttpPost]
    public async Task Post(AuthorEntity author)
    {
        await _authorGenericRepository.InsertDocument(author);
    }

    [HttpPut("{id}")]
    public async Task Put(string id, AuthorEntity author)
    {
        author.Id = id;
        await _authorGenericRepository.UpdateDocument(author);
    }

    [HttpDelete("{id}")]
    public async Task Delete(string id)
    {
        await _authorGenericRepository.DeleteById(id);
    }

    [HttpPost("pagination")]
    public async Task<ActionResult<PaginationEntity<AuthorEntity>>> PostPagination(
        PaginationEntity<AuthorEntity> pagination)
    {
        var result =
            await _authorGenericRepository.PaginationByFilter(pagination);
        return Ok(result);
    }
}