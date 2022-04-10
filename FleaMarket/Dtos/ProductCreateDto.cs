using System.ComponentModel.DataAnnotations;

namespace FleaMarket.Dtos;

public class ProductCreateDto
{
    [Required] public string Name { get; set; }
    public decimal? Price { get; set; }
}