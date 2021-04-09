using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace IWantMyMummy.Models
{
    public partial class BurialQuadrant
    {
        public BurialQuadrant()
        {
            Burial = new HashSet<Burial>();
            Image = new HashSet<Image>();
        }

        public string BurialSquareId { get; set; }
        public string BurialSubplot { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
        public virtual ICollection<Image> Image { get; set; }
    }
}
