using Bank.BAL.Models.DTOs;
using Bank.BAL.Models.Requests;

namespace Bank.BAL.Contractors
{
    public interface IAccountService
    {
        Task<AccountDTO> GetAccountByIdAsync(Guid internalID);
        Task<List<AccountDTO>> GetAccountsAsync();
        Task SaveAccountAsync(SaveAccountRequest request);
    }
}