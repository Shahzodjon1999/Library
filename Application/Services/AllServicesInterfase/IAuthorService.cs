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
    public interface IAuthorService
    {
        Task<AuthorsRespons> GetAuthors();

        Task Create(CreateAuthorRequestModel author);

        Task Update(UpdateAuthorRequestModel author,Guid id);

        Task Delete(Guid id);

        Task<AuthorResponse?> GetById(Guid id);
    }
}
