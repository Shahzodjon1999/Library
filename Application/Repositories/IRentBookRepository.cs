using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRentBookRepository
    {
        Task<IEnumerable<RentBook>> GetAllRentBook();

        Task Create(RentBook rentBook);

        Task Update(RentBook rentBook);

        Task Delete(Guid id);

        Task<RentBook?> GetById(Guid id);
    }
}
