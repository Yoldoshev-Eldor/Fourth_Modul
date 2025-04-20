using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xisobot_Bot.DataAccess;
using Xisobot_Bot.Service.Services;

namespace Xisobot_Bot;

public class Program
{
    static void Main(string[] args)
    {
        var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));

        var configuration = new ConfigurationBuilder()
            .SetBasePath(projectDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<IBotService, BotService>();
        serviceCollection.AddScoped<ITransactionService, TransactionService>();
        serviceCollection.AddSingleton<BotListener>();
        serviceCollection.AddSingleton<MainContext>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var botListenerService = serviceProvider.GetRequiredService<BotListener>();
        botListenerService.StartBot();

        Console.ReadKey();
    }
}
