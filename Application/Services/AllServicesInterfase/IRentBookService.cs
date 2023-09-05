using Application.RequestModels;
using Application.ResponsModels;
using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AllServicesInterfase
{
    public interface IRentBookService
    {
        Task<RentBooksResponse> GetAuthors();

        Task Create(CreateRentBookRequestModel rentbook);

        Task Update(UpdateRentBookRequestModel rentbook, Guid id);

        Task Delete(Guid id);

        Task<RentBookResponse?> GetById(Guid id);
    }
}
