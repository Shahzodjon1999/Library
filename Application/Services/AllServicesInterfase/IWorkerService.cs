using Application.RequestModels;
using Application.ResponsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AllServicesInterfase
{
    public interface IWorkerService
    {
        Task<WorkersResponse> GetWorkers();

        Task Create(CreateWorkerRequestModel worker);

        Task Update(UpdateWorkerRequestModel worker, Guid id);

        Task Delete(Guid id);

        Task<WorkerResponse?> GetById(Guid id);
    }
}
