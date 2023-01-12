using Microsoft.AspNetCore.Mvc;
using Services.api.Library.Core.Entities;
using Services.api.Library.Repository;

namespace Services.api.Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryAuthorController : ControllerBase
{
    private readonly IMongoRepository<AuhtorEntity> _authorGenericRepository;

    public LibraryAuthorController(IMongoRepository<AuhtorEntity> authorGenericRepository)
    {
        _authorGenericRepository = authorGenericRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuhtorEntity>>> Get()
    {
        return Ok(await _authorGenericRepository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuhtorEntity>> GetById(string id)
    {
        var author = await _authorGenericRepository.GetById(id);
        return Ok(author);
    }

    [HttpPost]
    public async Task Post(AuhtorEntity author)
    {
        await _authorGenericRepository.InsertDocument(author);
    }

    [HttpPut("{id}")]
    public async Task Put(string id, AuhtorEntity author)
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
    public async Task<ActionResult<PaginationEntity<AuhtorEntity>>> PostPagination(
        PaginationEntity<AuhtorEntity> pagination)
    {
        var result =
            await _authorGenericRepository.PaginationByFilter(pagination);
        return Ok(result);
    }
}