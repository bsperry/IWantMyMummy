using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IWantMyMummy.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public int? BurialId { get; set; }
        public string BurialSquareId { get; set; }
        public string BurialSubplot { get; set; }
        public int? CranialId { get; set; }
        public byte[] Image1 { get; set; }
        public string ImagePath { get; set; }
        public string ImageDescription { get; set; }

        public virtual Burial Burial { get; set; }
        public virtual BurialQuadrant BurialS { get; set; }
        public virtual BurialSquare BurialSquare { get; set; }
        public virtual CranialSample Cranial { get; set; }
    }
}
