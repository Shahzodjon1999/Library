using Application.Repositories.BookRepo;
using Damen.Models;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesInfrastucture.BookRepo
{
    public class BookRepository : IBookRepository
    {
        private readonly ContractDbContext _contractDbContext;

        public BookRepository(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;
        }
        public async Task Create(Book book)
        {
            try
            {
              await  _contractDbContext.Books.AddAsync(book);

              await  _contractDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new NullReferenceException("j");
            }
           
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var book = _contractDbContext.Books.FirstOrDefault(i => i.Id == id);

                 _contractDbContext.Books.Remove(book);

               await _contractDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw new NullReferenceException("j");
            }

        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            try
            {
                return _contractDbContext.Books.AsEnumerable();
            }
            catch (Exception)
            {
                throw new NullReferenceException("j");
            }
        }

        public async Task<Book?> GetById(Guid id)
        {
            try
            {
                return  _contractDbContext.Books.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception)
            {
                throw new NullReferenceException("j");
            }
        }

        public async Task Update(Book book)
        {
            try
            {
               _contractDbContext.Books.Update(book);

               await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException("j");
            }

        }
    }
}
