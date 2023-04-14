using Bank.Common.Constants;
using Bank.DAL.Contractors;
using Bank.DAL.Data;
using Bank.DAL.Models.MST;
using System;
using System.Threading.Tasks;

namespace Bank.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
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
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new Exception(ErrorMessage.SAVING_DATA);
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
