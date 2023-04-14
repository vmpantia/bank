using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BAL.Models.Requests
{
    public class BaseRequest
    {
        public string RequestID { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }
    }
}
