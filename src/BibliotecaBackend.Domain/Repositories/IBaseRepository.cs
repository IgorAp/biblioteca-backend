using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBackend.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAsync();
        Task AddAsync(T aggregateRoot);
        Task Update(T aggregateRoot);
        Task Remove(T aggregateRoot);
    }
}
