using OMyBlog.Domain.Dtos;
using RabbitMQ.Client;

namespace OMyBlog.Domain.Contracts.Clients;

public interface IRabbitMqClient
{
    void SendMessage(MessageInfo message);
    IModel CreateModel();
}