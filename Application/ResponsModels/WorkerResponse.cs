using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponsModels
{
    public class WorkerResponse
    {
        public Guid id { get; set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; } 

        public string NumberPhone { get; set; } 

        public string Address { get; set; }

        public string UserName { get; set; } 

        public string Password { get; set; } 

        public DateTime DateTime { get; set; }
    }
}
