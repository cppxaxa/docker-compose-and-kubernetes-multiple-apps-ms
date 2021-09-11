using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LocationQueryLib
{
    public class LocationQueryClient : ILocationQueryClient
    {
        private readonly string nearbyPlacesSourceHost = "localhost";
        private readonly string nearbyPlacesSourceHostPort = "8001";

        public LocationQueryClient()
        {

        }

        public LocationQueryClient(string nearbyPlacesSourceHost, string nearbyPlacesSourceHostPort)
        {
            this.nearbyPlacesSourceHost = nearbyPlacesSourceHost;
            this.nearbyPlacesSourceHostPort = nearbyPlacesSourceHostPort;
        }

        public ILocationQueryExamples GetExamples()
        {
            return new LocationQueryExamples
            {
                Examples = new List<string>
                {
                    JsonConvert.SerializeObject(new LocationQueryExample {
                        Lat = 20.1,
                        Lon = 73.1,
                        Miles = 2
                    })
                }
            };
        }

        public ILocationQueryResponse Query(ILocationQueryRequest request)
        {
            IDataSource dataSource = new NearbyPlacesSource(host: nearbyPlacesSourceHost, port: nearbyPlacesSourceHostPort);
            return dataSource.Query(request);
        }
    }
}
