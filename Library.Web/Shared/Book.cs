using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Web.Shared
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Guid AuthorId { get; set; }

        public Guid CategoryId { get; set; }

        public int Count { get; set; }
    }
}
