using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Web.API.Controllers;

public class BookStoreControllerBase : ControllerBase
{
    protected readonly Serilog.ILogger _logger;
    protected readonly IMapper _mapper;
    
    public BookStoreControllerBase(Serilog.ILogger logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }
}

