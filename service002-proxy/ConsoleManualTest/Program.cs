using LocationQueryLib;
using Newtonsoft.Json;
using System;

namespace ConsoleManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new LocationQueryClient();
            Console.WriteLine(JsonConvert.SerializeObject(client.GetExamples(), Formatting.Indented));

            Console.WriteLine(JsonConvert.SerializeObject(client.Query(new LocationQueryRequest
            {
                Lat = 20.1,
                Lon = 73.1,
                Miles = 2
            }), Formatting.Indented));
        }
    }
}
