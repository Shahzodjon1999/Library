using Application.Services;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AuthorRepository : IAuthorRepository
    {
        public static List<Author> authors = new List<Author>()
        {
            new Author{Name="Bobo",BookId=2},

            new Author{Name="Author",BookId=3},

            new Author{Name="Salom",BookId=4},
        };

        public Task<string> Create(Author author)
        {
            authors.Add(author);

            return Task.FromResult("Seccessful addedRepo");
        }

        public Task<IEnumerable<Author>> GetAllAuthor()
        {
            return Task.FromResult(authors.AsEnumerable());
        }

        public Task<Author> GetById(Guid id)
        {
            var authorRes = authors.FirstOrDefault(i => i.id == id);

            return Task.FromResult(authorRes);
        }

        public Task<string> Update(Author author, Guid id)
        {
            var result = authors.FindIndex(i => i.id == author.id);

            if (result > 0)

                authors[result] = author;

            return Task.FromResult("Seccessful updateRepo");

            return Task.FromResult("Not found");
      
        }

        public Task<string> Delete(Guid id)
        {
            var result = authors.RemoveAll(i => i.id == id);

            return Task.FromResult("Seccessfull deleteRepo");
        }
    }
}
