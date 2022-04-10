using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Core.Models;

public class Product : Entity
{
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public IdentityUser Saller { get; set; }
}