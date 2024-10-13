using System.ComponentModel.DataAnnotations;

namespace ali.controller.dto;

public class PostRequest
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    public string Text { get; set; }
    
}