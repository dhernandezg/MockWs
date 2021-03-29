using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MockWebApi.Models
{
    [Serializable, XmlRoot("MockServer")]
    public class ConfigRoutes
    {
        public List<Route> DinamycMock { get; set; }
    }
}