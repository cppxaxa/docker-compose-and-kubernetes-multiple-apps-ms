using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationQueryLib
{
    public interface ILocationQueryClient
    {
        ILocationQueryExamples GetExamples();
        ILocationQueryResponse Query(ILocationQueryRequest request);
    }
}
