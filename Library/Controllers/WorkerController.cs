using Application.RequestModels;
using Application.ResponsModels;
using Application.Services.AllServicesInterfase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet(ApiEndPoints.Worker.GetAll)]
        public async Task<ActionResult<WorkersResponse>> GetAll()
        {
            try
            {
                return await _workerService.GetWorkers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet(ApiEndPoints.Worker.Get)]
        public async Task<ActionResult<WorkerResponse?>> Get([FromRoute] Guid id)
        {
            try
            {
                if (id != null)
                {
                    return await _workerService.GetById(id);
                }
                return BadRequest("You didn't enter id");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost(ApiEndPoints.Worker.Create)]
        public async Task<IActionResult> Create([FromBody] CreateWorkerRequestModel Request)
        {
            try
            {
                if (Request is null)
                {
                    return BadRequest("this method has null exseption");
                }
                await _workerService.Create(Request);

                return Ok("Seccessful Added");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete(ApiEndPoints.Worker.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                if (id != null)
                {
                    await _workerService.Delete(id);

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
