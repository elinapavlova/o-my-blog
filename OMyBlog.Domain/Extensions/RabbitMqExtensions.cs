using System.Text;

namespace OMyBlog.Domain.Extensions;

public static class RabbitMqExtensions
{
    public static string BytesToString(this ReadOnlyMemory<byte> body)
    {
        var message = Encoding.UTF8.GetString(body.ToArray());
        return message;
    }
}