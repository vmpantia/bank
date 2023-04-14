using Bank.BAL.Models.DTOs;

namespace Bank.BAL.Models.Requests
{
    public class SaveAccountRequest
    {
        public string RequestID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }
        public AccountDTO inputAccount { get; set; }
    }
}
