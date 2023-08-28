using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Service.Interfaces;
using Livraria.Shared.Messages;
using Livraria.Shared.Presenters;
using Livraria.Web.API.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;

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
            if (authors.Data == null || authors.Errors.Any() || !authors.Data.Any())
            {
                _logger.Error(Error.Author.NOT_FOUND);
                return NotFound(new Presenter<string>(authors.ErrorsToString()));
            }
            var authorsVm = _mapper
                .Map<List<Author>, ICollection<AuthorViewModel>>(authors.Data.ToList());
            
            return Ok(new Presenter<ICollection<AuthorViewModel>>(authorsVm));
        }
        catch (Exception ex)
        {
            _logger.Error("{ExMessage} - Cod: ECAC01G", ex.Message);
            return StatusCode(500, new Presenter<AuthorViewModel>($"{ex.Message} - Cod: ECAC01G" ));
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
    {
        try
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author.Errors.Any() || author.Data is null)
            {
                _logger.Error(Error.Author.NOT_FOUND);
                return NotFound(new Presenter<string>(author.ErrorsToString()));
            }

            var authorVm = _mapper.Map<Author, AuthorViewModel>(author.Data);
            return Ok(new Presenter<AuthorViewModel>(authorVm));
        }
        catch (Exception ex)
        {
            _logger.Error("{ExMessage} - Cod: ECAC02G", ex.Message);
            return StatusCode(500, new Presenter<AuthorViewModel>($"{ex.Message} - Cod: ECAC02G"));
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorInputModel authorIm)
    {
        try
        {
            if (authorIm.Notifications is not null && authorIm.Notifications.Any())
            {
                _logger.Error(Error.Common.INVALID_MODEL);
                var errors = string.Join(", ", authorIm.Notifications.Select(n => $"({n.Key}) - {n.Message}"));
                return BadRequest(new Presenter<string>(errors));
            }
            
            var authorEntity = _mapper.Map<AuthorInputModel, Author>(authorIm);

            var result = await _authorService.InsertAuthorAsync(authorEntity);
            if (result.Errors.Any() || !result.Data)
            {
                _logger.Error(Error.Author.NOT_INSERTED);
                return BadRequest(new Presenter<string>(result.ErrorsToString()));
            }

            return Ok(new Presenter<string>(Success.Author.INSERTED, new List<string>()) );
        }
        catch (Exception ex)
        {
            _logger.Error("{ExMessage} - Cod: ECAC01PO", ex.Message);
            return StatusCode(500, new Presenter<AuthorViewModel>($"{ex.Message} - Cod: ECAC01PO"));
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthorAsync(Guid id, [FromBody] AuthorInputModel authorIm)
    {
        try
        {
            if (authorIm.Notifications is not null && authorIm.Notifications.Any())
            {
                _logger.Error(Error.Common.INVALID_MODEL);
                var errors = string.Join(", ", authorIm.Notifications.Select(n => $"({n.Key}) - {n.Message}"));
                return BadRequest(new Presenter<string>(errors));
            }

            var authorEntity = _mapper.Map<AuthorInputModel, Author>(authorIm);

            var result = await _authorService.UpdateAuthorAsync(id, authorEntity);
            if (result.Errors.Any() || !result.Data)
            {
                _logger.Error(Error.Author.NOT_UPDATED);
                return BadRequest(new Presenter<string>(result.ErrorsToString()));
            }

            return Ok(new Presenter<string>(Success.Author.UPDATED, new List<string>()));
        }
        catch (Exception ex)
        {
            _logger.Error("{ExMessage} - Cod: ECAC01PU", ex.Message);
            return StatusCode(500, new Presenter<AuthorViewModel>($"{ex.Message} - Cod: ECAC01PU"));
        }
        
    }
}
