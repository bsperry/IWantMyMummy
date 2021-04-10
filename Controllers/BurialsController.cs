using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWantMyMummy.Models;
using Microsoft.AspNetCore.Identity;
using IWantMyMummy.Data;
using IWantMyMummy.Models.ViewModels;
using IWantMyMummy.Areas.Identity.Data;


namespace IWantMyMummy.Controllers
{
    public class BurialsController : Controller
    {
        private MummyContext _context { get; set; }
        private IWantMyMummyContext wantContext;
        private UserManager<IWantMyMummyUser> userManager;



        public BurialsController(MummyContext ctx, UserManager<IWantMyMummyUser> tempUser, IWantMyMummyContext con)
        {
            _context = ctx;
            userManager = tempUser;
            wantContext = con;
        }

        // GET: Burials
        // GET: Burials
        public IActionResult Index(string filterId, int pageNum = 1)
        {
            int pageSize = 5;
            //ViewBag.LocationNS = locationNS;

            var role = wantContext.UserRoles
                        .Where(r => r.UserId == userManager.GetUserId(User))
                        .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }



            //var partialResult = (from b in _context.Burial
            //                     join bsquare in _context.BurialSquare

            //                     on b.BurialSquareId equals bsquare.BurialSquareId
            //                     select new JoinBurialSquareViewModel
            //                     {
            //                        Burials = b,
            //                        BurialSquare = bsquare,
            //                     })
            //                     .Where(x => x.BurialSquare.BurialLocationNs == locationNS || locationNS == null)
            //                     .Skip((pageNum - 1) * pageSize)
            //                     .Take(pageSize)
            //                     .ToList();

            var queryFilter = (from b in _context.Burial
                               join bsquare in _context.BurialSquare

                               on b.BurialSquareId equals bsquare.BurialSquareId
                               select new JoinBurialSquareViewModel
                               {
                                   Burials = b,
                                   BurialSquare = bsquare,
                               });


            var test = _context.Burial;


            var filterLoc = new FilterLocation(filterId);
            ViewBag.FilterString = filterId;
            ViewBag.FilterLoc = filterLoc;
            ViewBag.LocationNStemp = _context.BurialSquare
                                      .Select(b => b.BurialLocationNs)
                                      .Distinct()
                                      .ToList();
            ViewBag.LowPairNs = _context.BurialSquare
                                      .Select(b => b.LowPairNs)
                                      .Distinct()
                                      .ToList();
            ViewBag.HighPairNs = _context.BurialSquare
                                      .Select(b => b.HighPairNs)
                                      .Distinct()
                                      .ToList();
            ViewBag.LocationEw = _context.BurialSquare
                                      .Select(b => b.BurialLocationEw)
                                      .Distinct()
                                      .ToList();
            ViewBag.LowPairEw = _context.BurialSquare
                                      .Select(b => b.LowPairEw)
                                      .Distinct()
                                      .ToList();
            ViewBag.HighPairEw = _context.BurialSquare
                                      .Select(b => b.HighPairEw)
                                      .Distinct()
                                      .ToList();
            ViewBag.Gender = _context.Burial
                                      .Select(b => b.GenderGe)
                                      .Distinct()
                                      .ToList();


            if (filterLoc.HasLocationNs)
            {
                queryFilter = queryFilter.Where(b => b.BurialSquare.BurialLocationNs == filterLoc.LocationNs);
            }

            if (filterLoc.HasLowPairNs)
            {
                queryFilter = queryFilter.Where(b => b.BurialSquare.LowPairNs.ToString() == filterLoc.LowPairNs);
            }

            if (filterLoc.HasHighPairNs)
            {
                queryFilter = queryFilter.Where(b => b.BurialSquare.HighPairNs.ToString() == filterLoc.HighPairNs);
            }

            if (filterLoc.HasLocationEw)
            {
                queryFilter = queryFilter.Where(b => b.BurialSquare.BurialLocationEw == filterLoc.LocationEw);
            }
            if (filterLoc.HasLowPairEw)
            {
                queryFilter = queryFilter.Where(b => b.BurialSquare.LowPairEw.ToString() == filterLoc.LowPairEw);
            }
            if (filterLoc.HasHighPairEw)
            {
                queryFilter = queryFilter.Where(b => b.BurialSquare.HighPairEw.ToString() == filterLoc.HighPairEw);
            }
            if (filterLoc.HasGender)
            {
                queryFilter = queryFilter.Where(b => b.Burials.GenderGe == filterLoc.Gender);
            }

            var mummyContext = _context.Burial.Include(b => b.BurialS).Include(b => b.BurialSquare);
            ViewBag.mummy = mummyContext
                            .ToList();

            return View(new BurialsViewModel
            {
                JoinBurialSquareViewModel = queryFilter
                                            .Skip((pageNum - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList(),
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    Query = filterId,

                    TotalNumItems = queryFilter.Count()
                },

            }
                );
        }

        //FILTERING
        [HttpPost]
        public IActionResult FilterLoc(string[] filter)
        {
            string filterId = string.Join('-', filter);
            int pageNum = 1;
            return RedirectToAction("Index", new { filterId, pageNum });
        }

        // GET: Burials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burial
                .Include(b => b.BurialS)
                .Include(b => b.BurialSquare)
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        //POST: Burials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        public async Task<IActionResult> Create([Bind("BurialId,BurialNumber,BurialSubplot,BurialSquareId,BurialDepth," +
            "SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,BurialWrapping,BurialWrappingMaterial," +
            "BurialAdult,LengthOfRemains,SampleNumber,GenderGe,SexMethodSkull,GeFunctionTotal,GenderBodyCol,HeadDirection," +
            "BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting," +
            "ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust," +
            "SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength," +
            "MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion," +
            "MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,HairTaken,SoftTissueTaken," +
            "BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition," +
            "ToothEruption,PathologyAnomalies,EpiphysealUnion,DateFound,AgeAtDeath,AgeMethodSkull")] Burial burial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Create1", burial);
        }
        //on get for create1 (will be deleteing Create Actions and using Create1,2,3 etc)
        public IActionResult Create1()
        {
            BurialInformationViewModel viewModel = new BurialInformationViewModel
            {
                BurialSquare = _context.BurialSquare.ToList(),
                BurialQuadrantsList = _context.BurialQuadrant.ToList(),
                Burial = new Burial { },
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create1(string Addition, string SelectedSquareId, string BurialSubplot, int BurialNumber,
            int BurialDepth, int SouthToHead, int SouthToFeet, int WestToHead, int WestToFeet, string BurialSituation,
            string BurialWrapping, string BurialWrappingMaterial, bool BurialAdult, int LengthOfRemains, int SampleNumber, string GenderGe,

            bool SexMethodSkull, double GeFunctionTotal, string HeadDirection, string GenderBodyCol, bool BasilarSuture,
            int VentralArc, int SubpubicAngle, int SciaticNotch, int PubicBone, int PreaurSulcus, int MedialIpRamus, int DorsalPitting,
            double ForemanMagnum, double FemurHead, double HumerusHead, int Osteophytosis, int PubicSymphysis, double FemurLength,
            double HumerusLength, double TibiaLength, int Robust, int SupraorbitalRidges, int OrbitEdge, int ParietalBossing, int Gonian,
            int NuchalCrest, int ZygomaticCrest, string CranialSuture, double MaximumCranialLength, double MaximumCranialBreadth,
            double BasionBregmaHeight, double BasionNasion, double BasionProsthionLength, double BizygomaticDiameter, double NasionProsthion,
            double MaximumNasalBreadth, double InterorbitalBreadth, string ArtifactsDescription, string HairColor, int PreservationIndex,
            bool HairTaken, bool SoftTissueTaken, bool BoneTaken, bool ToothTaken, bool TextileTaken, string DescriptionOfTaken, bool ArtifactFound,
            double EstimateAge, double EstimateLivingStature, int ToothAttrition, string ToothEruption, string PathologyAnomalies, bool EpiphysealUnion,
            DateTime DateFound, string AgeAtDeath, bool AgeMethodSkull)
            
        {

            Burial burial = new Burial();

           
                burial.BurialSquareId = SelectedSquareId;
                burial.BurialSubplot = BurialSubplot;
                burial.BurialNumber = BurialNumber;
                burial.BurialDepth = BurialDepth;
                burial.SouthToHead = SouthToHead;
                burial.SouthToFeet = SouthToFeet;
                burial.WestToHead = WestToHead;
                burial.WestToFeet = WestToFeet;
                burial.BurialSituation = BurialSituation;
                burial.BurialWrapping = BurialWrapping;
                burial.BurialWrappingMaterial = BurialWrappingMaterial;
                burial.BurialAdult = BurialAdult;
                burial.LengthOfRemains = LengthOfRemains;
                burial.SampleNumber = SampleNumber;
                burial.GenderGe = GenderGe;
                
            
                if (Addition == "Additional")
                {

                    burial.SexMethodSkull = SexMethodSkull;
                    burial.GeFunctionTotal = GeFunctionTotal;
                    burial.HeadDirection = HeadDirection;
                    burial.GenderBodyCol = GenderBodyCol;
                    burial.BasilarSuture = BasilarSuture;
                    burial.VentralArc = VentralArc;
                    burial.SubpubicAngle = SubpubicAngle;
                    burial.SciaticNotch = SciaticNotch;
                    burial.PubicBone = PubicBone;
                    burial.PreaurSulcus = PreaurSulcus;
                    burial.MedialIpRamus = MedialIpRamus;
                    burial.DorsalPitting = DorsalPitting;
                    burial.ForemanMagnum = ForemanMagnum;
                    burial.FemurHead = FemurHead;
                    burial.HumerusHead = HumerusHead;
                    burial.Osteophytosis = Osteophytosis;
                    burial.PubicSymphysis = PubicSymphysis;
                    burial.FemurLength = FemurLength;
                    burial.HumerusLength = HumerusLength;
                    burial.TibiaLength = TibiaLength;
                    burial.Robust = Robust;
                    burial.SupraorbitalRidges = SupraorbitalRidges;
                    burial.OrbitEdge = OrbitEdge;
                    burial.ParietalBossing = ParietalBossing;
                    burial.Gonian = Gonian;
                    burial.NuchalCrest = NuchalCrest;
                    burial.ZygomaticCrest = ZygomaticCrest;
                    burial.CranialSuture = CranialSuture;
                    burial.MaximumCranialLength = MaximumCranialLength;
                    burial.MaximumCranialBreadth = MaximumCranialBreadth;
                    burial.BasionBregmaHeight = BasionBregmaHeight;
                    burial.BasionNasion = BasionNasion;
                    burial.BasionProsthionLength = BasionProsthionLength;
                    burial.BizygomaticDiameter = BizygomaticDiameter;
                    burial.NasionProsthion = NasionProsthion;
                    burial.MaximumNasalBreadth = MaximumNasalBreadth;
                    burial.InterorbitalBreadth = InterorbitalBreadth;
                    burial.ArtifactsDescription = ArtifactsDescription;
                    burial.HairColor = HairColor;
                    burial.PreservationIndex = PreservationIndex;
                    burial.HairTaken = HairTaken;
                    burial.SoftTissueTaken = SoftTissueTaken;
                    burial.BoneTaken = BoneTaken;
                    burial.ToothTaken = ToothTaken;
                    burial.TextileTaken = TextileTaken;
                    burial.DescriptionOfTaken = DescriptionOfTaken;
                    burial.ArtifactFound = ArtifactFound;
                    burial.EstimateAge = EstimateAge;
                    burial.EstimateLivingStature = EstimateLivingStature;
                    burial.ToothAttrition = ToothAttrition;
                    burial.ToothEruption = ToothEruption;
                    burial.PathologyAnomalies = PathologyAnomalies;
                    burial.EpiphysealUnion = EpiphysealUnion;
                    burial.DateFound = DateFound;
                    burial.AgeAtDeath = AgeAtDeath;
                    burial.AgeMethodSkull = AgeMethodSkull;
                }
                   

            return RedirectToAction("Create", burial);
        }


        //Create new burial WITH a subplot
        public IActionResult CreateWith(string SelectedSquareId)
        {
            SelectedSquareId = SelectedSquareId.Replace("%2F", "/");
            ViewBag.Sid = SelectedSquareId;
            ViewBag.CreateParam = "NoAdditional";
            BurialInformationViewModel viewModel = new BurialInformationViewModel
            {
                BurialSquare = _context.BurialSquare.ToList(),
                BurialQuadrantsList = _context.BurialQuadrant.ToList(),
                Burial = new Burial { },
            };
            return View(viewModel);
        }

        //Create new burial WITHOUT a subplot
        public IActionResult CreateWithout(string SelectedSquareId)
        {
            SelectedSquareId = SelectedSquareId.Replace("%2F", "/");
            ViewBag.CreateParam = "NoAdditional";

            ViewBag.Sid = SelectedSquareId;
            return View();
        }

        public IActionResult CreateAdditional(string SelectedSquareId, string BurialSubplot, int BurialNumber,
            int BurialDepth, int SouthToHead, int SouthToFeet, int WestToHead, int WestToFeet, string BurialSituation,
            string BurialWrapping, string BurialWrappingMaterial, bool BurialAdult, int LengthOfRemains, int SampleNumber,
            string GenderGe, bool SexMethodSkull, double GeFunctionTotal, string HeadDirection)
        {
            ViewBag.CreateParam = "Additional";

            SelectedSquareId = SelectedSquareId.Replace("%2F", "/");
            ViewBag.BurialSquareId = SelectedSquareId;
            ViewBag.BurialSubplot = BurialSubplot;
            ViewBag.BurialNumber = BurialNumber;
            ViewBag.BurialDepth = BurialDepth;
            ViewBag.SouthToHead = SouthToHead;
            ViewBag.SouthToFeet = SouthToFeet;
            ViewBag.WestToHead = WestToHead;
            ViewBag.WestToFeet = WestToFeet;
            ViewBag.BurialSituation = BurialSituation;
            ViewBag.BurialWrapping = BurialWrapping;
            ViewBag.BurialWrappingMaterial = BurialWrappingMaterial;
            ViewBag.BurialAdult = BurialAdult;
            ViewBag.LengthOfRemains = LengthOfRemains;
            ViewBag.SampleNumber = SampleNumber;
            ViewBag.GenderGe = GenderGe;
            ViewBag.SexMethodSkull = SexMethodSkull;
            ViewBag.GeFunctionTotal = GeFunctionTotal;
            ViewBag.HeadDirection = HeadDirection;

            BurialInformationViewModel viewModel = new BurialInformationViewModel
            {
                BurialSquare = _context.BurialSquare.ToList(),
                BurialQuadrantsList = _context.BurialQuadrant.ToList(),
                Burial = new Burial { },
                SelectedSquareId = SelectedSquareId,
                BurialSubplot = BurialSubplot,
                BurialNumber = BurialNumber,
                BurialDepth = BurialDepth,
                SouthToHead = SouthToHead,
                SouthToFeet = SouthToFeet,
                WestToHead = WestToHead,
                WestToFeet = WestToFeet,
                BurialSituation = BurialSituation,
                BurialWrapping = BurialWrapping,
                BurialWrappingMaterial = BurialWrappingMaterial,
                BurialAdult = BurialAdult,
                LengthOfRemains = LengthOfRemains,
                SampleNumber = SampleNumber,
                GenderGe = GenderGe,
                SexMethodSkull = SexMethodSkull,
                GeFunctionTotal = GeFunctionTotal,
                HeadDirection = HeadDirection,
            };
            return View(viewModel);
        }
        // GET: Burials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burial.FindAsync(id);
            if (burial == null)
            {
                return NotFound();
            }
            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot", burial.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId", burial.BurialSquareId);
            return View(burial);
        }

        // POST: Burials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurialId,BurialNumber,BurialSubplot,BurialSquareId,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,BurialWrapping,BurialWrappingMaterial,BurialAdult,LengthOfRemains,SampleNumber,GenderGe,SexMethodSkull,GeFunctionTotal,GenderBodyCol,HeadDirection,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,DateFound,AgeAtDeath,AgeMethodSkull")] Burial burial)
        {
            if (id != burial.BurialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialExists(burial.BurialId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot", burial.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId", burial.BurialSquareId);
            return View(burial);
        }

        // GET: Burials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burial
                .Include(b => b.BurialS)
                .Include(b => b.BurialSquare)
                .FirstOrDefaultAsync(m => m.BurialId == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        // POST: Burials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burial = await _context.Burial.FindAsync(id);
            _context.Burial.Remove(burial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialExists(int id)
        {
            return _context.Burial.Any(e => e.BurialId == id);
        }
    }
}