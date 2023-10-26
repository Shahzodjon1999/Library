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
    public class RentBookService : IRentBookService
    {
        private readonly IRentBookRepository _rentBookRepository;

        public RentBookService(IRentBookRepository rentBookRepository)
        {
            _rentBookRepository = rentBookRepository;
        }

        public async Task Create(CreateRentBookRequestModel rentbook)
        {
            try
            {
                var mapRentBook = rentbook.MapToCreate();

               await _rentBookRepository.Create(mapRentBook);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookService has null exseption" + ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
               await _rentBookRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookService has null exseption" + ex);
            }
        }

        public async Task<RentBooksResponse> GetRentBooks()
        {
            try
            {
              var rentBooks = await _rentBookRepository.GetAll();

                return rentBooks.MapToRentBooks();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookService has null exseption" + ex);
            }
        }

        public async Task<RentBookResponse?> GetById(Guid id)
        {
            try
            {
                var rentBook =await _rentBookRepository.GetById(id);

                return rentBook?.MapToRentBook();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookService has null exseption" + ex);
            }
        }

        public async Task Update(UpdateRentBookRequestModel rentbook, Guid id)
        {
            try
            {
                var rentBookUpdate = rentbook.MapToUpdate(id);

               await _rentBookRepository.Update(rentBookUpdate);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("RentBookService has null exseption" + ex);
            }
        }
    }
}
