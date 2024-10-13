using System.ComponentModel.DataAnnotations;

namespace ali.models;

public class User
{
    public int Id { get; set; }

    [Required] [MaxLength(50)] public string Username { get; set; }

    [Required] [MaxLength(100)] public string Password { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }
    public ICollection<Post> Posts { get; set; }

}