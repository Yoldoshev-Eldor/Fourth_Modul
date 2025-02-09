using Instagram.Bll.Dtos;
using Instagram.Dal.Entities;
using Instagram.Repository.Services;

namespace Instagram.Bll.Services;

public class AccountService : IAccountService
{
    private readonly IAccauntRepository _accountRepo;

    public AccountService(IAccauntRepository accountRepo)
    {
        _accountRepo = accountRepo;
    }

    public async Task<long> AddAccountAsync(AccountCreateDto accountCreateDto)
    {
        var account = new Account()
        {
            UserName = accountCreateDto.UserName,
            Bio = accountCreateDto.Bio,
        };
        return await _accountRepo.AddAccount(account);
    }

    public async Task<AccountGetDto> GetAccountByIdAsync(long id)
    {
        var account = await _accountRepo.GetAccountByIdAsync(id);
        if (account == null)
        {
            throw new Exception("null");
        }
        var accountDto = new AccountGetDto()
        {
            AccountId = account.AccountId,
            UserName = account.UserName,
            Bio = account.Bio,
            Posts = account.Posts,

        };
        return accountDto;
    }

    public async Task<List<AccountGetDto>> GetAllAccountAsync()
    {
        var accountEntiti = await _accountRepo.GetAllAccountAsync();
        var accountGetDto = new List<AccountGetDto>();
        foreach (var acc in accountEntiti)
        {
            var accDto = new AccountGetDto();

            accDto.AccountId = acc.AccountId;
            accDto.UserName = acc.UserName;
            accDto.Bio = acc.Bio;        
            
            accountGetDto.Add(accDto);
        }
        return accountGetDto;
    }
}
