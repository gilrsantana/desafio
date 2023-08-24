using System.Collections.Generic;
using System.Collections;
using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Service.Interfaces;
using Livraria.Web.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Serilog;

namespace Livraria.Web.API.Controllers.Actions;

[Route("bookstore/[controller]")]
[ApiController]
public class AuthorController : BookStoreControllerBase
{
    private readonly IAuthorService _authorService;
    
    public AuthorController(Serilog.ILogger logger, IMapper mapper, IAuthorService authorService) 
        : base(logger.ForContext<AuthorController>(), mapper)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthorsAsync(int skip = 0, int take = 25)
    {
        try
        {
            var authors = await _authorService.GetAllAuthorsAsync(skip, take);
            var authorsVm = _mapper.Map<List<Author>, ICollection<AuthorViewModel>>(authors.ToList());
            
            if (authorsVm is null)
            {
                _logger.Error("Author not found");
                return NotFound(new ResultViewModel<string>("Author not found"));
            }
            _logger.Information("Author founded!");
            return Ok(new ResultViewModel<ICollection<AuthorViewModel>>(authorsVm));
        }
        catch (Exception ex)
        {
            _logger.Error("{ExMessage} - Cod: ECAC01G", ex.Message);
            return StatusCode(500, new ResultViewModel<AuthorViewModel>($"{ex.Message} - Cod: ECAC01G" ));
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
            {
                _logger.Error("Author not found");
                return NotFound(new ResultViewModel<string>("Author not found"));
            }
            var authorVm = _mapper.Map<Author, AuthorViewModel>(author);
            if (authorVm is null)
            {
                _logger.Error("Author not found");
                return NotFound(new ResultViewModel<string>("Author not found"));
            }
            _logger.Information("Author founded!");
            return Ok(new ResultViewModel<AuthorViewModel>(authorVm));
        }
        catch (Exception ex)
        {
            _logger.Error("{ExMessage} - Cod: ECAC02G", ex.Message);
            return StatusCode(500, new ResultViewModel<AuthorViewModel>($"{ex.Message} - Cod: ECAC02G"));
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
            if (result is null)
            {
                _logger.Error("Error while adding author!");
                return BadRequest(new ResultViewModel<string>("Error while adding author!"));
            }

            _logger.Information("Author added successfully!");
            return Ok(new ResultViewModel<string>("Author added successfully!", new List<string>()) );
        }
        catch (Exception ex)
        {
            _logger.Error("{ExMessage} - Cod: ECAC01PO", ex.Message);
            return StatusCode(500, new ResultViewModel<AuthorViewModel>($"{ex.Message} - Cod: ECAC01PO"));
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthorAsync(Guid id, [FromBody] AuthorViewModel authorVM)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var authorEntity = _mapper.Map<AuthorViewModel, Author>(authorVM);
            var result = await _authorService.UpdateAuthorAsync(id, authorEntity);
            return result == true 
                ? Ok(new ResultViewModel<string>("Author added successfully!", new List<string>())) 
                : BadRequest(new ResultViewModel<string>("Error while adding author!"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<AuthorViewModel>($"{ex.Message} - Cod: ECAC01PU"));
        }
        
    }
}
