namespace ali.controller.dto;

public class PostResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Username { get; set; }
}