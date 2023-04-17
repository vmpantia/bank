using Bank.BAL.Contractors;
using Bank.BAL.Models.DTOs;
using Bank.BAL.Models.Requests;
using Bank.BAL.Utilities;
using Bank.Common.Constants;
using Bank.DAL.Contractors;
using Bank.DAL.Models.MST;

namespace Bank.BAL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AccountDTO>> GetAccountsAsync()
        {
            var result = await _unitOfWork.ActRepo.GetAllAsync();
            return result.Select(data => Parser.ParseAccount(data)).ToList();
        }

        public async Task<List<AccountDTO>> GetAccountByQueryAsync(string query)
        {
            var result = await _unitOfWork.ActRepo.GetByQueryAsync(data => data.FirstName.Contains(query) ||
                                                                          data.LastName.Contains(query));
            return result.Select(data => Parser.ParseAccount(data)).ToList();
        }

        public async Task<AccountDTO> GetAccountByIDAsync(Guid internalID)
        {
            var result = await _unitOfWork.ActRepo.GetByIDAsync(internalID);
            return Parser.ParseAccount(result);
        }

        public async Task SaveAccountAsync(SaveAccountRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var requestID = await _unitOfWork.InsertRequestAsync(request.FunctionID, 
                                                                 request.RequestStatus, 
                                                                 request.inputClient.UserID);
            var input = Parser.ParseAccount(request.inputAccount);
            switch (request.FunctionID)
            {
                case RequestFunction.ADD_ACCOUNT:
                    await InsertAccountAsync(input);
                    break;
                case RequestFunction.EDIT_ACCOUNT:
                    await UpdateAccountAsync(input);
                    break;
                case RequestFunction.DELETE_ACCOUNT:
                    await DeleteAccountAsync(input.InternalID);
                    break;
            }
            await InsertAccountTrnAsync(input, requestID);
            await _unitOfWork.SaveAsync();
        }

        private async Task InsertAccountAsync(Account_MST input)
        {
            input.InternalID = Guid.NewGuid();
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = null;
            await _unitOfWork.ActRepo.AddAsync(input);
        }

        private async Task UpdateAccountAsync(Account_MST input)
        {
            await _unitOfWork.ActRepo.UpdateAsync(input.InternalID, new
            {
                //input.InternalID,
                //input.AccountNumber,
                input.Type,
                input.FirstName,
                input.LastName,
                input.MiddleName,
                input.Gender,
                input.CivilStatus,
                input.Birthdate,
                input.Birthplace,
                input.CountryCode,
                input.PhoneNumber,
                input.EmailAddress,
                input.PresentAddress,
                input.PermanentAddress,
                input.ProvincialAddress,
                input.Status,
                //input.CreatedDate,
                ModifiedDate = DateTime.Now
            });
        }

        private async Task DeleteAccountAsync(Guid internalID)
        {
            await _unitOfWork.ActRepo.DeleteAsync(internalID);
        }

        private async Task InsertAccountTrnAsync(Account_MST input, string requestID, int number = 1)
        {
            var trn = Parser.ParseAccount(input, requestID, number);
            await _unitOfWork.ActTrnRepo.AddAsync(trn);
        }
    }
}
