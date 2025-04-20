using Xisobot_Bot.DataAccess.Entities;

namespace Xisobot_Bot.Service.Services;

public interface ITransactionService
{

    public  Task<string> GetTransactionsAsCsvAsync(long userId);
    public  Task<List<Transaction>> GetTransactionsByUserIdAsync(long userId);
    public  Task AddTransactionAsync(long userId, decimal amount, string type, string description);
}