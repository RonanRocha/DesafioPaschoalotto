using AutoMapper;
using DesafioPaschoalotto.Application.ViewModels;
using DesafioPaschoalotto.Domain.Entities;

namespace DesafioPaschoalotto.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, UserDetailViewModel>().ReverseMap();
            CreateMap<Document, DocumentViewModel>().ReverseMap();
            CreateMap<Location, LocationViewModel>().ReverseMap();
            CreateMap<Contact, ContactViewModel>().ReverseMap();

        }
    }
}
