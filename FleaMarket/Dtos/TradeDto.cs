using FleaMarket.Core.Models;

namespace FleaMarket.Dtos;

public class TradeDto
{
    public string Id { get; set; }
    public ProductDto Product { get; set; }
    public UserDto Customer { get; set; }
    public TradeStatus Status { get; set; }
}