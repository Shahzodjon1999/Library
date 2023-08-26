using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damen.Models
{
    public class Customer : Person
    {
        public Guid id { get; set; }

        public string FirstName { get; set; }=string.Empty;

        public string LastName { get; set; }= string.Empty;

        public string NumberPhone { get; set; } = string.Empty;

        public string Address { get; set ; }=string.Empty;

        public DateTime DateTime { get; set; }
    }
}
