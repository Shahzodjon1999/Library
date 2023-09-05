using Application.Mapping.AuthorMapping;
using Application.RequestModels.AuthorRequestModels;
using Application.ResponsModels.AuthorResponsModel;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthorsService
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Create(CreateAuthorRequestModel authorREquest)
        {
            try
            {
                if (authorREquest.Name == null)
                {
                    throw new NullReferenceException($"Author was null! {authorREquest}");
                }

                var author = authorREquest.MapToAuthor();

                await _authorRepository.Create(author);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Author service has exception in Create method()" + ex.Message);
            }
           
        }

        public async Task<AuthorsRespons> GetAuthors()
        {
            try
            {
                var authors =await _authorRepository.GetAllAuthor();

                return  authors.MapToAuthorAllResponse();
            }
            catch (Exception ex)
            {
                throw new Exception("Author service has exception in getAuthors method()" + ex.Message);
            }
           
        }

        public async Task<AuthorResponse?> GetById(Guid id)
        {
            try
            {
                var author = await _authorRepository.GetById(id);

                var result = author?.MapToAuthorResponse();

                return result;
            }
            catch (Exception)
            {
                throw new NullReferenceException("AuthorService has method() doesn't get Author");
            }
        }

        public async Task Update(UpdateAuthorRequestModel author,Guid id)
        {
            try
            {
                var updateRequestMap = author.MapToAuthorUpdate(id);

                await _authorRepository.Update(updateRequestMap);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("AuthorService has method() doesn't Update");
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _authorRepository.Delete(id);
            }
            catch (Exception)
            {
                throw new NullReferenceException("AuthorService has method() doesn't Delete");
            }
          
        }
    }
}
