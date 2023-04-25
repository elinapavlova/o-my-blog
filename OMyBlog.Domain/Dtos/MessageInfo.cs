namespace OMyBlog.Domain.Dtos;

public record MessageInfo(string Text, string Queue, string Exchange)
{
    public string Text { get; set; } = Text;
    public string Queue { get; set; } = Queue;
    public string Exchange { get; set; } = Exchange;
}