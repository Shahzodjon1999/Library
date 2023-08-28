using Application.Mapping;
using Application.RequestModels.AuthorRequestModels;
using Application.Services;
using Damen.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    public class AuthorContrroler : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorContrroler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost(ApiEndPoints.Author.Create)]
        public async Task<IActionResult> create([FromBody] CreateAuthorRequestModel createAuthorRequest)
        {
            var res = createAuthorRequest.MapToAuthor();

             await  _authorService.Create(res);

            return Ok("Seccessfull added");
        }

        [HttpGet(ApiEndPoints.Author.GetAll)]
        public Task<IEnumerable<Author>> Get()
        {
            return _authorService.GetAuthors();
        }

        [HttpGet(ApiEndPoints.Author.Get)]
        public async Task<Author?> getById([FromRoute] Guid id)
        {
            var author = await _authorService.GetById(id);

            return author;
        }

        [HttpPut(ApiEndPoints.Author.Update)]
        public async Task<IActionResult> update([FromBody] UpdateAuthorRequestModel updateAuthorRequest, [FromRoute] Guid id)
        {
            var result =  updateAuthorRequest.MapToAuthorUpdate(id);

            if (result == null)
            {
                return Ok("not found");
            }
            var author = await _authorService.Update(result,id);

            return Ok("Seccessfull update");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete([FromRoute] Guid  id)
        {
            var author = await _authorService.Delete(id);

            if (author == false)
            {
                return Ok("Not found");
            }
            return Ok("Seccessfull delete");
        }
    }
}
