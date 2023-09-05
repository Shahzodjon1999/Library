using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponsModels.BookResponsModel
{
    public class BooksResponse
    {
        public IEnumerable<BookResponse> Books { get; set; }=Enumerable.Empty<BookResponse>();
    }
}
