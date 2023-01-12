using Microsoft.AspNetCore.Mvc;
using Services.api.Library.Core.Entities;
using Services.api.Library.Repository;

namespace Services.api.Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMongoRepository<BookEntity> _bookRepository;

    public BooksController(IMongoRepository<BookEntity> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpPost]
    public async Task Post(BookEntity book)
    {
        await _bookRepository.InsertDocument(book);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookEntity>>> Get()
    {
        return Ok(await _bookRepository.GetAll());
    }

    [HttpPost("pagination")]
    public async Task<ActionResult<PaginationEntity<BookEntity>>> PostPagination(
        PaginationEntity<BookEntity> pagination)
    {
        var results = await _bookRepository.PaginationByFilter(pagination);
        return Ok(results);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookEntity>> GetById(string id)
    {
        var book = await _bookRepository.GetById(id);
        return Ok(book);
    }
}