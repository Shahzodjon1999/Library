using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RequestModels
{
    public class CreateRentBookRequestModel
    {
        public Guid CustomerId { get; set; }

        public Guid BookId { get; set; }

        public int countBook { get; set; }

        public DateTime GiveBookDate { get; set; }

        public DateTime TakeBookDate { get; set; }
    }
}
