using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MockWebApi.Models
{
    [Serializable]
    public class RequestMock
    {
        [XmlArray("Filters"), XmlArrayItem(typeof(string), ElementName = "Contains")]
        public List<string> Filters { get; set; }
    }
}