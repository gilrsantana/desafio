using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Web.API.Controllers;

public class BookStoreControllerBase<T> : ControllerBase
{
    protected readonly ILogger<T> _logger;
    protected readonly IMapper _mapper;
    
    public BookStoreControllerBase(ILogger<T> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }
    
}

