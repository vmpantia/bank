using Bank.DAL.Models.LST;
using Bank.DAL.Models.MST;
using Bank.DAL.Models.TRN;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL.Data
{
    public class BankDBContext : DbContext
    {
        public BankDBContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Account_MST> Account_MST { get; set; }
        public virtual DbSet<Account_TRN> Account_TRN { get; set; }
        public virtual DbSet<Request_LST> Request_LST { get; set; }
    }
}
