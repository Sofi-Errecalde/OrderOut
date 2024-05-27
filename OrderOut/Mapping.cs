using AutoMapper;
using OrderOut.EF.Models;

namespace OrderOut.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, Product>().ReverseMap();
        }

    }
}