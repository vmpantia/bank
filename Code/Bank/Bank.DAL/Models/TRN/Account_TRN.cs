using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.DAL.Models.TRN
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(InternalID))]
    public class Account_TRN
    {
        [Required, MaxLength(15)]
        public string RequestID { get; set; }

        public int Number { get; set; }

        //Account Details
        public Guid InternalID { get; set; }

        [Required, MaxLength(15)]
        public string AccountNumber { get; set; }

        public int Type { get; set; }

        //Personal Details
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string? MiddleName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(6)]
        public string Gender { get; set; }

        [Required, MaxLength(10)]
        public string CivilStatus { get; set; }

        public DateTime Birthdate { get; set; }

        [Required, MaxLength(150)]
        public string Birthplace { get; set; }

        //Contact Details
        [Required, MaxLength(5)]
        public string CountryCode { get; set; }

        [Required, MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(50)]
        public string EmailAddress { get; set; }

        //Location Details
        [Required, MaxLength(150)]
        public string PresentAddress { get; set; }

        [Required, MaxLength(150)]
        public string PermanentAddress { get; set; }

        [MaxLength(150)]
        public string ProvincialAddress { get; set; }

        //Common Columns
        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
