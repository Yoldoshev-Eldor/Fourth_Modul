using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xisobot_Bot.DataAccess.Entities;

public class Transaction
{
    public long Id { get; set; }
    public long UserId { get; set; } // Foreign Key
    public decimal Amount { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Type { get; set; } = "Expense"; // "Income" yoki "Expense"
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }
    public BotUser User { get; set; } // Navigation Property

}
