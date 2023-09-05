using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Damen.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Author Author { get; set; }

        public Guid AuthorId { get; set; }

        public Category Category { get; set; }

        public Guid CategoryId { get; set; }

        public int Count { get; set; }
    }
}
