﻿using Microsoft.AspNetCore.Mvc;
using Services.api.Library.Core.Entities;
using Services.api.Library.Repository;

namespace Services.api.Library.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LibraryServiceController : ControllerBase
{
    private readonly IMongoRepository<AuhtorEntity> _authorGenericRepository;
    private readonly IAuthorRepository _authorRepository;

    public LibraryServiceController(IAuthorRepository authorRepository,
        IMongoRepository<AuhtorEntity> authorGenericRepository)
    {
        _authorRepository = authorRepository;
        _authorGenericRepository = authorGenericRepository;
    }

    [HttpGet("authors")]
    public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
    {
        var authors = await _authorRepository.GetAuthors();
        return Ok(authors);
    }

    [HttpGet("authorGeneric")]
    public async Task<ActionResult<IEnumerable<AuhtorEntity>>> GetAuthorsGeneric()
    {
        var authors = await _authorGenericRepository.GetAll();
        return Ok(authors);
    }
}