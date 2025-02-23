using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_bot;

public class Program
{
    private static string BotToken = "7012681936:AAF1KxsuhIeQ4MyKQywkphXUcH683gZWPAY";
    private static TelegramBotClient BotClient = new TelegramBotClient(BotToken);
    private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "UserIDs.json");
    private static HashSet<long> Ids = new HashSet<long>();
    static async Task Main(string[] args)
    {
        var receiverOptions = new ReceiverOptions { AllowedUpdates = new[] { UpdateType.Message, UpdateType.InlineQuery } };

        BotClient.StartReceiving(
        HandleUpdateAsync,
        HandleErrorAsync
        );

        Console.ReadKey();

    }
    static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {
        Ids = await GetAllIDs();
        var message = update.Message;
        var user = message.Chat;
        Console.WriteLine($"{user.Id} , {user.LastName}, {user.FirstName} , {message.Text}");

        if (message.Text == "/start")
        {
            Ids.Add(user.Id);
            await SaveId();
            await bot.SendTextMessageAsync(user.Id, "salomaleykum hizmat", cancellationToken: cancellationToken);
            return;


        }
        if (message.Text.ToLower().Contains("salom"))
        {
            await bot.SendTextMessageAsync(user.Id, "Qalesan", cancellationToken: cancellationToken);
            return;
        }



    }


    static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {

    }


    public static async Task SaveId()
    {


        var json = JsonSerializer.Serialize(Ids);
        await File.WriteAllTextAsync(FilePath, json);
    }

    public static async Task<HashSet<long>> GetAllIDs()
    {
        var idsString = File.ReadAllText(FilePath);
        var ids = JsonSerializer.Deserialize<HashSet<long>>(idsString);
        return ids ?? new HashSet<long>();
    }

}
