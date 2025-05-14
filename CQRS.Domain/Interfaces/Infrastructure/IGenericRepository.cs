using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Domain.Interfaces.Infrastructure
{
    public interface IGenericRepository<T>
    {
        /* Commands */
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        /* Queries */
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
