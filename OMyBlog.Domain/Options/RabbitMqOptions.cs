namespace OMyBlog.Domain.Options;

public class RabbitMqOptions
{
    public string HostName { get; set; }
    public int Port { get; set; }
    public Authentication Authentication { get; set; }
    public List<ExchangeInfo> Exchanges { get; set; }
}

public record Authentication
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public record ExchangeInfo
{
    public string Name { get; set; }
    public List<QueueInfo> Queues { get; set; }
}

public record QueueInfo
{
    public string Name { get; set; }
    public string RoutingKey { get; set; }
}