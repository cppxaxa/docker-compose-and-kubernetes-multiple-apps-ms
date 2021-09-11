using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace LocationQueryLib
{
    public class NearbyPlacesSource : IDataSource
    {
        private string host;
        private string port;

        public NearbyPlacesSource(string host, string port)
        {
            this.host = host;
            this.port = port;
        }

        public ILocationQueryResponse Query(ILocationQueryRequest request)
        {
            try
            {
                var client = new HttpClient();
                var futureResponseString = client.GetStringAsync($"http://{this.host}:{this.port}/fetch_places_nearby?lat={request.Lat}&lon={request.Lon}&miles={request.Miles}");
                futureResponseString.Wait(new TimeSpan(0, 0, 20));

                if (!futureResponseString.IsCompleted)
                {
                    return new LocationQueryResponse
                    {
                        Error = "Timeout"
                    };
                }

                return new LocationQueryResponse
                {
                    Places = JsonConvert.DeserializeObject<List<Place>>(futureResponseString.Result)
                };
            }
            catch (Exception ex)
            {
                return new LocationQueryResponse
                {
                    Error = ex.Message + ex
                };
            }
        }
    }
}