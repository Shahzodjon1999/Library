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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Create(CreateCustomerRequestModel customer)
        {
            try
            {
                var mapCustomer = customer.MapToCreate();

                await _customerRepository.Create(mapCustomer);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Service has null exseption" + ex);
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                await _customerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Service has null exseption" + ex);
            }
        }

        public async Task<CustomerResponse?> GetById(Guid id)
        {
            try
            {
                var customer =await  _customerRepository.GetById(id);
                
                return customer.MapToCustomer();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Service has null exseption" + ex);
            }
        }

        public async Task<CustomersResponse> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAll();

                return customers.MapToCustumers();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Service has null exseption" + ex);
            }
        }

        public async Task Update(UpdateCustomerRequestModel customer, Guid id)
        {
            try
            {
                var customerMap = customer.MapToUpdate(id);

                await _customerRepository.Update(customerMap);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Customer Service has null exseption" + ex);
            }
        }
    }
}
