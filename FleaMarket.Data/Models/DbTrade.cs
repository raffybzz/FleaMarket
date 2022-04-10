using System.ComponentModel.DataAnnotations;
using FleaMarket.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Data.Models;

public class DbTrade : DbEntity
{
    public string CustomerId { get; set; }

    [Required] public IdentityUser Customer { get; set; }

    public string ProductId { get; set; }
    [Required] public DbProduct Product { get; set; }

    [Required]  public TradeStatus Status { get; set; }
}