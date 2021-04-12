using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models
{
    public class Sort
    {
        public string SortString { get; set; }

        public string SortDepth { get; set; }

        public Sort (string sort)
        {
            SortString = sort ?? "all";

            string[] sortString = SortString.Split("-");
            SortDepth = sortString[0];


        }

        public bool HasSortDepth => SortDepth.ToLower() != "all";
    }
}
