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
        public bool BurialAdult { get; set; }
        public int LengthOfRemains { get; set; }
        public int SampleNumber { get; set; }
        public string GenderGe { get; set; }
        public bool SexMethodSkull { get; set; }
        public double GeFunctionTotal { get; set; }
        public string HeadDirection { get; set; }


        //Additional info
        public string GenderBodyCol { get; set; }
        public bool BasilarSuture { get; set; }
        public int VentralArc { get; set; }
        public int SubpubicAngle { get; set; }
        public int SciaticNotch { get; set; }
        public int PubicBone { get; set; }
        public int PreaurSulcus { get; set; }
        public int MedialIpRamus { get; set; }
        public int DorsalPitting { get; set; }
        public double ForemanMagnum { get; set; }
        public double FemurHead { get; set; }
        public double HumerusHead { get; set; }
        public int Osteophytosis { get; set; }
        public int PubicSymphysis { get; set; }
        public double FemurLength { get; set; }
        public double HumerusLength { get; set; }
        public double TibiaLength { get; set; }
        public int Robust { get; set; }
        public int SupraorbitalRidges { get; set; }
        public int OrbitEdge { get; set; }
        public int ParietalBossing { get; set; }
        public int Gonian { get; set; }
        public int NuchalCrest { get; set; }
        public int ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public double MaximumCranialLength { get; set; }
        public double MaximumCranialBreadth { get; set; }
        public double BasionBregmaHeight { get; set; }
        public double BasionNasion { get; set; }
        public double BasionProsthionLength { get; set; }
        public double BizygomaticDiameter { get; set; }
        public double NasionProsthion { get; set; }
        public double MaximumNasalBreadth { get; set; }
        public double InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public int PreservationIndex { get; set; }
        public bool HairTaken { get; set; }
        public bool SoftTissueTaken { get; set; }
        public bool BoneTaken { get; set; }
        public bool ToothTaken { get; set; }
        public bool TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool ArtifactFound { get; set; }
        public double EstimateAge { get; set; }
        public double EstimateLivingStature { get; set; }
        public int ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public bool EpiphysealUnion { get; set; }
        public DateTime DateFound { get; set; }
        public string AgeAtDeath { get; set; }
        public bool AgeMethodSkull { get; set; }




    }
}


