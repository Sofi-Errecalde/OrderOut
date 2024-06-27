using AutoMapper;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<TableWaiter, TableWaiterDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProduct>().ReverseMap();
            CreateMap<Order, Order>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Table, opt => opt.MapFrom(src => src.Table))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ReverseMap();
            CreateMap<User, User>()
             .ForMember(dest => dest.UsersRoles, opt => opt.MapFrom(src => src.UsersRoles.Select(ur => ur.Role)))
             .ReverseMap();
        }
    }

    }
