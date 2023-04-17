using Bank.DAL.Models.LST;
using Bank.DAL.Models.MST;
using Bank.DAL.Models.TRN;
using System;
using System.Threading.Tasks;

namespace Bank.DAL.Contractors
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Request_LST> ReqRepo { get; }
        IBaseRepository<Account_MST> ActRepo { get; }
        IBaseRepository<Account_TRN> ActTrnRepo { get; }
        IBaseRepository<Transaction_MST> TrnRepo { get; }
        Task<string> InsertRequestAsync(string functionID, string requestStatus, Guid userID);
        Task SaveAsync();
    }
}
