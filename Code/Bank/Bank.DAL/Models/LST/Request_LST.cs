using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DAL.Models.LST
{
    public class Request_LST
    {
        [Key, MaxLength(15)]
        public string RequestID { get; set; }

        [MaxLength(5)]
        public string FunctionID { get; set; }

        public DateTime RequestDate { get; set; }

        public Guid RequestBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public Guid? ApprovedBy { get; set; }

        [MaxLength(2)]
        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

    }
}
