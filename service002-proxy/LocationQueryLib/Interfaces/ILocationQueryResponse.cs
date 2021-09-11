using System.Collections.Generic;

namespace LocationQueryLib
{
    public interface ILocationQueryResponse
    {
        string Error { get; set; }
        List<Place> Places { get; set; }
    }
}