using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponsModels.AuthorResponsModel
{
    public class AuthorResponse
    {
        public Guid id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<Book> Books { get; set; }
    }
}
