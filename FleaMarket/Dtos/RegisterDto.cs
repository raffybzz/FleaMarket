using System.ComponentModel.DataAnnotations;

namespace FleaMarket.Dtos
{
    public record RegisterDto : UserDto
    {
        [Required] public string Password { get; init; }
    }
}