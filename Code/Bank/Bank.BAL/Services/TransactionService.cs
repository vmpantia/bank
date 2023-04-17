using Bank.BAL.Models.DTOs;
using Bank.DAL.Contractors;
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

        }

        public async Task<TransactionDTO> GetTransactionByIDAsync(Guid internalID)
        {
            var result = await _unitOfWork.TrnRepo.GetByIDAsync(internalID);

        }
    }
}
