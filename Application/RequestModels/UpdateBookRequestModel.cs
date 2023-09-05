using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RequestModels.BookRequestModels
{
    public class UpdateBookRequestModel
    {
        public string Name { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public Guid CategoryId { get; set; }

        public int Count { get; set; }
    }
}
