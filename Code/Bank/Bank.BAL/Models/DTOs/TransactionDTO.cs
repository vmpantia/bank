namespace Bank.BAL.Models.DTOs
{
    public class TransactionDTO
    {
        //Transaction Details
        public Guid InternalID { get; set; }
        public Guid Account_InternalID { get; set; }
        public string Code { get; set; }
        public string Made { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public decimal RunningBalance { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }

        //Common Columns
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
