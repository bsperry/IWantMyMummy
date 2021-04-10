using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IWantMyMummy.Models
{
    public partial class RackSample
    {
        public RackSample()
        {
            CranialSample = new HashSet<CranialSample>();
        }

        public string RackShelf { get; set; }
        public string RackNumber { get; set; }
        public bool IsBag { get; set; }
        public int BurialId { get; set; }
        public int TubeNumber { get; set; }
        public string RankDescription { get; set; }
        public int MlSize { get; set; }
        public int Foci { get; set; }
        public string LocationNotes { get; set; }
        public string Questions { get; set; }
        public int Conventional14cAgeBp { get; set; }
        public int _14cCalendarDay { get; set; }
        public int Calibrated95CalendarDateMax { get; set; }
        public int Calibrated95CalendarDateMin { get; set; }
        public int Calibrated95CalendarDateSpan { get; set; }
        public string Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }

        public virtual Burial Burial { get; set; }
        public virtual ICollection<CranialSample> CranialSample { get; set; }
    }
}
