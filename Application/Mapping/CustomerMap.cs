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
    public static class CustomerMap
    {
        public static Customer MapToCreate(this CreateCustomerRequestModel createCustomerRequest)
        {
            return new Customer()
            {
                id = Guid.NewGuid(),

                FirstName = createCustomerRequest.FirstName,

                LastName = createCustomerRequest.LastName,

                Address = createCustomerRequest.Address,

                NumberPhone = createCustomerRequest.NumberPhone,

                DateTime = createCustomerRequest.DateTime
            };
        }

        public static Customer MapToUpdate(this UpdateCustomerRequestModel updateCustomerRequest,Guid guid)
        {
            return new Customer()
            {
                id = Guid.NewGuid(),

                FirstName = updateCustomerRequest.FirstName,

                LastName = updateCustomerRequest.LastName,

                Address = updateCustomerRequest.Address,

                NumberPhone = updateCustomerRequest.NumberPhone,

                DateTime = updateCustomerRequest.DateTime
            };
        }

        public static CustomerResponse MapToCustomer(this Customer customer)
        {
            return new CustomerResponse()
            {
                id = Guid.NewGuid(),

                FirstName = customer.FirstName,

                LastName = customer.LastName,

                Address = customer.Address,

                NumberPhone = customer.NumberPhone,

                DateTime = customer.DateTime
            };
        }

        public static CustomersResponse MapToCustumers(this IEnumerable<Customer> customers)
        {
            return new CustomersResponse()
            {
                Customers = customers.Select(MapToCustomer)
            };
        }
    }
}
