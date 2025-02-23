using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Valyuta_bot.DataAccess.Entities;
using Valyuta_bot.Service.Services;

namespace Valyuta_bot;

public class BotListenerService
{
    private static string botToken = "7012681936:AAF1KxsuhIeQ4MyKQywkphXUcH683gZWPAY";
    private TelegramBotClient botClient = new TelegramBotClient(botToken);
    private readonly IBotService userService;

    public BotListenerService(IBotService userService)
    {
        this.userService = userService;
    }

    public async Task StartBot()
    {
       
    }

   
}
