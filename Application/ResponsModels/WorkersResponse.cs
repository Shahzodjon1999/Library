using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponsModels
{
    public class WorkersResponse
    {
        public IEnumerable<WorkerResponse> Workers { get; set; }
    }
}
