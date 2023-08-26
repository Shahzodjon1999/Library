using Application.Mapping;
using Application.RequestModels.AuthorRequestModels;
using Application.Services;
using Damen.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorContrroler : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorContrroler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public Task<string> create([FromBody] CreateAuthorRequestModel createAuthorRequest)
        {
            var res = createAuthorRequest.MapToAuthor();

            _authorService.Create(res);

            return Task.FromResult("Seccessffull added!!!");
        }

        [HttpGet]
        public Task<IEnumerable<Author>> Get()
        {
            return _authorService.GetAuthors();
        }

        [HttpGet("{id}")]
        public Task<Author> getById([FromRoute] Guid id)
        {
            var author = _authorService.GetById(id);

            return author;
        }

        [HttpPut("{id}")]
        public Task<string> update([FromBody] CreateAuthorRequestModel createAuthorRequest, [FromRoute] Guid id)
        {
            var result = createAuthorRequest.MapToAuthor();
            if (result == null)
            {
                return Task.FromResult("not found");
            }
            var author = _authorService.Update(result,id);

            return Task.FromResult("Seccessffull update!!!");
        }

        [HttpDelete("{id}")]
        public Task<string> delete([FromRoute] Guid  id)
        {
            var author = _authorService.Delete(id);
            if (author==null)
            {
                return Task.FromResult("not found");
            }
            return Task.FromResult("Seccessffull delete!!!");
        }

    }
}
