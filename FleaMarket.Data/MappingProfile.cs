using AutoMapper;
using FleaMarket.Core.Models;
using FleaMarket.Data.Models;

namespace FleaMarket.Data;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DbProduct, Product>();
        CreateMap<Product, DbProduct>()
            .ForMember(x => x.SallerId, opt => opt.MapFrom(x => x.Saller.Id));
        CreateMap<DbTrade, Trade>();
        CreateMap<Trade, DbTrade>()
            .ForMember(x => x.CustomerId, opt => opt.MapFrom(x => x.Customer.Id))
            .ForMember(x => x.ProductId, opt => opt.MapFrom(x => x.Product.Id));
    }
}