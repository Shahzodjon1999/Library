using Application.Services;
using Damen.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ContractDbContext _contractDbContext;

        public AuthorRepository(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;
        }

        public async Task Create(Author author)
        {
            try
            {
                await _contractDbContext.Authors.AddAsync(author);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("AuthorRepository has method create() error" + ex.Message);
            }
        }

        public async Task<IEnumerable<Author>> GetAllAuthor()
        {
            try
            {
               return _contractDbContext.Authors.Include(g=>g.Books);
            }
            catch (Exception)
            {
                throw new NullReferenceException("AuthorRepository has method Getall() Doesn't find Authors");
            }
        }

        public async Task<Author?> GetById(Guid id)
        {
            try
            {
                return _contractDbContext.Authors.FirstOrDefault(i => i.id == id); 
            }
            catch (Exception)
            {
                throw new NullReferenceException("AuthorRepository has method GetById() Doesn't find Author");
            }
        }

        public async Task Update(Author author)
        {
            try
            {
                _contractDbContext.Authors.Update(author);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("AuthorRepository has method Update() Doesn't update");
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var author = _contractDbContext.Authors.FirstOrDefault(i => i.id == id);

                _contractDbContext.Authors.Remove(author);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NullReferenceException("AuthorRepository has method delete() Doesn't delete");
            }

        }
    }
}
