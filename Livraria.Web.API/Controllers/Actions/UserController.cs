using AutoMapper;
using Livraria.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Web.API.Controllers.Actions;

[Route("bookstore/[controller]")]
[ApiController]
public class UserController : BookStoreControllerBase
{
    private readonly IAuthorService _authorService;

    public UserController(Serilog.ILogger logger, IMapper mapper, IAuthorService authorService) 
        : base(logger.ForContext<UserController>(), mapper)
    {
        _authorService = authorService;
    }
}
