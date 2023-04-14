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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _table.ToListAsync();
            if (result == null)
                throw new Exception(ErrorMessage.ERROR_NO_RECORD_FOUND);

            return result;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
                throw new Exception(ErrorMessage.ERROR_NO_RECORD_FOUND);

            return result;
        }

        public bool IsDataExist(Func<T, bool> condition)
        {
            var result = _table.Where(condition);
            return result.ToList().Any();
        }

        public async Task AddAsync(T entity, bool isAutoSave = true)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _table.AddAsync(entity);

            if (!isAutoSave)
                return;

            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new Exception(ErrorMessage.ERROR_INSERTING_DATA);
        }

        public async Task UpdateAsync(object id, object model, bool isAutoSave = true)
        {
            var data = await GetByIdAsync(id);
            _db.Entry(data).CurrentValues.SetValues(model);

            if (!isAutoSave)
                return;

            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new Exception(ErrorMessage.ERROR_UPDATING_DATA);
        }

        public async Task DeleteAsync(object id, bool isAutoSave = true)
        {
            var data = await GetByIdAsync(id);
            _table.Remove(data);

            if (!isAutoSave)
                return;

            var result = await _db.SaveChangesAsync();
            if (result <= 0)
                throw new Exception(ErrorMessage.ERROR_DELETING_DATA);
        }

    }
}
