using Bank.Common.Constants;
using Bank.DAL.Contractors;
using Bank.DAL.Data;
using Bank.DAL.Models.LST;
using Bank.DAL.Models.MST;
using Bank.DAL.Models.TRN;
using System;
using System.Threading.Tasks;

namespace Bank.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BankDBContext _db;
        private IBaseRepository<Request_LST> _req;
        private IBaseRepository<Account_MST> _act;
        private IBaseRepository<Account_TRN> _actTrn;

        public UnitOfWork(BankDBContext db)
        {
            _db = db;
        }

        public IBaseRepository<Request_LST> ReqRepo
        {
            get
            {
                if (_req == null)
                    _req = new BaseRepository<Request_LST>(_db);

                return _req;
            }
        }
        public IBaseRepository<Account_MST> ActRepo
        {
            get
            {
                if(_act == null)
                    _act = new BaseRepository<Account_MST>(_db);

                return _act;
            }
        }
        public IBaseRepository<Account_TRN> ActTrnRepo
        {
            get
            {
                if (_actTrn == null)
                    _actTrn = new BaseRepository<Account_TRN>(_db);

                return _actTrn;
            }
        }

        public async Task SaveAsync()
        {
            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new Exception(ErrorMessage.SAVING_DATA);

            Dispose();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
