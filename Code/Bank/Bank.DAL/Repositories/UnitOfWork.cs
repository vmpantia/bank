using Bank.DAL.Contractors;
using Bank.DAL.Data;
using Bank.DAL.Models.MST;
using System;
using System.Threading.Tasks;

namespace Bank.DAL.Repositories
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BankDBContext _db;
        private IBaseRepository<Account_MST> _account;

        public UnitOfWork(BankDBContext db)
        {
            _db = db;
        }

        public IBaseRepository<Account_MST> AccountRepository
        {
            get
            {
                if(_account == null)
                    _account = new BaseRepository<Account_MST>(_db);

                return _account;
            }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
