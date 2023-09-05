using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthor();

        Task Create(Author author);

        Task Update(Author author);

        Task Delete(Guid id);

        Task<Author?> GetById(Guid id);
    }
}
