using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models
{
    public class FilterLocation
    {

        public string FilterString { get; set; }
        public string LocationNs { get; set; }
        public string LowPairNs { get; set; }

        public FilterLocation (string filterstring)
        {
            FilterString = filterstring ?? "all-all";
            string[] filters = FilterString.Split("-");
            LocationNs = filters[0];
            LowPairNs = filters[1];
        }

        public bool HasLocationNs => LocationNs.ToLower() != "all";
        public bool HasLowPairNs => LowPairNs.ToLower() != "all";
    }
}
