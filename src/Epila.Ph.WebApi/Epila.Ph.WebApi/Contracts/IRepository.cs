using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epila.Ph.WebApi.Contracts
{
    public interface IRepository<T, in TE>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> CreateAsync(TE entity);
        Task<T> UpdateAsync(TE entity,object id);
        Task<bool> DeleteAsync(object id);
        Task<bool> ExistAsync(object id);
    }
}
