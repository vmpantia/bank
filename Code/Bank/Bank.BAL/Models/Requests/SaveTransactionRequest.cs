using Bank.BAL.Models.DTOs;

namespace Bank.BAL.Models.Requests
{
    public class SaveTransactionRequest : BaseRequest
    {
        public TransactionDTO inputTransaction { get; set; }
    }
}
