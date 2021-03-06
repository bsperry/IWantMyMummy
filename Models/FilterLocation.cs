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
        public string HighPairNs { get; set; }
        public string LocationEw { get; set; }
        public string LowPairEw { get; set; }
        public string HighPairEw { get; set; }
        public string SubPlotFilter { get; set; }

        public string Gender { get; set; }

        //Mummy Characteristics
        public string HeadDirection { get; set; }
        public string AdultChild { get; set; }


        public FilterLocation (string filterstring)
        {
            FilterString = filterstring ?? "all-all-all-all-all-all-all-all-all-all";
            string[] filters = FilterString.Split("-");
            LocationNs = filters[0];
            LowPairNs = filters[1];
            HighPairNs = filters[2];
            LocationEw = filters[3];
            LowPairEw = filters[4];
            HighPairEw = filters[5];
            SubPlotFilter = filters[6];

            //Other filters (I'd prefer to add them to a different class, but for time issues, let's not overcomplicate things)
            Gender = filters[7];

            //Mummy Characteristics
            HeadDirection = filters[8];
            AdultChild = filters[9];

        }

        public bool HasLocationNs => LocationNs.ToLower() != "all";
        public bool HasLowPairNs => LowPairNs.ToLower() != "all";
        public bool HasHighPairNs => HighPairNs.ToLower() != "all";
        public bool HasLocationEw => LocationEw.ToLower() != "all";
        public bool HasLowPairEw => LowPairEw.ToLower() != "all";
        public bool HasHighPairEw => HighPairEw.ToLower() != "all";
        public bool HasSubPlot => SubPlotFilter.ToLower() != "all";

        public bool HasGender => Gender.ToLower() != "all";
        public bool HasHeadDirection => HeadDirection.ToLower() != "all";
        public bool HasAdultChild => AdultChild.ToString().ToLower() != "all";

    }
}
