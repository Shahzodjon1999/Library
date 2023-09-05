using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damen.Models
{
    public class RentBook
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public Guid BookId { get; set; }

        public int countBook { get; set; }

        public DateTime GiveBookDate { get; set; }

        public DateTime TakeBookDate { get; set; }
    }
}
