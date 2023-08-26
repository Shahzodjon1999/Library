using Application.RequestModels.AuthorRequestModels;
using Application.ResponsModels.AuthorResponsModel;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public static class ContractMapping
    {
        public static Author MapToAuthor(this CreateAuthorRequestModel authorRequestModel)
        {
            return new Author
            {
                id= Guid.NewGuid(),

                Name = authorRequestModel.Name,

                BookId = authorRequestModel.BookId,
            };
        }

        public static AuthorResponse MapToAuthorResponse(this Author author)
        {
            return new AuthorResponse
            {
                id = author.id,

                Name = author.Name,

                BookId = author.BookId,
            };
        }

        public static AuthorsRespons MapToAuthorAllResponse(this IEnumerable<Author> authors)
        {
            return new AuthorsRespons
            {
                Items = authors.Select(MapToAuthorResponse)
            };
        }

        //public static Author MaToAuthor1(this UpdateAuthorRequestModel updateAuthorRequest, Guid guid)
        //{
        //    return new Author
        //    {
        //        id = guid,

        //        Name = updateAuthorRequest.Name,

        //        BookId = updateAuthorRequest.BookId
        //    };
        //}


    }
}
