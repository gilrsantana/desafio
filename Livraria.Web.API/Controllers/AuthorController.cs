using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Service.Interfaces;
using Livraria.Web.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        try
        {
            var authors = await _authorService.GetAllAuthorsAsync(skip, take);
            var authorsVm = _mapper
                                                        .Map<EnumerableQuery<Author>, EnumerableQuery<AuthorViewModel>>
                                                        ((EnumerableQuery<Author>)authors
                                                            .AsQueryable().OrderBy(x => x.Name));
            return authorsVm == null ? NotFound() : Ok(authorsVm);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<AuthorViewModel>(ex.Message));
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
    {
        if(id == Guid.Empty)
            return BadRequest(new ResultViewModel<string>("Invalid id"));
        try
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author is null)
                return NotFound(new ResultViewModel<string>("Author not found"));
            var authorVm = _mapper.Map<Author, AuthorViewModel>(author);
            return authorVm == null 
                ? NotFound(new ResultViewModel<string>("Author not found")) 
                : Ok(new ResultViewModel<AuthorViewModel>(authorVm));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<AuthorViewModel>(ex.Message));
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorInputModel authorIm)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<ModelStateDictionary>(ModelState));
            var authorEntity = _mapper.Map<AuthorInputModel, Author>(authorIm);
            var result = await _authorService.InsertAuthorAsync(authorEntity);
            return result is true
                ? Ok(new ResultViewModel<string>("Author added successfully!", new List<string>()) )
                : BadRequest(new ResultViewModel<string>("Error while adding author!"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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
