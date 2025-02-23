


using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace tgBot
{
    public class Program
    {
        private static string BotToken = "7012681936:AAF1KxsuhIeQ4MyKQywkphXUcH683gZWPAY";
        private static TelegramBotClient BotClient = new TelegramBotClient(BotToken);

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
            var message = update.Message;
            var user = message.Chat;

            if (message.Text == "/start")
            {
                await bot.SendTextMessageAsync(user.Id, "salomaleykum hizmat", cancellationToken: cancellationToken);
                return;
            }

        }


        static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
