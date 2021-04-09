using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models.ViewModels
{
    public class BurialInformationViewModel
    {
        public List<BurialSquare> BurialSquare { get; set; }
        public BurialQuadrant BurialQuadrant { get; set; }
        
        public List<BurialQuadrant> BurialQuadrantsList { get; set; }

        public List<string> Subplots { get; set; }

    }
}
