using ConfigurationBuilder = OMyBlog.Core.Builders.ConfigurationBuilder;

namespace OMyBlog.Api;

public static class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Start work");
            await CreateHostBuilder(args).Build().RunAsync();
        }
        catch (Exception e)
        {
            await Console.Error.WriteLineAsync("Stopped program because of exception\r\n" +
                                               $"Data: {e.Data}\r\n" +
                                               $"Message: {e.Message}\r\n" +
                                               $"Trace:\r\n{e.StackTrace}"
            );
        }

    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, _) =>
            {
                ConfigurationBuilder.Build();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Debug);
            });
}