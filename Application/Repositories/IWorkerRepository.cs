using Application.ResponsModels;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<Worker>> GetAllCategories();

        Task Create(Worker worker);

        Task Update(Worker worker);

        Task Delete(Guid id);

        Task<Worker?> GetById(Guid id);
    }
}
