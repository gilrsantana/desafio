using AutoMapper;
using Livraria.Domain.Entities;
using Livraria.Web.API.ViewModels.Author;

namespace Livraria.Web.API.Mappings;

public class EntitiesToVMMappingProfile : Profile
{
    public EntitiesToVMMappingProfile()
    {
        CreateMap<Author, AuthorViewModel>().ReverseMap();
        CreateMap<Author, AuthorInputModel>().ReverseMap();
    }
}
