using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.DAL.Models.MST
{
    public class Transaction_MST
    {
        //Transaction Details
        [Key]
        public Guid InternalID { get; set; }

        public Guid Account_InternalID { get; set; }

        [Required, MaxLength(5)]
        public string Code { get; set; }

        [Required, MaxLength(15)]
        public string Made { get; set; }

        [Required, Precision(18, 2)]
        public decimal Amount { get; set; }

        [Required, Precision(18, 2)]
        public decimal Fee { get; set; }

        [Required, MaxLength(50)]
        public string Location { get; set; }

        [Required, MaxLength(100)]
        public string Remarks { get; set; }

        //Common Columns
        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}
