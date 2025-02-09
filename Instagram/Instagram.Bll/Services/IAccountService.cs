using Instagram.Bll.Dtos;
using Instagram.Dal.Entities;

namespace Instagram.Bll.Services;

public interface IAccountService
{
    Task<long> AddAccountAsync(AccountCreateDto account);

    Task<AccountGetDto> GetAccountByIdAsync(long id);

    Task<List<AccountGetDto>> GetAllAccountAsync();

}