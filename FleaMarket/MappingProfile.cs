using AutoMapper;
using FleaMarket.Core.Models;
using FleaMarket.Dtos;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDto, IdentityUser>();
        CreateMap<IdentityUser, UserDto>();
        CreateMap<Product, ProductDto>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Trade, TradeDto>();
    }
}