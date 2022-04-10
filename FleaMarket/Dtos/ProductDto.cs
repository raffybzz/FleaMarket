namespace FleaMarket.Dtos;

public class ProductDto : ProductCreateDto
{
    public string Id { get; set; }
    public UserDto Seller { get; set; }
}