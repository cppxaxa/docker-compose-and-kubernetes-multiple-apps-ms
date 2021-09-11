namespace LocationQueryLib
{
    public interface ILocationQueryRequest
    {
        double Lat { get; }
        double Lon { get; }
        int Miles { get; }
    }
}