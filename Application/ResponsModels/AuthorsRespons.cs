using Damen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponsModels.AuthorResponsModel
{
    public class AuthorsRespons
    {
        public IEnumerable<AuthorResponse> Items { get; set; }
    }
}
