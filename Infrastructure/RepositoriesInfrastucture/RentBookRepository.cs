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
    public class RentBookRepository : IRentBookRepository
    {
        private readonly ContractDbContext _contractDbContext;

        public RentBookRepository(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;
        }

        public async Task Create(RentBook rentBook)
        {
            try
            {
                _contractDbContext.RentBooks.Add(rentBook);

              await  _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookRepository has null exseption" + ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var rentbook = _contractDbContext.RentBooks.SingleOrDefault(i => i.Id == id);

                 _contractDbContext.RentBooks.Remove(rentbook);

                await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookRepository has null exseption" + ex);
            }
        }

        public async Task<IEnumerable<RentBook>> GetAllRentBook()
        {
            try
            {
                return  _contractDbContext.RentBooks.AsEnumerable();

            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookRepository has null exseption" + ex);
            }
        }

        public async Task<RentBook?> GetById(Guid id)
        {
            try
            {
                return  _contractDbContext.RentBooks.FirstOrDefault(i => i.Id == id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookRepository has null exseption" + ex);
            }
        }

        public async Task Update(RentBook rentBook)
        {
            try
            {
                _contractDbContext.RentBooks.Update(rentBook);

               await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookRepository has null exseption" + ex);
            }
        }
    }
}
