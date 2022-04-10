using System.ComponentModel.DataAnnotations;

namespace FleaMarket.Dtos;

public record UserDto
{
    [Required] public string UserName { get; init; }
    [Required] public string Email { get; init; }
}