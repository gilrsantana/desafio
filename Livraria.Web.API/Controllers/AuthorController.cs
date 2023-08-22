using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Service.Interfaces;
using Livraria.Web.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Web.API.Controllers;

[Route("bookstore/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;
    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthorsAsync(int skip = 0, int take = 25)
    {
        var authors = await _authorService.GetAllAuthorsAsync(skip, take);
        var authorsVM = _mapper.Map<List<Author>, List<AuthorViewModel>>(authors.ToList());
        return authorsVM == null ? NotFound() : Ok(authorsVM);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
    {
        var author = await _authorService.GetAuthorByIdAsync(id);
        if (author == null)
            return NotFound();
        var authorVM = _mapper.Map<Author, AuthorViewModel>(author);
        return authorVM == null ? NotFound() : Ok(authorVM);
    }


    [HttpPost]
    public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorViewModel authorVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var authorEntity = _mapper.Map<AuthorViewModel, Author>(authorVM);
        var result = await _authorService.InsertAuthorAsync(authorEntity);
        return result != null && result == true ? Ok("Author added successfully!") : BadRequest("Error while adding author!");
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthorAsync(Guid id, [FromBody] AuthorViewModel authorVM)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var authorEntity = _mapper.Map<AuthorViewModel, Author>(authorVM);
        var result = await _authorService.UpdateAuthorAsync(id, authorEntity);
        return result != null && result == true ? Ok("Author added successfully!") : BadRequest("Error while adding author!");
    }
}