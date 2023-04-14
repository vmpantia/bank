using System;

namespace Bank.BAL.Models.DTOs
{
    public class AccountDTO
    {
        //Account Details
        public Guid InternalID { get; set; }
        public string AccountNumber { get; set; }
        public int Type { get; set; }
        public string TypeDescription { get; set; }

        //Personal Details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }

        //Contact Details
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        //Location Details
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string ProvincialAddress { get; set; }

        //Common Columns
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
