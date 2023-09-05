using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponsModels
{
    public class CustomersResponse
    {
        public IEnumerable<CustomerResponse> Customers { get; set; }
    }
}
