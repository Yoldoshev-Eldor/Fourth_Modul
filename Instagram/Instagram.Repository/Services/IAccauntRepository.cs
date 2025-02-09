using Instagram.Dal.Entities;

namespace Instagram.Repository.Services;

public interface IAccauntRepository
{
    Task<long> AddAccount(Account account);

    Task<Account> GetAccountByIdAsync(long id);

    Task<List<Account>> GetAllAccountAsync();
}