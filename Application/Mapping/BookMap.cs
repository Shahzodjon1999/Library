using Application.RequestModels.BookRequestModels;
using Application.ResponsModels.BookResponsModel;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.BookMapping
{
    public static class BookMap
    {
        public static Book MapToBookCreate(this CreateBookRequestModel  createBookRequest)
        {
            Book book = new Book
            { 
                Id = Guid.NewGuid(),

                Name = createBookRequest.Name,

                AuthorId = createBookRequest.AuthorId,

                CategoryId = createBookRequest.CategoryId,

                Count = createBookRequest.Count,
            };

            return book;
        }

        public static Book MapToBookUpdate(this UpdateBookRequestModel updateBookRequest, Guid id)
        {
            return new Book
            {
                Id = id,

                Name = updateBookRequest.Name,

                AuthorId = updateBookRequest.AuthorId,

                CategoryId = updateBookRequest.CategoryId,

                Count = updateBookRequest.Count,
            };
        }
        public static BookResponse MapToBook(this Book book)
        {
            return new BookResponse
            {
                Id = book.Id,

                Name = book.Name,

                AuthorId = book.AuthorId,

                CategoryId = book.CategoryId,

                Count = book.Count
            };
        }

        public static BooksResponse MapToBooks(this IEnumerable<Book> booksIEnumrable)
        {
            return new BooksResponse
            {
                Books = booksIEnumrable.Select(MapToBook)
            };
        }
    }
}
