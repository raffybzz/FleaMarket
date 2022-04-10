using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FleaMarket.Data.Models;

public class DbProduct : DbEntity
{
    [Required] public string Name { get; set; }

    public decimal? Price { get; set; }

    public string SallerId { get; set; }
    [Required] public IdentityUser Saller { get; set; }
}