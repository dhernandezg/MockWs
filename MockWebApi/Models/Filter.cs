using System;
using System.Collections.Generic;

namespace MockWebApi.Models
{
    [Serializable]
    public class Filter
    {
        public List<string> Contains { get; set; }
    }
}