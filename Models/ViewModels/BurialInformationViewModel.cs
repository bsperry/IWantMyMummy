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

        //not using currently   public List<string> Subplots { get; set; }
        
        public Burial Burial { get; set; }
        public string SelectedSquareId { get; set; }
        public string BurialSubplot { get; set; }
        public int BurialNumber { get; set; }
        public int BurialDepth { get; set; }
        public int SouthToHead { get; set; }
        public int SouthToFeet { get; set; }
        public int WestToHead { get; set; }
        public int WestToFeet { get; set; }
        public string BurialSituation { get; set; }
        public string BurialWrapping { get; set; }
        public string BurialWrappingMaterial { get; set; }
        public bool BurialAdult{ get; set; }
        public int LengthOfRemains { get; set; }
        public int SampleNumber { get; set; }
        public string GenderGe{ get; set; }
        public bool SexMethodSkull { get; set; }
        public double GeFunctionTotal { get; set; }
        public string HeadDirection { get; set; }




    }
}
