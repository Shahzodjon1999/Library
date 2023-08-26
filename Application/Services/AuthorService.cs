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

        public Task<string> Create(Author author)
        {
            _authorRepository.Create(author);

            return Task.FromResult("Seccessful added");
        }

        public Task<IEnumerable<Author>> GetAuthors()
        {
            var authors = _authorRepository.GetAllAuthor();
            return authors;
        }

        public Task<Author> GetById(Guid id)
        {
            var author = _authorRepository.GetById(id);

            return author;
        }

        public Task<string> Update(Author author,Guid id)
        {
            _authorRepository.Update(author,id);

            return Task.FromResult("Seccessfull added");
        }

        public Task<string> Delete(Guid id)
        {
            _authorRepository.Delete(id);

            return Task.FromResult("Sesscesfull deleted");
        }
    }
}
