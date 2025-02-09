using Instagram.Bll.Dtos;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("getAlll")]
        public async Task<List<AccountGetDto>> GetAll()
        {
            return await _accountService.GetAllAccountAsync();
        }
        [HttpPost("addAccount")]
        public async Task<long>AddAccount(AccountCreateDto account)
        {
            return await _accountService.AddAccountAsync(account);
        }
        
        [HttpPost("getAccount")]
        public async Task<AccountGetDto> GetAccountId(long id)
        {
            return await _accountService.GetAccountByIdAsync(id);
        }
    }
}
