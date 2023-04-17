using Bank.Common.Constants;
using Bank.DAL.Contractors;
using Bank.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _db;
        private readonly DbSet<T> _table;
        public BaseRepository(BankDBContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }

        public DbSet<T> Table 
        { 
            get
            {
                return _table;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _table.ToListAsync();
            if (result == null)
                throw new Exception(ErrorMessage.NO_RECORD_FOUND);

            return result;
        }

        public async Task<IEnumerable<T>> GetByQueryAsync(Func<T, bool> condition)
        {
            var result = _table.Where(condition).ToList();
            return result;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
                throw new Exception(ErrorMessage.NO_RECORD_FOUND);

            return result;
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _table.AddAsync(entity);

        }

        public async Task UpdateAsync(object id, object model)
        {
            var data = await GetByIdAsync(id);
            _db.Entry(data).CurrentValues.SetValues(model);
        }

        public async Task DeleteAsync(object id)
        {
            var data = await GetByIdAsync(id);
            _table.Remove(data);
        }

    }
}
