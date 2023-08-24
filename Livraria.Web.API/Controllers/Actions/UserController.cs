using AutoMapper;
using Livraria.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Web.API.Controllers.Actions;

[Route("bookstore/[controller]")]
[ApiController]
public class UserController : BookStoreControllerBase<UserController>
{
    private readonly IAuthorService _authorService;

    public UserController(ILogger<UserController> logger, IMapper mapper, IAuthorService authorService) 
        : base(logger, mapper)
    {
        _authorService = authorService;
    }
}
