using Application.Services;
using Damen.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorDbContext _authorDbContext;

        public AuthorRepository(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }

        public Task<bool> Create(Author author)
        {
            _authorDbContext.Authors.AddAsync(author);

            _authorDbContext.SaveChangesAsync();

            return Task.FromResult(true);
        }

        public Task<IEnumerable<Author>> GetAllAuthor()
        {
            var authors = _authorDbContext.Authors.AsEnumerable();

            _authorDbContext.SaveChangesAsync();

            return Task.FromResult(authors);
        }

        public Task<Author?> GetById(Guid id)
        {
            var author = _authorDbContext.Authors.FirstOrDefault(i => i.id == id);

            _authorDbContext.SaveChangesAsync();

            return Task.FromResult(author);
        }

        public Task<bool> Update(Author author)
        {
            _authorDbContext.Authors.Update(author);

            _authorDbContext.SaveChangesAsync();

            return Task.FromResult(true);
        }

        public Task<bool> Delete(Guid id)
        {
            var author = _authorDbContext.Authors.FirstOrDefault(i => i.id == id);
            if (author ==null)
            {
                return Task.FromResult(false);
            }
            _authorDbContext.Authors.Remove(author);

            _authorDbContext.SaveChangesAsync();

            return Task.FromResult(true);
        }
    }
}
