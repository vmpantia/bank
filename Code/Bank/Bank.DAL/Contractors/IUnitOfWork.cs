using System;
using System.Threading.Tasks;

namespace Bank.DAL.Contractors
{
    internal interface IUnitOfWork : IDisposable
    {
        Task SaveAsync();
    }
}
