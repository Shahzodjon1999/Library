using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IBaseModel<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(Guid id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(Guid id);
    }
}
