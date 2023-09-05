using Application.RequestModels;
using Application.ResponsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AllServicesInterfase
{
    public interface ICustomerService
    {
        Task<CustomersResponse> GetCustomers();

        Task Create(CreateCustomerRequestModel customer);

        Task Update(UpdateCustomerRequestModel customer, Guid id);

        Task Delete(Guid id);

        Task<CustomerResponse?> GetById(Guid id);
    }
}
