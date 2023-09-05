using Application.RequestModels;
using Application.ResponsModels;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public static class RentBookMap
    {
        public static RentBook MapToCreate(this CreateRentBookRequestModel  createRentBookRequest)
        {
            return  new RentBook()
            {
                Id = Guid.NewGuid(),

                CustomerId = createRentBookRequest.CustomerId,

                BookId = createRentBookRequest.BookId,

                countBook = createRentBookRequest.countBook,

                GiveBookDate = createRentBookRequest.GiveBookDate,

                TakeBookDate = createRentBookRequest.TakeBookDate
            };
        }

        public static RentBook MapToUpdate(this UpdateRentBookRequestModel updateRentBookRequest,Guid guid)
        {
            return new RentBook()
            {
                Id = guid,

                CustomerId = updateRentBookRequest.CustomerId,

                BookId = updateRentBookRequest.BookId,

                countBook = updateRentBookRequest.countBook,

                GiveBookDate = updateRentBookRequest.GiveBookDate,

                TakeBookDate = updateRentBookRequest.TakeBookDate
            };
        }

        public static RentBookResponse MapToRentBook(this RentBook rentBook)
        {
            return new RentBookResponse()
            {
                Id = rentBook.Id,

                CustomerId = rentBook.CustomerId,

                BookId = rentBook.BookId,

                countBook = rentBook.countBook,

                GiveBookDate = rentBook.GiveBookDate,

                TakeBookDate = rentBook.TakeBookDate
            };
        }

        public static RentBooksResponse MapToRentBooks(this IEnumerable<RentBook> rentBooks)
        {
            return new RentBooksResponse()
            {
                RentBooks = rentBooks.Select(MapToRentBook)
            };
        }
    }
}
