using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Core.Models;

public class Trade : Entity
{
    public IdentityUser Customer { get; set; }
    public IdentityUser Seller => Product.Saller;
    public Product Product { get; set; }
    public TradeStatus Status { get; set; }
}