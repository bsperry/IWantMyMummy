using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IWantMyMummy.Models
{
    public partial class CranialSample
    {
        public CranialSample()
        {
            Image = new HashSet<Image>();
        }

        public int CranialId { get; set; }
        public int BurialId { get; set; }
        public int SampleNumber { get; set; }
        public string RackShelf { get; set; }
        public string RackNumber { get; set; }
        public double MaxCranialLength { get; set; }
        public double MaxCranialBreadth { get; set; }
        public double BasionBregmaHeight { get; set; }
        public double BasionNasion { get; set; }
        public double BasionProsthionLength { get; set; }
        public double BizgomaticDiameter { get; set; }
        public double NasionProsthion { get; set; }
        public double MaxNasalBreadth { get; set; }
        public double InterobitalBreadth { get; set; }

        public virtual Burial Burial { get; set; }
        public virtual RackSample Rack { get; set; }
        public virtual ICollection<Image> Image { get; set; }
    }
}
