using Bank.BAL.Models.DTOs;
using Bank.BAL.Models.Requests;

namespace Bank.BAL.Contractors
{
    public interface IAccountService
    {
        Task<List<AccountDTO>> GetAccountsAsync();
        Task<List<AccountDTO>> GetAccountByQueryAsync(string query);
        Task<AccountDTO> GetAccountByIDAsync(Guid internalID);
        Task SaveAccountAsync(SaveAccountRequest request);
    }
}