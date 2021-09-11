using LocationQueryLib;

namespace LocationQueryLib
{
    public class LocationQueryRequest : ILocationQueryRequest
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Miles { get; set; }
    }
}