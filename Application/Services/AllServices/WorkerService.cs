using Application.Mapping;
using Application.Repositories;
using Application.RequestModels;
using Application.ResponsModels;
using Application.Services.AllServicesInterfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AllServices
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task Create(CreateWorkerRequestModel worker)
        {
            try
            {
                var workerMap = worker.MapToCreate();

               await  _workerRepository.Create(workerMap);

            }
            catch (Exception ex)
            {
                throw new NullReferenceException("WorkerService has null exseption" + ex);
            }
            
        }

        public async Task Delete(Guid id)
        {
            try
            {
              await  _workerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("WorkerService has null exseption" + ex);
            }
        }

        public async Task<WorkerResponse?> GetById(Guid id)
        {
            try
            {
                var worker = await _workerRepository.GetById(id);

               return  worker?.MapToRespons();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("WorkerService has null exseption" + ex);
            }

        }

        public async Task<WorkersResponse> GetWorkers()
        {
            try
            {
                var workers =await _workerRepository.GetAllCategories();

               return workers.MapToResponse();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("WorkerService has null exseption" + ex);
            }
        }

        public async Task Update(UpdateWorkerRequestModel worker, Guid id)
        {
            try
            {
                var workerRequest = worker.MapToUpdate(id);

                await _workerRepository.Update(workerRequest);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("WorkerService has null exseption" + ex);
            }
        }
    }
}
