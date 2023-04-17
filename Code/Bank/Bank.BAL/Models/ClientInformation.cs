using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BAL.Models
{
    public class ClientInformation
    {
        public Guid ClientID { get; set; }
        public Guid UserID { get; set; }
        public string Browser { get; set; } = string.Empty;
        public string BrowserVersion { get; set; } = string.Empty;
        public string Windows { get; set; } = string.Empty;
        public string WindowsVersion { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
    }
}
