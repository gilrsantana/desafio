using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Web.API.ViewModels;

namespace Livraria.Web.API.Mappings;

public class EntitiesToVMMappingProfile : Profile
{
    public EntitiesToVMMappingProfile()
    {
        CreateMap<Author, AuthorViewModel>().ReverseMap();
    }
}
