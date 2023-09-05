using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomers();

        Task Create(Customer customer);

        Task Update(Customer  customer);

        Task Delete(Guid id);

        Task<Customer?> GetById(Guid id);
    }
}
