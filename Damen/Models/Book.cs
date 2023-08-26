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

        public string AuthorId { get; set; }=string.Empty;

        public string CategoryId { get; set; }=string.Empty;

        public int Count { get; set; }
    }
}
