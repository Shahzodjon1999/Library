using Application.Repositories;
using Damen.Models;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoriesInfrastucture
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly ContractDbContext _contractDbContext;

        public WorkerRepository(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;
        }

        public async Task Create(Worker worker)
        {
            try
            {
                await _contractDbContext.Workerss.AddAsync(worker);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Worker Repository has null" + ex);
            }

        }

        public async Task Delete(Guid id)
        {
            try
            {
              var worker =  _contractDbContext.Workerss.FirstOrDefault(i => i.id == id);

                _contractDbContext.Remove(worker);

                await _contractDbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Worker Repository has null" + ex);
            }
        }

        public async Task<IEnumerable<Worker>> GetAll()
        {
            try
            {
                return _contractDbContext.Workerss.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Worker Repository has null" + ex);
            }
        }

        public async Task<Worker?> GetById(Guid id)
        {
            try
            {
                return _contractDbContext.Workerss.FirstOrDefault(i => i.id == id);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Worker Repository has null" + ex);
            }
        }

        public async Task Update(Worker worker)
        {
            try
            {
                _contractDbContext.Update(worker);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Worker Repository has null" + ex);
            }
        }
    }
}
