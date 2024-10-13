using System.ComponentModel.DataAnnotations;

namespace ali.controller.dto;

public class UserRequest
{
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [MaxLength(100)]
    public string Password { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}