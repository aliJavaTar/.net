using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ali.models;

[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }

    public string Email { get; set; }
}