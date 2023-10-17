using Application.Mapping;
using Application.Mapping.AuthorMapping;
using Application.RequestModels.AuthorRequestModels;
using Application.ResponsModels.AuthorResponsModel;
using Application.Services;
using Application.Services.AuthorsService;
using Damen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Authorize]
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
            try
            {
               await _authorService.Create(createAuthorRequest);

                return Ok("Seccessfull added");
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("AuthorController doesn't add createRequest in method create()" + ex.Message);
            }
        }

        [HttpGet(ApiEndPoints.Author.GetAll)]
        public Task<AuthorsRespons> Get()
        {
            try
            {
                var result = _authorService.GetAuthors();

                return result;
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("AuthorController doesn't find Authors in method Get()");
            }        
         }

        [HttpGet(ApiEndPoints.Author.Get)]
        public async Task<AuthorResponse?> getById([FromRoute] Guid id)
        {
            try
            {
                var author = await _authorService.GetById(id);

                return author;
            }
            catch (Exception)
            {
                throw new NullReferenceException("AuthorController doesn't find id in method getById()");
            }
            
        }

        [HttpPut(ApiEndPoints.Author.Update)]
        public async Task<IActionResult> update([FromBody] UpdateAuthorRequestModel updateAuthorRequest, [FromRoute] Guid id)
        {
            try
            {
                if (updateAuthorRequest != null)
                {
                    await _authorService.Update(updateAuthorRequest, id);

                    return Ok("Seccessfull update");
                }
                return Ok("not found");
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("AuthorController doesn't find updateRequest in method update()");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete([FromRoute] Guid  id)
        {
            try
            {
                if (id != null)
                {
                    await _authorService.Delete(id);

                    return Ok("Seccessfull delete");
                }
                return Ok("Not found");
            }
            catch (Exception)
            {
                throw new IndexOutOfRangeException("AuthorController doesn't find id");
            }

            
        }
    }
}
