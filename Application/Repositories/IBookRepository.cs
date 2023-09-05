using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.BookRepo
{
     public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task Create(Book book);

        Task Update(Book book);

        Task Delete(Guid id);

        Task<Book?> GetById(Guid id);
    }
}
