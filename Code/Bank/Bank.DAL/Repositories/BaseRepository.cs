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
                throw new ArgumentNullException("No records found in the system.");

            return result;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
                throw new ArgumentNullException("No record found in the system.");

            return result;
        }

        public bool IsDataExist(Func<T, bool> condition)
        {
            var result = _table.Where(condition);
            return result.ToList().Any();
        }

        public async Task AddAsync(T t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t));

            await _table.AddAsync(t);
            var result = await _db.SaveChangesAsync();

            if (result <= 0)
                throw new Exception("Error in creating data.");
        }

        public async Task UpdateAsync(object id, object model)
        {
            var data = await GetByIdAsync(id);
            if (data != null)
            {
                _db.Entry(data).CurrentValues.SetValues(model);
                var result = await _db.SaveChangesAsync();

                if (result <= 0)
                    throw new Exception("Error in updating data.");
            }
        }

        public async Task DeleteAsync(object id)
        {
            var data = await GetByIdAsync(id);
            if (data != null)
            {
                _table.Remove(data);
                var result = await _db.SaveChangesAsync();

                if (result <= 0)
                    throw new Exception("Error in deleting data.");
            }
        }

    }
}
