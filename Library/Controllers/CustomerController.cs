using Application.RequestModels;
using Application.ResponsModels;
using Application.Services.AllServicesInterfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(ApiEndPoints.Customer.GetAll)]
        public async Task<ActionResult<CustomersResponse>> GetAll()
        {
            try
            {
              return await  _customerService.GetCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(ApiEndPoints.Customer.Get)]
        public async Task<ActionResult<CustomerResponse?>> Get([FromRoute] Guid id)
        {
            try
            {
                if (id != null)
                {
                  return  await _customerService.GetById(id);
                }
                return BadRequest("You didn't enter id");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(ApiEndPoints.Customer.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequestModel createCustomerRequest)
        {
            try
            {
                if (createCustomerRequest is null)
                {
                    return BadRequest("this method has null exseption");
                }
               await _customerService.Create(createCustomerRequest);

                return Ok("Seccessful Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(ApiEndPoints.Customer.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                if (id != null)
                {
                    await _customerService.Delete(id);

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
