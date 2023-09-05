using Application.Mapping.BookMapping;
using Application.Repositories.BookRepo;
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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Create(CreateBookRequestModel createBookRequest)
        {
            try
            {
                if (createBookRequest.Name != null)
                {
                    var creatBookReq = createBookRequest.MapToBookCreate();

                    await _bookRepository.Create(creatBookReq);
                }
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Book service has exception in Create method()" + ex.Message);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _bookRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Book service has exception in delete method()" + ex.Message);
            }

        }

        public async Task<BooksResponse> GetBooks()
        {
            try
            {
                var bookResponse = await _bookRepository.GetAllBooks();

                var books = bookResponse.MapToBooks();

                return books;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Book service has exception in getall method()" + ex.Message);
            }

        }

        public async Task<BookResponse?> GetById(Guid id)
        {
            try
            {
                var book = await _bookRepository.GetById(id);

                var result = book?.MapToBook();

                return result;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Book service has exception in getall method()" + ex.Message);
            }

        }

        public async Task Update(UpdateBookRequestModel updateBookRequest, Guid id)
        {
            try
            {
                var bookRequest = updateBookRequest.MapToBookUpdate(id);

                await _bookRepository.Update(bookRequest);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Book service has exception in getall method()" + ex.Message);
            }

        }
    }
}
