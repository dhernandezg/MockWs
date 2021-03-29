using System;

namespace MockWebApi.Models
{
    [Serializable]
    public class Route
    {
        public string PartialPath { get; set; }
        public RequestMock Request { get; set; }
        public ResponseMock Response { get; set; }
    }
}