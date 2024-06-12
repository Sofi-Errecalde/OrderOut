using AutoMapper;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, Product>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }

    }
}