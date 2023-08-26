using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damen.Models
{
     public abstract class Person
    {
        public Guid id { get; set; }

        public  string FirstName { get; set; }=string.Empty;

        public string LastName { get; set; }

        public string NumberPhone { get; set; }

        public string Address { get; set; }

        public DateTime DateTime { get; set; }
    }
}
