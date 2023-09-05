using Application.Mapping.BookMapping;
using Application.RequestModels.BookRequestModels;
using Application.ResponsModels.BookResponsModel;
using Application.Services.BooksServices;
using Damen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    public class BookController:ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost(ApiEndPoints.Book.Create)]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestModel createBookRequest)
        {
            try
            {
                if (createBookRequest.Name != null)
                {
                    await _bookService.Create(createBookRequest);

                    return Ok("Seccessfull added");
                }
                return BadRequest("createBookRequest.Name has null in the Create method");
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("BookController has null in the create method");
            }
           
        }

        [HttpGet(ApiEndPoints.Book.GetAll)]
        public async Task<BooksResponse> GetAll()
        {
            try
            {
                var books = await _bookService.GetBooks();

                return books;
            }
            catch (Exception)
            {
                throw new NullReferenceException("BookController has null in the getAll method");
            }
          
        }

        [HttpGet(ApiEndPoints.Book.Get)]
        public async Task<BookResponse> GetById([FromRoute] Guid id)
        {
            try
            {
                var book = await _bookService.GetById(id);

                return book;
            }
            catch (Exception)
            {
                throw new NullReferenceException("BookController has null in the getById method");
            }
           
        }

        [HttpPut(ApiEndPoints.Book.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateBookRequestModel updateBookRequest,Guid id)
        {
            try
            {
                await _bookService.Update(updateBookRequest, id);

                return Ok("Seccessfull update");
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("BookController has null in the update method");
            }
            
             
        }

        [HttpDelete(ApiEndPoints.Book.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _bookService.Delete(id);

                return Ok("Seccessfull Deleted");
            }
            catch (Exception)
            {
                throw new NullReferenceException("BookController has null in the delete method");
            } 
        }
    }
}
