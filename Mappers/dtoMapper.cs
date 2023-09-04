using AutoMapper;
using EcommerceApp.Dtos;
using EcommerceApp.models;

namespace EcommerceApp.Mappers
{
    public class dtoMapper : Profile
    {
        public dtoMapper()
        {
            CreateMap<Order, orderDto>().ReverseMap();
            CreateMap<Products, productDto>().ReverseMap();
            CreateMap<User, userDto>().ReverseMap();
            CreateMap<OrderStatus, statusDto>().ReverseMap();
            CreateMap<Seller, sellerDto>().ReverseMap();
        }
    }
}
