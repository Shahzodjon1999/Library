using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();

        Task Create(Category category);

        Task Update(Category category);

        Task Delete(Guid id);

        Task<Category?> GetById(Guid id);
    }
}
