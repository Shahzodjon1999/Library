using Application.RequestModels.AuthorRequestModels;
using Application.ResponsModels.AuthorResponsModel;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.AuthorMapping
{
    public static class AuthorMap
    {
        public static Author MapToAuthor(this CreateAuthorRequestModel authorRequestModel)
        {
            return new Author
            {
                id = Guid.NewGuid(),

                Name = authorRequestModel.Name,
            };
        }

        public static AuthorResponse MapToAuthorResponse(this Author author)
        {
            return new AuthorResponse
            {
                id = author.id,

                Name = author.Name,

                Books=author.Books,
            };
        }

        public static AuthorsRespons MapToAuthorAllResponse(this IEnumerable<Author> authors)
        {
            return new AuthorsRespons
            {
                Items = authors.Select(MapToAuthorResponse)
            };
        }

        public static Author MapToAuthorUpdate(this UpdateAuthorRequestModel updateAuthorRequest, Guid id)
        {
            return new Author
            {
                id = id,

                Name = updateAuthorRequest.Name,
            };
        }
    }
}
