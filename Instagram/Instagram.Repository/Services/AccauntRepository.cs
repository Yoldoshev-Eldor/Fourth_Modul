using Instagram.Dal;
using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repository.Services;

public class AccauntRepository : IAccauntRepository
{
    private readonly MainContext _mainContext;

    public AccauntRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddAccount(Account account)
    {
        await _mainContext.Accounts.AddAsync(account);
        await _mainContext.SaveChangesAsync();
        return account.AccountId;
    }

    public async Task<Account> GetAccountByIdAsync(long id)
    {
      var account =await _mainContext.Accounts.FirstOrDefaultAsync(ac => ac.AccountId == id);
        if (account == null)
        {
            throw new Exception("Null");
        }
        return account;
    }

    public async Task<List<Account>> GetAllAccountAsync()
    {
        return await  _mainContext.Accounts.Include(ac => ac.Posts).ToListAsync();
    }
}
