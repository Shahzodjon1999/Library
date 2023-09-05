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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ContractDbContext _contractDbContext;

        public CustomerRepository(ContractDbContext contractDbContext)
        {
            _contractDbContext = contractDbContext;
        }

        public async Task Create(Customer customer)
        {
            try
            {
                _contractDbContext.Customers.Add(customer);

               await _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Repository has null" + ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                _contractDbContext.Customers.SingleOrDefault(i=>i.id ==id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Repository has null" + ex);
            }

        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
               return _contractDbContext.Customers.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Repository has null" + ex);
            }

        }

        public async Task<Customer?> GetById(Guid id)
        {
            try
            {
               return _contractDbContext.Customers.FirstOrDefault(i => i.id == id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Repository has null" + ex);
            }
        }

        public async Task Update(Customer customer)
        {
            try
            {
               _contractDbContext.Customers.Update(customer);

              await  _contractDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Repository has null" + ex);
            }

        }
    }
}
