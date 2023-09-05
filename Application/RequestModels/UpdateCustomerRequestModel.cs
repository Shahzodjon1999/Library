using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RequestModels
{
    public class UpdateCustomerRequestModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string NumberPhone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }
    }
}
