namespace Xisobot_Bot.DataAccess.Entities;

public class BotUser
{
    public long Id { get; set; } // Primary Key
    public long TelegramUserId { get; set; } // Telegram foydalanuvchi ID
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } // Telegramda lastname bo'lmasligi mumkin
    public string? Username { get; set; } // Telegram username (@username)
    public string PhoneNumber { get; set; } = string.Empty; // Foydalanuvchi telefon raqami
    public string? Bio { get; set; } // Telegramdagi bio qismi
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foydalanuvchining daromad va xarajatlari
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

}
