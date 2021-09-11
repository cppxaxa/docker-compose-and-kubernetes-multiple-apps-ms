namespace LocationQueryLib
{
    internal interface IDataSource
    {
        ILocationQueryResponse Query(ILocationQueryRequest request);
    }
}