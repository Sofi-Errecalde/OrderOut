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
            CreateMap<ProductDto, GetProductDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<TableWaiter, TableWaiterDto>().ReverseMap();
            CreateMap<Order, NewOrderDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProduct>().ReverseMap();
            CreateMap<Order, Order>();
            CreateMap<User, User>();
            CreateMap<CreateBillDto, Bill>().ReverseMap();
        }
    }

    }
