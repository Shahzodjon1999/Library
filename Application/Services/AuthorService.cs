using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<bool> Create(Author author)
        {
            _authorRepository.Create(author);

            return Task.FromResult(true);
        }

        public Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = _authorRepository.GetAllAuthor();
            return authors;
        }

        public Task<Author?> GetById(Guid id)
        {
            var author = _authorRepository.GetById(id);

            return author;
        }

        public Task<bool> Update(Author author,Guid id)
        {
            _authorRepository.Update(author);

            return Task.FromResult(true);
        }

        public Task<bool> Delete(Guid id)
        {
            _authorRepository.Delete(id);

            return Task.FromResult(true);
        }
    }
}
