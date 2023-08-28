using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthors();

        Task<bool> Create(Author author);

        Task<bool> Update(Author author,Guid id);

        Task<bool> Delete(Guid id);

        Task<Author?> GetById(Guid id);
    }
}
