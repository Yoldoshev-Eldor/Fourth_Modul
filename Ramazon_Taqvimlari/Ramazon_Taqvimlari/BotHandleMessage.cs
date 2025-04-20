using DataAccess.Entities;
using Services.Service;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Ramazon_Taqvimlari;

public class BotHandleMessage
{

    private static string botToken = "7583887593:AAH3h_I70O2dp7bYc3aPR73tTbbAqTZjeWI";
    private TelegramBotClient botClient = new TelegramBotClient(botToken);
    private readonly ITaqvimBotService userService;

    public BotHandleMessage(ITaqvimBotService userService)
    {
        this.userService = userService;
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


            if (message.Text == "/start")
            {
                var savingUser = new BotUser()
                {
                    TelegramUserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    UpdatedAt = DateTime.UtcNow,
                };

                await userService.AddUserAsync(savingUser);


                //await bot.SendTextMessageAsync(user.Id, "You are successfully started");

                var menu = new ReplyKeyboardMarkup(new[]
                {
                    new[]
                    {
                        new KeyboardButton("Saharlik duosi"),
                        new KeyboardButton("Iftorlik duosi")
                    },
                    new[]
                    {
                        new KeyboardButton("Ramazon taqvimi"),

                    }
                })
                {
                    ResizeKeyboard = true,
                    OneTimeKeyboard = true
                };


                await bot.SendTextMessageAsync(user.Id, $"{user.FirstName}Siz botga start bosdingiz Endi Foydalanishingiz mumkin ! ! ! ", replyMarkup: menu);

                return;
            }

            if (message.Text == "Saharlik duosi")
            {

                await bot.SendTextMessageAsync(user.Id, "🌙 Saxarlik duosi:\r\n\r\n" +
                    " نَوَيْتُ أَنْ أَصُومَ صَوْمَ شَهْرِ رَمَضَانَ مِنَ الْفَجْرِ إِلَى الْمَغْرِبِ، خَالِصًا لِلَّهِ تَعَالَى. اللَّهُ أَكْبَرُ.ُ.ُ\r\n\r\n" +
                    "Tarjimasi ->  Navaytu an asuma sovma shahri Ramazona minal fajri ilal mag‘ribi, xolisan lillahi ta’alaa. Allohu akbar.\r\n\r\n" +
                    "Ma'nosi: Allohim, men Sening roziliging uchun ro‘za tutdim, Senga iymon keltirdim, Senga tavakkul qildim va Sen ato etgan rizq bilan saxarlik qildim.\r\n  ");
            }

            if (message.Text == "Iftorlik duosi")
            {

                await bot.SendTextMessageAsync(user.Id, "🌅 Iftorlik duosi:\r\n\r\nاللَّهُمَّ لَكَ صُمْتُ وَبِكَ آمَنْتُ وَعَلَيْكَ تَوَكَّلْتُ وَعَلَى رِزْقِكَ أَفْطَرْتُ، فَاغْفِرْ لِي ذُنُوبِي يَا غَفَّارُ مَا قَدَّمْتُ وَمَا أَخَّرْتُ.\r\n\r\n" +
                    "Tarjimasi ->  Allohumma laka sumtu va bika aamantu va ’alayka tavakkaltu va ’alaa rizqika aftortu, fag‘firliy zunubiy yaa G‘offaru maa qoddamtu va maa axxortu. \r\n\r\n" +
                    "Ma'nosi: Allohim, men Sening roziliging uchun ro‘za tutdim, Senga iymon keltirdim, Senga tavakkul qildim va Sen ato etgan rizq bilan iftorlik qildim. Mening oldingi va keyingi gunohlarimni kechir. ");
            }


            if (message.Text == "Ramazon taqvimi")
            {
                var inlineMenu = new InlineKeyboardMarkup(new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Toshkent","Toshkent"),
                        InlineKeyboardButton.WithCallbackData("Andijon " , "Andijon")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Buxoro","Buxoro"),
                        InlineKeyboardButton.WithCallbackData("Farg'ona","Farg'ona"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Jizzax", "Jizzax"),
                        InlineKeyboardButton.WithCallbackData("Xorazm", "Xorazm"),

                    },
                      new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Namangan", "Namangan"),
                        InlineKeyboardButton.WithCallbackData("Navoiy", "Navoiy"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Qashqadaryo", "Qashqadaryo"),
                        InlineKeyboardButton.WithCallbackData("Surxondaryo", "Surxondaryo"),

                    },
                       new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Samarqand", "Samarqand"),
                        InlineKeyboardButton.WithCallbackData("Sirdaryo", "Sirdaryo"),

                    }


                });



                await bot.SendTextMessageAsync(user.Id, "Ozingizga kerakli viloyatni tanlang :", replyMarkup: inlineMenu);



            }








        }


        else if (update.Type == UpdateType.CallbackQuery)
        {

            Console.WriteLine("Callback ga kirdi");
            Console.WriteLine(update.CallbackQuery.Data);

            string callbackData = update.CallbackQuery.Data;
            long userId = update.CallbackQuery.From.Id;



            if (callbackData == "Toshkent" || callbackData == "Andijon"
                || callbackData == "Buxoro" || callbackData == "Farg'ona"
                || callbackData == "Jizzax" || callbackData == "Xorazm"
                || callbackData == "Namangan" || callbackData == "Navoiy"
                || callbackData == "Qashqadaryo" || callbackData == "Surxondaryo"
                || callbackData == "Samarqand" || callbackData == "Sirdaryo")
            {
                int messageId = update.CallbackQuery.Message.MessageId; // Eski xabar ID sini olish

                // Eski xabarni o‘chirish
                await botClient.DeleteMessageAsync(chatId: update.CallbackQuery.From.Id, messageId: messageId);

                var viloyat = callbackData;


                var dataMenu = new InlineKeyboardMarkup(new[]
           {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("1-mart", $"{viloyat}:1"),
                InlineKeyboardButton.WithCallbackData("2-mart", $"{viloyat}:2"),
                InlineKeyboardButton.WithCallbackData("3-mart", $"{viloyat}:3"),
                InlineKeyboardButton.WithCallbackData("4-mart", $"{viloyat}:4"),
                InlineKeyboardButton.WithCallbackData("5-mart", $"{viloyat}:5"),
                InlineKeyboardButton.WithCallbackData("6-mart", $"{viloyat}:6")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("7-mart", $"{viloyat}:7"),
                InlineKeyboardButton.WithCallbackData("8-mart", $"{viloyat}:8"),
                InlineKeyboardButton.WithCallbackData("9-mart", $"{viloyat}:9"),
                InlineKeyboardButton.WithCallbackData("10-mart", $"{viloyat}:10"),
                InlineKeyboardButton.WithCallbackData("11-mart", $"{viloyat}:11"),
                InlineKeyboardButton.WithCallbackData("12-mart", $"{viloyat}:12")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("13-mart", $"{viloyat}:13"),
                InlineKeyboardButton.WithCallbackData("14-mart", $"{viloyat}:14"),
                InlineKeyboardButton.WithCallbackData("15-mart", $"{viloyat}:15"),
                InlineKeyboardButton.WithCallbackData("16-mart", $"{viloyat}:16"),
                InlineKeyboardButton.WithCallbackData("17-mart", $"{viloyat}:17"),
                InlineKeyboardButton.WithCallbackData("18-mart", $"{viloyat}:18")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("19-mart", $"{viloyat}:19"),
                InlineKeyboardButton.WithCallbackData("20-mart", $"{viloyat}:20"),
                InlineKeyboardButton.WithCallbackData("21-mart", $"{viloyat}:21"),
                InlineKeyboardButton.WithCallbackData("22-mart", $"{viloyat}:22"),
                InlineKeyboardButton.WithCallbackData("23-mart", $"{viloyat}:23"),
                InlineKeyboardButton.WithCallbackData("24-mart", $"{viloyat}:24")
            },
            new[]
            {
                InlineKeyboardButton.WithCallbackData("25-mart", $"{viloyat}:25"),
                InlineKeyboardButton.WithCallbackData("26-mart", $"{viloyat}:26"),
                InlineKeyboardButton.WithCallbackData("27-mart", $"{viloyat}:27"),
                InlineKeyboardButton.WithCallbackData("28-mart", $"{viloyat}:28"),
                InlineKeyboardButton.WithCallbackData("29-mart", $"{viloyat}:29"),
                InlineKeyboardButton.WithCallbackData("30-mart", $"{viloyat}:30")
            },
             new[]
                    {
                        InlineKeyboardButton.WithCallbackData("ortga ↩️", "ortga"),

                    }
        });

                await botClient.SendTextMessageAsync(
                    chatId: userId,
                    text: "O'zingizga kerakli kunni tanlang:",
                    replyMarkup: dataMenu
                );


            }

            if (update.CallbackQuery.Data == "ortga")
            {

                int messageId = update.CallbackQuery.Message.MessageId; // Eski xabar ID sini olish

                // Eski xabarni o‘chirish
                await botClient.DeleteMessageAsync(chatId: update.CallbackQuery.From.Id, messageId: messageId);


                var inlineMenu = new InlineKeyboardMarkup(new[]
                {
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Toshkent","Toshkent"),
                        InlineKeyboardButton.WithCallbackData("Andijon " , "Andijon")
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Buxoro","Buxoro"),
                        InlineKeyboardButton.WithCallbackData("Farg'ona","Farg'ona"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Jizzax", "Jizzax"),
                        InlineKeyboardButton.WithCallbackData("Xorazm", "Xorazm"),

                    },
                      new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Namangan", "Namangan"),
                        InlineKeyboardButton.WithCallbackData("Navoiy", "Navoiy"),
                    },
                    new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Qashqadaryo", "Qashqadaryo"),
                        InlineKeyboardButton.WithCallbackData("Surxondaryo", "Surxondaryo"),

                    },
                       new[]
                    {
                        InlineKeyboardButton.WithCallbackData("Samarqand", "Samarqand"),
                        InlineKeyboardButton.WithCallbackData("Sirdaryo", "Sirdaryo"),

                    }


                });



                await bot.SendTextMessageAsync(userId, "Choose an option:", replyMarkup: inlineMenu);
            }











            else if (update.CallbackQuery.Data == "Toshkent:1")
            {

                await bot.SendTextMessageAsync(userId, " 🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:40  \r\nToshkent shahrida Iftorlik   🌙     18:15    ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:2")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:38  \r\nToshkent shahrida Iftorlik   🌙     18:17    ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:3")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:37  \r\nToshkent shahrida Iftorlik   🌙     18:18    ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:4")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:35  \r\nToshkent shahrida Iftorlik   🌙     18:19   ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:5")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:33  \r\nToshkent shahrida Iftorlik   🌙     18:20  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:6")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:32  \r\nToshkent shahrida Iftorlik   🌙     18:21  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:7")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:30  \r\nToshkent shahrida Iftorlik   🌙     18:22  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:8")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:29  \r\nToshkent shahrida Iftorlik   🌙     18:24  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:9")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:27  \r\nToshkent shahrida Iftorlik   🌙     18:25  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:10")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:25  \r\nToshkent shahrida Iftorlik   🌙     18:26  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:11")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:24  \r\nToshkent shahrida Iftorlik   🌙     18:27  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:12")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:22  \r\nToshkent shahrida Iftorlik   🌙     18:28  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:13")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:20  \r\nToshkent shahrida Iftorlik   🌙     18:29  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:14")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:18  \r\nToshkent shahrida Iftorlik   🌙     18:30  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:15")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:17  \r\nToshkent shahrida Iftorlik   🌙     18:31  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:16")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:13  \r\nToshkent shahrida Iftorlik   🌙     18:32  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:17")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:11  \r\nToshkent shahrida Iftorlik   🌙     18:34  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:18")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:10  \r\nToshkent shahrida Iftorlik   🌙     18:35  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:19")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:08  \r\nToshkent shahrida Iftorlik   🌙     18:36  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:20")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:06  \r\nToshkent shahrida Iftorlik   🌙     18:37  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:21")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:04  \r\nToshkent shahrida Iftorlik   🌙     18:38  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:22")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:02  \r\nToshkent shahrida Iftorlik   🌙     18:39  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:23")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     05:01  \r\nToshkent shahrida Iftorlik   🌙     18:40  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:24")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     04:59  \r\nToshkent shahrida Iftorlik   🌙     18:41  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:25")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     04:57  \r\nToshkent shahrida Iftorlik   🌙     18:42  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:26")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     04:55  \r\nToshkent shahrida Iftorlik   🌙     18:43  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:27")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     04:53  \r\nToshkent shahrida Iftorlik   🌙     18:44  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:28")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     04:53  \r\nToshkent shahrida Iftorlik   🌙     18:46  ");
            }

            else if (update.CallbackQuery.Data == "Toshkent:29")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     04:52  \r\nToshkent shahrida Iftorlik   🌙     18:47  ");


            }
            else if (update.CallbackQuery.Data == "Toshkent:30")
            {
                await bot.SendTextMessageAsync(userId, " 🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nToshkent shahrida Saxarlik ☀️     04:50  \r\nToshkent shahrida Iftorlik   🌙     18:48  ");
            }








            else if (update.CallbackQuery.Data == "Andijon:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:28  \r\nAndijon viloyatida  Iftorlik   🌙     18:03");
            }
            else if (update.CallbackQuery.Data == "Andijon:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:26  \r\nAndijon viloyatida  Iftorlik   🌙     18:05");
            }
            else if (update.CallbackQuery.Data == "Andijon:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:25  \r\nAndijon viloyatida  Iftorlik   🌙     18:06");
            }
            else if (update.CallbackQuery.Data == "Andijon:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:23  \r\nAndijon viloyatida  Iftorlik   🌙     18:07");
            }
            else if (update.CallbackQuery.Data == "Andijon:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:21  \r\nAndijon viloyatida  Iftorlik   🌙     18:08");
            }
            else if (update.CallbackQuery.Data == "Andijon:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:20  \r\nAndijon viloyatida  Iftorlik   🌙     18:09");
            }
            else if (update.CallbackQuery.Data == "Andijon:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:18  \r\nAndijon viloyatida  Iftorlik   🌙     18:10");
            }
            else if (update.CallbackQuery.Data == "Andijon:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:17  \r\nAndijon viloyatida  Iftorlik   🌙     18:12");
            }
            else if (update.CallbackQuery.Data == "Andijon:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:15  \r\nAndijon viloyatida  Iftorlik   🌙     18:13");
            }
            else if (update.CallbackQuery.Data == "Andijon:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:13  \r\nAndijon viloyatida  Iftorlik   🌙     18:14");
            }
            else if (update.CallbackQuery.Data == "Andijon:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:12  \r\nAndijon viloyatida  Iftorlik   🌙     18:15");
            }
            else if (update.CallbackQuery.Data == "Andijon:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:10  \r\nAndijon viloyatida  Iftorlik   🌙     18:16");
            }
            else if (update.CallbackQuery.Data == "Andijon:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:08  \r\nAndijon viloyatida  Iftorlik   🌙     18:17");
            }
            else if (update.CallbackQuery.Data == "Andijon:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:06  \r\nAndijon viloyatida  Iftorlik   🌙     18:18");
            }
            else if (update.CallbackQuery.Data == "Andijon:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:05  \r\nAndijon viloyatida  Iftorlik   🌙     18:19");
            }
            else if (update.CallbackQuery.Data == "Andijon:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:03  \r\nAndijon viloyatida  Iftorlik   🌙     18:20");
            }
            else if (update.CallbackQuery.Data == "Andijon:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      05:01  \r\nAndijon viloyatida  Iftorlik   🌙     18:22");
            }
            else if (update.CallbackQuery.Data == "Andijon:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:59  \r\nAndijon viloyatida  Iftorlik   🌙     18:23");
            }
            else if (update.CallbackQuery.Data == "Andijon:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:58  \r\nAndijon viloyatida  Iftorlik   🌙     18:24");
            }
            else if (update.CallbackQuery.Data == "Andijon:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:57  \r\nAndijon viloyatida  Iftorlik   🌙     18:25");
            }
            else if (update.CallbackQuery.Data == "Andijon:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:55  \r\nAndijon viloyatida  Iftorlik   🌙     18:26");
            }
            else if (update.CallbackQuery.Data == "Andijon:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:53  \r\nAndijon viloyatida  Iftorlik   🌙     18:27");
            }
            else if (update.CallbackQuery.Data == "Andijon:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:51  \r\nAndijon viloyatida  Iftorlik   🌙     18:28");
            }
            else if (update.CallbackQuery.Data == "Andijon:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:50  \r\nAndijon viloyatida  Iftorlik   🌙     18:29");
            }
            else if (update.CallbackQuery.Data == "Andijon:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:48  \r\nAndijon viloyatida  Iftorlik   🌙     18:30");
            }
            else if (update.CallbackQuery.Data == "Andijon:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:46  \r\nAndijon viloyatida  Iftorlik   🌙     18:31");
            }
            else if (update.CallbackQuery.Data == "Andijon:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:44  \r\nAndijon viloyatida  Iftorlik   🌙     18:32");
            }
            else if (update.CallbackQuery.Data == "Andijon:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:42  \r\nAndijon viloyatida  Iftorlik   🌙     18:34");
            }
            else if (update.CallbackQuery.Data == "Andijon:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:41  \r\nAndijon viloyatida  Iftorlik   🌙     18:35");
            }
            else if (update.CallbackQuery.Data == "Andijon:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nAndijon viloyatida Saxarlik ☀️      04:39  \r\nAndijon viloyatida  Iftorlik   🌙     18:35");
            }




            else if (update.CallbackQuery.Data == "Buxoro:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:59  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:35");
            }
            else if (update.CallbackQuery.Data == "Buxoro:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:57  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:37");
            }
            else if (update.CallbackQuery.Data == "Buxoro:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:56  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:38");
            }
            else if (update.CallbackQuery.Data == "Buxoro:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:54  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:39");
            }
            else if (update.CallbackQuery.Data == "Buxoro:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:52  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:40");
            }
            else if (update.CallbackQuery.Data == "Buxoro:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:51  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:41");
            }
            else if (update.CallbackQuery.Data == "Buxoro:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:49  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:42");
            }
            else if (update.CallbackQuery.Data == "Buxoro:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:48  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:44");
            }
            else if (update.CallbackQuery.Data == "Buxoro:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:46  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:45");
            }
            else if (update.CallbackQuery.Data == "Buxoro:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:45  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:46");
            }
            else if (update.CallbackQuery.Data == "Buxoro:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:44  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:47");
            }
            else if (update.CallbackQuery.Data == "Buxoro:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:42  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:48");
            }

            else if (update.CallbackQuery.Data == "Buxoro:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:40  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:49");
            }
            else if (update.CallbackQuery.Data == "Buxoro:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:38  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:50");
            }
            else if (update.CallbackQuery.Data == "Buxoro:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:37  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:51");
            }
            else if (update.CallbackQuery.Data == "Buxoro:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:35  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:52");
            }
            else if (update.CallbackQuery.Data == "Buxoro:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:37  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:54");
            }
            else if (update.CallbackQuery.Data == "Buxoro:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:35  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:55");
            }
            else if (update.CallbackQuery.Data == "Buxoro:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:33  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:56");
            }
            else if (update.CallbackQuery.Data == "Buxoro:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:31  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:56");
            }
            else if (update.CallbackQuery.Data == "Buxoro:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:30  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:55");
            }
            else if (update.CallbackQuery.Data == "Buxoro:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:30  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:57");
            }
            else if (update.CallbackQuery.Data == "Buxoro:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:28  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:58");
            }
            else if (update.CallbackQuery.Data == "Buxoro:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:26  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      18:59");
            }
            else if (update.CallbackQuery.Data == "Buxoro:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:24  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      19:00");
            }
            else if (update.CallbackQuery.Data == "Buxoro:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:23  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      19:01");
            }
            else if (update.CallbackQuery.Data == "Buxoro:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:21  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      19:02");
            }
            else if (update.CallbackQuery.Data == "Buxoro:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:19  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙      19:03");
            }
            else if (update.CallbackQuery.Data == "Buxoro:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nBuxoro viloyatida Saxarlik ☀️      05:17  \r\n\r\nBuxoro viloyatida  Iftorlik   🌙     19:05");
            }






            else if (update.CallbackQuery.Data == "Farg'ona:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:30  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:05");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:28  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:07");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:27  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:08");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:25  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:09");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:23  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:10");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:22  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:11");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:20  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:12");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:19  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:14");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:17  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:15");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:16  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:16");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:15  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:17");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:13  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:18");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:11  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:19");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:09  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:20");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:08  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:21");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:06  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:22");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:04  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:24");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:02  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:25");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:01  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:26");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      05:00  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:27");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:58  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:28");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:56  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:29");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:54  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:30");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:53  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:31");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:51  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:32");
            }

            else if (update.CallbackQuery.Data == "Farg'ona:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:49  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:33");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:47  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:34");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:45  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:36");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:44  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:37");
            }
            else if (update.CallbackQuery.Data == "Farg'ona:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nFarg'ona viloyatida Saxarlik ☀️      04:42  \r\n\r\nFarg'ona viloyatida  Iftorlik   🌙     18:37");
            }






            else if (update.CallbackQuery.Data == "Jizzax:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:46  \r\nJizzax viloyatida  Iftorlik   🌙      18:22");
            }
            else if (update.CallbackQuery.Data == "Jizzax:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:44  \r\nJizzax viloyatida  Iftorlik   🌙      18:24");
            }
            else if (update.CallbackQuery.Data == "Jizzax:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:43  \r\nJizzax viloyatida  Iftorlik   🌙      18:25");
            }
            else if (update.CallbackQuery.Data == "Jizzax:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:41  \r\nJizzax viloyatida  Iftorlik   🌙      18:26");
            }
            else if (update.CallbackQuery.Data == "Jizzax:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:39  \r\nJizzax viloyatida  Iftorlik   🌙      18:27");
            }
            else if (update.CallbackQuery.Data == "Jizzax:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:38  \r\nJizzax viloyatida  Iftorlik   🌙      18:28");
            }
            else if (update.CallbackQuery.Data == "Jizzax:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:36  \r\nJizzax viloyatida  Iftorlik   🌙      18:29");
            }
            else if (update.CallbackQuery.Data == "Jizzax:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:35  \r\nJizzax viloyatida  Iftorlik   🌙      18:31");
            }
            else if (update.CallbackQuery.Data == "Jizzax:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:33  \r\nJizzax viloyatida  Iftorlik   🌙      18:32");
            }
            else if (update.CallbackQuery.Data == "Jizzax:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:31  \r\nJizzax viloyatida  Iftorlik   🌙      18:32");
            }
            else if (update.CallbackQuery.Data == "Jizzax:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:30  \r\nJizzax viloyatida  Iftorlik   🌙      18:33");
            }
            else if (update.CallbackQuery.Data == "Jizzax:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:28  \r\nJizzax viloyatida  Iftorlik   🌙      18:34");
            }
            else if (update.CallbackQuery.Data == "Jizzax:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:26  \r\nJizzax viloyatida  Iftorlik   🌙      18:35");
            }
            else if (update.CallbackQuery.Data == "Jizzax:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:24  \r\nJizzax viloyatida  Iftorlik   🌙      18:36");
            }
            else if (update.CallbackQuery.Data == "Jizzax:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:23  \r\nJizzax viloyatida  Iftorlik   🌙      18:37");
            }
            else if (update.CallbackQuery.Data == "Jizzax:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:21  \r\nJizzax viloyatida  Iftorlik   🌙      18:38");
            }
            else if (update.CallbackQuery.Data == "Jizzax:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:19  \r\nJizzax viloyatida  Iftorlik   🌙      18:40");
            }
            else if (update.CallbackQuery.Data == "Jizzax:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:17  \r\nJizzax viloyatida  Iftorlik   🌙      18:41");
            }
            else if (update.CallbackQuery.Data == "Jizzax:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:16  \r\nJizzax viloyatida  Iftorlik   🌙      18:42");
            }
            else if (update.CallbackQuery.Data == "Jizzax:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:16  \r\nJizzax viloyatida  Iftorlik   🌙      18:43");
            }
            else if (update.CallbackQuery.Data == "Jizzax:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:14  \r\nJizzax viloyatida  Iftorlik   🌙      18:44");
            }
            else if (update.CallbackQuery.Data == "Jizzax:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:12  \r\nJizzax viloyatida  Iftorlik   🌙      18:45");
            }
            else if (update.CallbackQuery.Data == "Jizzax:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:10  \r\nJizzax viloyatida  Iftorlik   🌙      18:46");
            }
            else if (update.CallbackQuery.Data == "Jizzax:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:09  \r\nJizzax viloyatida  Iftorlik   🌙      18:47");
            }
            else if (update.CallbackQuery.Data == "Jizzax:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:07  \r\nJizzax viloyatida  Iftorlik   🌙      18:48");
            }
            else if (update.CallbackQuery.Data == "Jizzax:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:05  \r\nJizzax viloyatida  Iftorlik   🌙      18:49");
            }
            else if (update.CallbackQuery.Data == "Jizzax:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:03  \r\nJizzax viloyatida  Iftorlik   🌙      18:50");
            }
            else if (update.CallbackQuery.Data == "Jizzax:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:01  \r\nJizzax viloyatida  Iftorlik   🌙      18:52");
            }
            else if (update.CallbackQuery.Data == "Jizzax:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nJizzax viloyatida Saxarlik ☀️      05:00  \r\nJizzax viloyatida  Iftorlik   🌙      18:53");
            }




            else if (update.CallbackQuery.Data == "Xorazm:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:14  \r\nXorazm viloyatida  Iftorlik   🌙      18:48");
            }
            else if (update.CallbackQuery.Data == "Xorazm:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:12  \r\nXorazm viloyatida  Iftorlik   🌙      18:50");
            }
            else if (update.CallbackQuery.Data == "Xorazm:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:11  \r\nXorazm viloyatida  Iftorlik   🌙      18:51");
            }
            else if (update.CallbackQuery.Data == "Xorazm:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:09  \r\nXorazm viloyatida  Iftorlik   🌙      18:52");
            }
            else if (update.CallbackQuery.Data == "Xorazm:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:07  \r\nXorazm viloyatida  Iftorlik   🌙      18:53");
            }
            else if (update.CallbackQuery.Data == "Xorazm:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:06  \r\nXorazm viloyatida  Iftorlik   🌙      18:54");
            }
            else if (update.CallbackQuery.Data == "Xorazm:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:04  \r\nXorazm viloyatida  Iftorlik   🌙      18:55");
            }
            else if (update.CallbackQuery.Data == "Xorazm:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:03  \r\nXorazm viloyatida  Iftorlik   🌙      18:57");
            }
            else if (update.CallbackQuery.Data == "Xorazm:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      06:01  \r\nXorazm viloyatida  Iftorlik   🌙      18:58");
            }
            else if (update.CallbackQuery.Data == "Xorazm:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:58  \r\nXorazm viloyatida  Iftorlik   🌙      19:00");
            }
            else if (update.CallbackQuery.Data == "Xorazm:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:57  \r\nXorazm viloyatida  Iftorlik   🌙      19:01");
            }
            else if (update.CallbackQuery.Data == "Xorazm:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:55  \r\nXorazm viloyatida  Iftorlik   🌙      19:02");
            }
            else if (update.CallbackQuery.Data == "Xorazm:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:53  \r\nXorazm viloyatida  Iftorlik   🌙      19:03");
            }
            else if (update.CallbackQuery.Data == "Xorazm:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:51  \r\nXorazm viloyatida  Iftorlik   🌙      19:04");
            }
            else if (update.CallbackQuery.Data == "Xorazm:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:50  \r\nXorazm viloyatida  Iftorlik   🌙      19:05");
            }
            else if (update.CallbackQuery.Data == "Xorazm:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:48  \r\nXorazm viloyatida  Iftorlik   🌙      19:06");
            }

            else if (update.CallbackQuery.Data == "Xorazm:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:46  \r\nXorazm viloyatida  Iftorlik   🌙      19:08");
            }
            else if (update.CallbackQuery.Data == "Xorazm:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:44  \r\nXorazm viloyatida  Iftorlik   🌙      19:09");
            }
            else if (update.CallbackQuery.Data == "Xorazm:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:43  \r\nXorazm viloyatida  Iftorlik   🌙      19:10");
            }
            else if (update.CallbackQuery.Data == "Xorazm:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:41  \r\nXorazm viloyatida  Iftorlik   🌙      19:12");
            }

            else if (update.CallbackQuery.Data == "Xorazm:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:39  \r\nXorazm viloyatida  Iftorlik   🌙      19:13");
            }
            else if (update.CallbackQuery.Data == "Xorazm:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:37  \r\nXorazm viloyatida  Iftorlik   🌙      19:14");
            }
            else if (update.CallbackQuery.Data == "Xorazm:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:35  \r\nXorazm viloyatida  Iftorlik   🌙      19:15");
            }
            else if (update.CallbackQuery.Data == "Xorazm:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:34  \r\nXorazm viloyatida  Iftorlik   🌙      19:16");
            }
            else if (update.CallbackQuery.Data == "Xorazm:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:32  \r\nXorazm viloyatida  Iftorlik   🌙      19:17");
            }
            else if (update.CallbackQuery.Data == "Xorazm:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:30  \r\nXorazm viloyatida  Iftorlik   🌙      19:18");
            }
            else if (update.CallbackQuery.Data == "Xorazm:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:28  \r\nXorazm viloyatida  Iftorlik   🌙      19:19");
            }
            else if (update.CallbackQuery.Data == "Xorazm:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:26  \r\nXorazm viloyatida  Iftorlik   🌙      19:21");
            }
            else if (update.CallbackQuery.Data == "Xorazm:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:25  \r\nXorazm viloyatida  Iftorlik   🌙      19:22");
            }
            else if (update.CallbackQuery.Data == "Xorazm:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nXorazm viloyatida Saxarlik ☀️      05:22  \r\nXorazm viloyatida  Iftorlik   🌙      19:24");
            }





            else if (update.CallbackQuery.Data == "Namangan:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:30  \r\nNamangan viloyatida  Iftorlik   🌙      18:06");
            }
            else if (update.CallbackQuery.Data == "Namangan:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:28  \r\nNamangan viloyatida  Iftorlik   🌙      18:08");
            }
            else if (update.CallbackQuery.Data == "Namangan:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:27  \r\nNamangan viloyatida  Iftorlik   🌙      18:09");
            }
            else if (update.CallbackQuery.Data == "Namangan:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:25  \r\nNamangan viloyatida  Iftorlik   🌙      18:10");
            }
            else if (update.CallbackQuery.Data == "Namangan:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:23  \r\nNamangan viloyatida  Iftorlik   🌙      18:11");
            }
            else if (update.CallbackQuery.Data == "Namangan:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:22  \r\nNamangan viloyatida  Iftorlik   🌙      18:12");
            }
            else if (update.CallbackQuery.Data == "Namangan:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:20  \r\nNamangan viloyatida  Iftorlik   🌙      18:13");
            }
            else if (update.CallbackQuery.Data == "Namangan:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:19  \r\nNamangan viloyatida  Iftorlik   🌙      18:15");
            }

            else if (update.CallbackQuery.Data == "Namangan:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:17  \r\nNamangan viloyatida  Iftorlik   🌙      18:16");
            }
            else if (update.CallbackQuery.Data == "Namangan:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:16  \r\nNamangan viloyatida  Iftorlik   🌙      18:17");
            }
            else if (update.CallbackQuery.Data == "Namangan:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:15  \r\nNamangan viloyatida  Iftorlik   🌙      18:18");
            }
            else if (update.CallbackQuery.Data == "Namangan:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:13  \r\nNamangan viloyatida  Iftorlik   🌙      18:19");
            }
            else if (update.CallbackQuery.Data == "Namangan:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:11  \r\nNamangan viloyatida  Iftorlik   🌙      18:20");
            }
            else if (update.CallbackQuery.Data == "Namangan:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:09  \r\nNamangan viloyatida  Iftorlik   🌙      18:21");
            }
            else if (update.CallbackQuery.Data == "Namangan:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:08  \r\nNamangan viloyatida  Iftorlik   🌙      18:22");
            }
            else if (update.CallbackQuery.Data == "Namangan:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:06  \r\nNamangan viloyatida  Iftorlik   🌙      18:23");
            }
            else if (update.CallbackQuery.Data == "Namangan:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:04  \r\nNamangan viloyatida  Iftorlik   🌙      18:25");
            }
            else if (update.CallbackQuery.Data == "Namangan:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:02  \r\nNamangan viloyatida  Iftorlik   🌙      18:26");
            }
            else if (update.CallbackQuery.Data == "Namangan:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      05:01  \r\nNamangan viloyatida  Iftorlik   🌙      18:27");
            }
            else if (update.CallbackQuery.Data == "Namangan:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:59  \r\nNamangan viloyatida  Iftorlik   🌙      18:28");
            }
            else if (update.CallbackQuery.Data == "Namangan:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:59  \r\nNamangan viloyatida  Iftorlik   🌙      18:29");
            }
            else if (update.CallbackQuery.Data == "Namangan:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:57  \r\nNamangan viloyatida  Iftorlik   🌙      18:30");
            }
            else if (update.CallbackQuery.Data == "Namangan:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:55  \r\nNamangan viloyatida  Iftorlik   🌙      18:31");
            }
            else if (update.CallbackQuery.Data == "Namangan:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:53  \r\nNamangan viloyatida  Iftorlik   🌙      18:32");
            }
            else if (update.CallbackQuery.Data == "Namangan:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:50  \r\nNamangan viloyatida  Iftorlik   🌙      18:33");
            }
            else if (update.CallbackQuery.Data == "Namangan:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:48  \r\nNamangan viloyatida  Iftorlik   🌙      18:34");
            }
            else if (update.CallbackQuery.Data == "Namangan:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:46  \r\nNamangan viloyatida  Iftorlik   🌙      18:35");
            }
            else if (update.CallbackQuery.Data == "Namangan:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:44  \r\nNamangan viloyatida  Iftorlik   🌙      18:37");
            }
            else if (update.CallbackQuery.Data == "Namangan:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:43  \r\nNamangan viloyatida  Iftorlik   🌙      18:38");
            }
            else if (update.CallbackQuery.Data == "Namangan:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nNamangan viloyatida Saxarlik ☀️      04:41  \r\nNamangan viloyatida  Iftorlik   🌙      18:38");
            }





            else if (update.CallbackQuery.Data == "Navoiy:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:30  \r\nNavoiy viloyatida  Iftorlik   🌙      18:06");
            }
            else if (update.CallbackQuery.Data == "Navoiy:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:28  \r\nNavoiy viloyatida  Iftorlik   🌙      18:08");
            }
            else if (update.CallbackQuery.Data == "Navoiy:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:27  \r\nNavoiy viloyatida  Iftorlik   🌙      18:09");
            }
            else if (update.CallbackQuery.Data == "Navoiy:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:25  \r\nNavoiy viloyatida  Iftorlik   🌙      18:10");
            }
            else if (update.CallbackQuery.Data == "Navoiy:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:23  \r\nNavoiy viloyatida  Iftorlik   🌙      18:11");
            }
            else if (update.CallbackQuery.Data == "Navoiy:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:22  \r\nNavoiy viloyatida  Iftorlik   🌙      18:12");
            }
            else if (update.CallbackQuery.Data == "Navoiy:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:20  \r\nNavoiy viloyatida  Iftorlik   🌙      18:13");
            }
            else if (update.CallbackQuery.Data == "Navoiy:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:19  \r\nNavoiy viloyatida  Iftorlik   🌙      18:15");
            }
            else if (update.CallbackQuery.Data == "Navoiy:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:17  \r\nNavoiy viloyatida  Iftorlik   🌙      18:16");
            }
            else if (update.CallbackQuery.Data == "Navoiy:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:16  \r\nNavoiy viloyatida  Iftorlik   🌙      18:17");
            }
            else if (update.CallbackQuery.Data == "Navoiy:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:15  \r\nNavoiy viloyatida  Iftorlik   🌙      18:18");
            }
            else if (update.CallbackQuery.Data == "Navoiy:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:13  \r\nNavoiy viloyatida  Iftorlik   🌙      18:19");
            }
            else if (update.CallbackQuery.Data == "Navoiy:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:11  \r\nNavoiy viloyatida  Iftorlik   🌙      18:20");
            }
            else if (update.CallbackQuery.Data == "Navoiy:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:09  \r\nNavoiy viloyatida  Iftorlik   🌙      18:21");
            }
            else if (update.CallbackQuery.Data == "Navoiy:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:08  \r\nNavoiy viloyatida  Iftorlik   🌙      18:22");
            }
            else if (update.CallbackQuery.Data == "Navoiy:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:06  \r\nNavoiy viloyatida  Iftorlik   🌙      18:23");
            }
            else if (update.CallbackQuery.Data == "Navoiy:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:04  \r\nNavoiy viloyatida  Iftorlik   🌙      18:25");
            }
            else if (update.CallbackQuery.Data == "Navoiy:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:02  \r\nNavoiy viloyatida  Iftorlik   🌙      18:26");
            }
            else if (update.CallbackQuery.Data == "Navoiy:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      05:01  \r\nNavoiy viloyatida  Iftorlik   🌙      18:27");
            }
            else if (update.CallbackQuery.Data == "Navoiy:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:59  \r\nNavoiy viloyatida  Iftorlik   🌙      18:28");
            }
            else if (update.CallbackQuery.Data == "Navoiy:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:57  \r\nNavoiy viloyatida  Iftorlik   🌙      18:29");
            }
            else if (update.CallbackQuery.Data == "Navoiy:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:55  \r\nNavoiy viloyatida  Iftorlik   🌙      18:30");
            }
            else if (update.CallbackQuery.Data == "Navoiy:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:53  \r\nNavoiy viloyatida  Iftorlik   🌙      18:31");
            }
            else if (update.CallbackQuery.Data == "Navoiy:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:52  \r\nNavoiy viloyatida  Iftorlik   🌙      18:32");
            }
            else if (update.CallbackQuery.Data == "Navoiy:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:50  \r\nNavoiy viloyatida  Iftorlik   🌙      18:33");
            }
            else if (update.CallbackQuery.Data == "Navoiy:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:48  \r\nNavoiy viloyatida  Iftorlik   🌙      18:34");
            }
            else if (update.CallbackQuery.Data == "Navoiy:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:46  \r\nNavoiy viloyatida  Iftorlik   🌙      18:35");
            }
            else if (update.CallbackQuery.Data == "Navoiy:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:44  \r\nNavoiy viloyatida  Iftorlik   🌙      18:37");
            }
            else if (update.CallbackQuery.Data == "Navoiy:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:43  \r\nNavoiy viloyatida  Iftorlik   🌙      18:38");
            }
            else if (update.CallbackQuery.Data == "Navoiy:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nNavoiy viloyatida Saxarlik ☀️      04:41  \r\nNavoiy viloyatida  Iftorlik   🌙      18:38");
            }





            else if (update.CallbackQuery.Data == "Qashqadaryo:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:54  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:31");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:53  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:33");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:52  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:34");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:51  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:35");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:49  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:36");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:47  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:37");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:46  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:38");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:44  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:40");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:43  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:41");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:41  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:41");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:40  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:42");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:39  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:43");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:37  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:44");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:35  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:45");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:33  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:46");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:32  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:47");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:30  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:49");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:28  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:50");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:26  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:51");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:25  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:51");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:23  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:52");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:21  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:53");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:19  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:54");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:18  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:55");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:16  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:56");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:14  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:57");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:12  \r\nQashqadaryo viloyatida  Iftorlik   🌙      18:58");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:10  \r\nQashqadaryo viloyatida  Iftorlik   🌙      19:00");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:09  \r\nQashqadaryo viloyatida  Iftorlik   🌙      19:01");
            }
            else if (update.CallbackQuery.Data == "Qashqadaryo:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nQashqadaryo viloyatida Saxarlik ☀️      05:09  \r\nQashqadaryo viloyatida  Iftorlik   🌙      19:01");
            }





             else if (update.CallbackQuery.Data == "Surxondaryo:1")
            {

                await bot.SendTextMessageAsync(userId, "🗓  1-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:49  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:26");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:2")
            {

                await bot.SendTextMessageAsync(userId, "🗓  2-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:48  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:28");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:3")
            {

                await bot.SendTextMessageAsync(userId, "🗓  3-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:47  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:29");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:4")
            {

                await bot.SendTextMessageAsync(userId, "🗓  4-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:46  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:30");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:5")
            {

                await bot.SendTextMessageAsync(userId, "🗓  5-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:44  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:31");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:6")
            {

                await bot.SendTextMessageAsync(userId, "🗓  6-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:42  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:32");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:7")
            {

                await bot.SendTextMessageAsync(userId, "🗓  7-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:41  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:33");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:8")
            {

                await bot.SendTextMessageAsync(userId, "🗓  8-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:39  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:35");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:9")
            {

                await bot.SendTextMessageAsync(userId, "🗓  9-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:38  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:36");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:10")
            {

                await bot.SendTextMessageAsync(userId, "🗓  10-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:36  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:36");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:11")
            {

                await bot.SendTextMessageAsync(userId, "🗓  11-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:36  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:37");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:12")
            {

                await bot.SendTextMessageAsync(userId, "🗓  12-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:35  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:38");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:13")
            {

                await bot.SendTextMessageAsync(userId, "🗓  13-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:33  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:39");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:14")
            {

                await bot.SendTextMessageAsync(userId, "🗓  14-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:31  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:40");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:15")
            {

                await bot.SendTextMessageAsync(userId, "🗓  15-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:29  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:41");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:16")
            {

                await bot.SendTextMessageAsync(userId, "🗓  16-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:28  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:42");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:26  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:44");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:17")
            {

                await bot.SendTextMessageAsync(userId, "🗓  17-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:24  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:45");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:18")
            {

                await bot.SendTextMessageAsync(userId, "🗓  18-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:22  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:46");
            }
            else if (update.CallbackQuery.Data == "Surxondaryo:19")
            {

                await bot.SendTextMessageAsync(userId, "🗓  19-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:21  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:45");
            }
            else if (update.CallbackQuery.Data == "Surxondaryo:20")
            {

                await bot.SendTextMessageAsync(userId, "🗓  20-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:21  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:46");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:21")
            {

                await bot.SendTextMessageAsync(userId, "🗓  21-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:19  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:47");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:22")
            {

                await bot.SendTextMessageAsync(userId, "🗓  22-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:17  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:48");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:23")
            {

                await bot.SendTextMessageAsync(userId, "🗓  23-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:15  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:49");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:24")
            {

                await bot.SendTextMessageAsync(userId, "🗓  24-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:14  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:50");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:25")
            {

                await bot.SendTextMessageAsync(userId, "🗓  25-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:12  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:51");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:26")
            {

                await bot.SendTextMessageAsync(userId, "🗓  26-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:10  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:52");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:27")
            {

                await bot.SendTextMessageAsync(userId, "🗓  27-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:08  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:54");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:28")
            {

                await bot.SendTextMessageAsync(userId, "🗓  28-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:06  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:55");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:29")
            {

                await bot.SendTextMessageAsync(userId, "🗓  29-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:05  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:54");
            }
             else if (update.CallbackQuery.Data == "Surxondaryo:30")
            {

                await bot.SendTextMessageAsync(userId, "🗓  30-mart Ramazon Taqvimi ✨\r\n\r\nSurxondaryo viloyatida Saxarlik ☀️      05:05  \r\nSurxondaryo viloyatida  Iftorlik   🌙      18:26");
            }







        }





    }




    private async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {

    }
}
