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
            var result = await _unitOfWork.AccountRepository.GetAllAsync();
            return result.Select(data => Parser.ParseAccount(data)).ToList();
        }

        public async Task<AccountDTO> GetAccountByIdAsync(Guid internalID)
        {
            var result = await _unitOfWork.AccountRepository.GetByIdAsync(internalID);
            return Parser.ParseAccount(result);
        }

        public async Task SaveAccountAsync(SaveAccountRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var input = Parser.ParseAccount(request.inputAccount);

            switch (request.FunctionID)
            {
                case RequestFunction.ADD_ACCOUNT:
                    await AddAccount(input);
                    break;
                case RequestFunction.EDIT_ACCOUNT:
                    await EditAccount(input);
                    break;
                case RequestFunction.DELETE_ACCOUNT:
                    await _unitOfWork.AccountRepository.DeleteAsync(input.InternalID);
                    break;
            }
            await _unitOfWork.SaveAsync();
        }

        private async Task AddAccount(Account_MST input)
        {
            input.InternalID = Guid.NewGuid();
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = null;
            await _unitOfWork.AccountRepository.AddAsync(input);
        }

        private async Task EditAccount(Account_MST input)
        {
            await _unitOfWork.AccountRepository.UpdateAsync(input.InternalID, new
            {
                //InternalID = input.InternalID,
                //AccountNumber = input.AccountNumber,
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
                //CreatedDate = input.CreatedDate,
                ModifiedDate = DateTime.Now
            });
        }
    }
}
