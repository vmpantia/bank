using Bank.BAL.Models.DTOs;

namespace Bank.BAL.Models.Requests
{
    public class SaveAccountRequest : BaseRequest
    {
        public AccountDTO inputAccount { get; set; }
    }
}
