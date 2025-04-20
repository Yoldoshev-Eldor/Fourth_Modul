using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Xisobot_Bot.DataAccess.Entities;
using Xisobot_Bot.Service.Services;

namespace Xisobot_Bot;

public class BotListener
{
    private static string botToken = "7392524354:AAFs-cPpH7AkPZZvrpwYLjKlyuA0HShxbWk";
    private TelegramBotClient botClient = new TelegramBotClient(botToken);
    private readonly IBotService _botService;
    private readonly ITransactionService _transactionService;
    public BotListener(IBotService botService, ITransactionService transactionService)
    {
        _botService = botService;
        _transactionService = transactionService;
    }

    public async Task StartBot()
    {
        botClient.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync
            );

        Console.WriteLine("Bot is runing");

        Console.ReadKey();
    }


    private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cancellationToken)
    {


        if (update.Type == UpdateType.Message)
        {
            var user = update.Message.Chat;
            var message = update.Message;
            var botUserId = await _botService.GetBotUserByTelegramUserIdAsync(user.Id);


            if (message.Text == "/start")
            {
                var savingUser = new BotUser()
                {
                    TelegramUserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    PhoneNumber = "", // Telefon raqamini keyin olish mumkin
                    CreatedAt = DateTime.UtcNow

                };

                await _botService.AddUserAsync(savingUser);

                await SendStartMenu(bot, user.Id);
                return;
            }

            if (message.Text == "Mening Ma'lumotlarim")
            {

                await botClient.SendTextMessageAsync(chatId: user.Id, text: $"Telegram Id : {user.Id}\n UserName : {user.Username}\n FirstName : {user.FirstName}");

                return;
            }

            if (message.Text == "Moliya Bo'limiga O'tish")
            {
                var menu = new ReplyKeyboardMarkup(new[]
            {

             new[]
            {
                new KeyboardButton("Ma'lumot qo'shish"),
                new KeyboardButton("Ma'lumotlarni CVS qilib olish")

            },
            new[]
            {
                new KeyboardButton("Bosh menyuga qaytish")


            }

                })
                {
                    ResizeKeyboard = true
                };
                await bot.SendTextMessageAsync(user.Id, $"{user.FirstName}Siz botga start bosdingiz Endi Foydalanishingiz mumkin ! ! ! ", replyMarkup: menu);

            }


            if (message.Text == "Bosh menyuga qaytish")
            {

                await SendStartMenu(bot, user.Id);
                return;
            }

            if (message.Text == "Ma'lumot qo'shish")
            {
                await botClient.SendTextMessageAsync(
           chatId: message.Chat.Id,
           text: "Iltimos, quyidagi formatda ma'lumot kiriting:\n\n" +
                 "<b>Summasi</b> | <b>Turi</b> | <b>Izoh</b>\n" +
                 "Masalan: 10000 | Xarajat | Oziq-ovqat",
           parseMode: ParseMode.Html
       );
            }
            else if (message.Text.Contains("|"))
            {
                var parts = message.Text.Split('|', StringSplitOptions.TrimEntries);
                if (parts.Length == 3 && decimal.TryParse(parts[0], out decimal amount))
                {
                    string type = parts[1];
                    string description = parts[2];

                    await _transactionService.AddTransactionAsync(user.Id, amount, type, description);

                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "✅ Ma'lumot muvaffaqiyatli qo'shildi!"
                    );
                }
                else
                {
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "⚠️ Xatolik! Ma'lumotni to'g'ri formatda kiriting."
                    );
                }
            }



            if (message.Text == "Ma'lumotlarni CSV qilib olish")
            {
                var csvData = await _transactionService.GetTransactionsAsCsvAsync(message.Chat.Id);

                if (string.IsNullOrEmpty(csvData))
                {
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "⚠️ Sizda hali hech qanday tranzaksiya mavjud emas."
                    );
                }
                else
                {
                    string filePath = Path.Combine(Path.GetTempPath(), $"transactions_{message.Chat.Id}.csv");
                    await File.WriteAllTextAsync(filePath, csvData);

                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        await botClient.SendDocumentAsync(
                            chatId: message.Chat.Id,
                            document: new InputFileStream(stream, $"transactions_{message.Chat.Id}.csv"),
                            caption: "📄 Sizning tranzaksiya ma'lumotlaringiz."
                        );
                    }

                    File.Delete(filePath); // Faylni vaqtinchalik papkadan o‘chirish
                }
            }


        }





    }










    private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        // Xatoni to'liq chiqarish
        Console.WriteLine("[ERROR] Xatolik yuz berdi:");
        Console.WriteLine(exception.ToString()); // Stack trace va ichki xatoliklarni chiqaradi

        // Agar inner exception bo'lsa, qo'shimcha ma'lumot chiqaramiz
        if (exception.InnerException != null)
        {
            Console.WriteLine("[INNER ERROR] " + exception.InnerException.Message);
        }

        // Admin ID sini kiritib, xatolarni Telegram orqali yuborish (admin uchun)
        long adminId = 123456789; // O'zingizning Telegram ID-ingizni qo'ying
        string errorMessage = $"❌ Botda xatolik yuz berdi:\n\n{exception.Message}";

        try
        {
            await botClient.SendTextMessageAsync(adminId, errorMessage, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] Adminga xatolikni yuborib bo‘lmadi: " + ex.Message);
        }
    }

    private static async Task SendStartMenu(ITelegramBotClient botClient, long userId)
    {
        var menu = new ReplyKeyboardMarkup(new[]
        {
            new[]
            {
                new KeyboardButton("Mening Ma'lumotlarim"),
                new KeyboardButton("Moliya Bo'limiga O'tish"),

            }

        })
        {
            ResizeKeyboard = true
        };



        var introText = @"
            🌟 *Welcome to the CV Builder Bot!* 🌟

            I'm here to help you create a **professional CV in PDF format** effortlessly. Here's how it works:

            1. **Provide Your Information**: Fill in your personal details, work experience, education, and skills.
            2. **Review and Confirm**: You can review and edit your information at any time.
            3. **Generate Your CV**: Once everything is ready, I'll create a polished PDF version of your CV for you to download.

            📝 *What you'll need to provide:*
            - **User Info**: Name, contact details, etc.
            - **Education**: Your academic background and qualifications.
            - **Experience**: Your past jobs, roles, and achievements.
            - **Skills**: Your key skills and expertise.

            🚀 *Ready to get started?*
            Use the buttons below to fill in your details or generate your CV!

            Need help? Just type /help at any time.

            Let's create an amazing CV together! 😊
            ";

        await botClient.SendTextMessageAsync(
            chatId: userId,
            text: introText,
            parseMode: ParseMode.Markdown,
            replyMarkup: menu
        );
    }


}
