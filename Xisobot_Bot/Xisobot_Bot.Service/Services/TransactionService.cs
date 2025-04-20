using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

using Xisobot_Bot.DataAccess.Entities;
using Xisobot_Bot.DataAccess;

namespace Xisobot_Bot.Service.Services;

public class TransactionService : ITransactionService
{
    private readonly MainContext _mainContext;

    public TransactionService(MainContext mainContext)
    {
        _mainContext = mainContext;
    }


    public async Task AddTransactionAsync(long userId, decimal amount, string type, string description)
    {
        // Foydalanuvchi bazada bormi yoki yo‘q?
        var user = await _mainContext.Users.FindAsync(userId);
      

        // Yangi transaction yaratish
        var newTransaction = new Transaction
        {
            UserId = userId,
            Amount = amount,
            Type = type,
            Description = description,
            CreatedAt = DateTime.UtcNow
        };

        // Transactionni bazaga saqlash
        _mainContext.Transactions.Add(newTransaction);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<Transaction>> GetTransactionsByUserIdAsync(long userId)
    {
        return await _mainContext.Transactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }
    public async Task<string> GetTransactionsAsCsvAsync(long userId)
    {
        var transactions = await GetTransactionsByUserIdAsync(userId);
        if (!transactions.Any()) return string.Empty;

        var sb = new StringBuilder();
        sb.AppendLine("Id,UserId,Amount,Type,Description,CreatedAt");

        foreach (var t in transactions)
        {
            sb.AppendLine($"{t.Id},{t.UserId},{t.Amount},{t.Type},{t.Description},{t.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}");
        }

        return sb.ToString();
    }

}
