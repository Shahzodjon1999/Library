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

        Task<string> Create(Author author);

        Task<string> Update(Author author, Guid id);

        Task<string> Delete(Guid id);

        Task<Author> GetById(Guid id);
    }
}
