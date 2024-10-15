using System.ComponentModel.DataAnnotations.Schema;

namespace ali.models;

[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }

    public string Email { get; set; }
 
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    
    public string Role { get; set; }
    
}