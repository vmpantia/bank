using Bank.BAL.Models.DTOs;
using Bank.BAL.Models.Requests;
using Bank.BAL.Utilities;
using Bank.Common.Constants;
using Bank.DAL.Contractors;
using Bank.DAL.Models.MST;
using Microsoft.EntityFrameworkCore;

namespace Bank.BAL.Services
{
    public class TransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TransactionDTO>> GetTransactionsAsync(Guid acctInternalID)
        {
            var result = await _unitOfWork.TrnRepo.Table.Where(data => data.Account_InternalID == acctInternalID)
                                                        .ToListAsync();
            return Parser.ParseTransactions(result);
        }

        public async Task SaveTransactionAsync(SaveTransactionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            await _unitOfWork.InsertRequestAsync(request.FunctionID,
                                                 request.RequestStatus,
                                                 request.inputClient.UserID);
            var input = Parser.ParseTransaction(request.inputTransaction);
            switch (request.FunctionID)
            {
                case RequestFunction.ADD_TRANSACTION:
                    await InsertTransactionAsync(input);
                    break;
                case RequestFunction.EDIT_TRANSACTION:
                    await UpdateTransactionAsync(input);
                    break;
                default:
                    await DeleteTransactionAsync(input.InternalID);
                    break;
            }
            await _unitOfWork.SaveAsync();
        }

        private async Task InsertTransactionAsync(Transaction_MST input)
        {
            input.InternalID = Guid.NewGuid();
            input.CreatedDate = DateTime.Now;
            input.ModifiedDate = null;
            await _unitOfWork.TrnRepo.AddAsync(input);
        }

        private async Task UpdateTransactionAsync(Transaction_MST input)
        {
            await _unitOfWork.TrnRepo.UpdateAsync(input.InternalID, new
            {
                //input.InternalID,
                //input.Account_InternalID,
                input.Code,
                input.Made,
                input.Amount,
                input.Fee,
                input.Location,
                input.Remarks,
                input.Status,
                //input.CreatedDate,
                ModifiedDate = DateTime.Now
            });
        }

        private async Task DeleteTransactionAsync(Guid internalID)
        {
            await _unitOfWork.TrnRepo.DeleteAsync(internalID);
        }
    }
}
