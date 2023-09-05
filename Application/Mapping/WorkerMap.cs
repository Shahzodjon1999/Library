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
    public static class WorkerMap
    {
        public static Worker MapToCreate(this CreateWorkerRequestModel createWorker)
        {
            return new Worker()
            {
                id = Guid.NewGuid(),

                FirstName = createWorker.FirstName,

                LastName = createWorker.LastName,

                Address = createWorker.Address,

                UserName = createWorker.UserName,

                Password = createWorker.Password,

                NumberPhone = createWorker.NumberPhone,

                DateTime = createWorker.DateTime
            };
        }

        public static Worker MapToUpdate(this UpdateWorkerRequestModel updateWorkerRequest,Guid  guid)
        {
            return new Worker()
            {
                id =guid,

                FirstName = updateWorkerRequest.FirstName,

                LastName = updateWorkerRequest.LastName,

                Address = updateWorkerRequest.Address,

                UserName = updateWorkerRequest.UserName,

                Password = updateWorkerRequest.Password,

                NumberPhone = updateWorkerRequest.NumberPhone,

                DateTime = updateWorkerRequest.DateTime
            };
        }

        public static WorkerResponse MapToRespons(this Worker worker)
        {
            return new WorkerResponse()
            {
                id =worker.id,

                FirstName = worker.FirstName,

                LastName = worker.LastName,

                Address = worker.Address,

                UserName = worker.UserName,

                Password = worker.Password,

                NumberPhone = worker.NumberPhone,

                DateTime = worker.DateTime
            };
        }

        public static WorkersResponse MapToResponse(this IEnumerable<Worker> workers)
        {
            return  new WorkersResponse()
            {
                Workers = workers.Select(MapToRespons)
            }; 
        }
    }
}
