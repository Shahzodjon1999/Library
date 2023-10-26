using Application.RequestModels;
using Application.ResponsModels;
using Application.Services.AllServicesInterfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentBookController : ControllerBase
    {
        private readonly IRentBookService _rentBookService;

        public RentBookController(IRentBookService rentBookService)
        {
            _rentBookService = rentBookService;
        }

        [HttpGet(ApiEndPoints.RentBook.GetAll)]
        public async Task<ActionResult<RentBooksResponse>> GetAll()
        {
            try
            {
                return await _rentBookService.GetRentBooks();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(ApiEndPoints.RentBook.Get)]
        public async Task<ActionResult<RentBookResponse?>> Get([FromRoute] Guid id)
        {
            try
            {
                if (id != null)
                {
                    return await _rentBookService.GetById(id);
                }
                return BadRequest("You didn't enter id");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(ApiEndPoints.RentBook.Create)]
        public async Task<IActionResult> Create([FromBody] CreateRentBookRequestModel Request)
        {
            try
            {
                if (Request is null)
                {
                    return BadRequest("this method has null exseption");
                }
                await _rentBookService.Create(Request);

                return Ok("Seccessful Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(ApiEndPoints.RentBook.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                if (id != null)
                {
                    await _rentBookService.Delete(id);

                    return Ok("Seccessfull delete");
                }
                return BadRequest("Don't enter Id");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
