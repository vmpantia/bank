using Bank.DAL.Models.MST;
using System;
using System.Threading.Tasks;

namespace Bank.DAL.Contractors
{
    internal interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Account_MST> AccountRepository { get; }
        Task SaveAsync();
    }
}
