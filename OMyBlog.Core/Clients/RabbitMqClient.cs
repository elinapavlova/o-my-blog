using System.Text;
using OMyBlog.Domain.Contracts.Clients;
using OMyBlog.Domain.Dtos;
using OMyBlog.Domain.Options;
using RabbitMQ.Client;

namespace OMyBlog.Core.Clients;

public class RabbitMqClient : IRabbitMqClient
{
    private readonly RabbitMqOptions _options;

    public RabbitMqClient(RabbitMqOptions options)
    {
        _options = options;
    }

    public void SendMessage(MessageInfo message)
    {
        using var model = CreateModel();

        model.ExchangeDeclare(message.Exchange, ExchangeType.Direct);
        model.QueueDeclare(message.Queue, durable: true, exclusive: false, autoDelete: false);
        model.QueueBind(message.Queue, message.Exchange, message.Queue);
        model.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

        var body = Encoding.UTF8.GetBytes(message.Text);

        model.BasicPublish(message.Exchange, message.Queue, basicProperties: null, body);
        //_logger.Information($"Отправлено сообщение {message}\r\nExchange: {ExchangeName}, Queue: {message.Queue}");
    }

    public IModel CreateModel()
    {
        var factory = new ConnectionFactory
        {
            AutomaticRecoveryEnabled = true,
            DispatchConsumersAsync = true,
            TopologyRecoveryEnabled = true,
            HostName = _options.HostName,
        };

        var connection = factory.CreateConnection();
        return connection.CreateModel();
    }
}