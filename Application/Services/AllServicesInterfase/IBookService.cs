using Application.RequestModels.BookRequestModels;
using Application.ResponsModels.BookResponsModel;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.BooksServices
{
    public interface IBookService
    {
        Task<BooksResponse> GetBooks();

        Task Create(CreateBookRequestModel book);

        Task Update(UpdateBookRequestModel book, Guid id);

        Task Delete(Guid id);

        Task<BookResponse?> GetById(Guid id);
    }
}
