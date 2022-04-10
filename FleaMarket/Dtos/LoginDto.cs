using System.ComponentModel.DataAnnotations;

namespace FleaMarket.Dtos;

public class LoginDto
{
    [Required] public string Username { get; init; }
    [Required] public string Password { get; init; }
}