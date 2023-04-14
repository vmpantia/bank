using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bank.DAL.Contractors
{
    public interface IBaseRepository<T> where T : class
    {
        bool IsDataExist(Func<T, bool> condition);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task AddAsync(T entity, bool isAutoSave = true);
        Task UpdateAsync(object id, object model, bool isAutoSave = true);
        Task DeleteAsync(object id, bool isAutoSave = true);
    }
}
