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
        private MummyContext context { get; set; }
        private IWantMyMummyContext wantContext;
        private UserManager<IWantMyMummyUser> userManager;



        public BurialsController(MummyContext ctx, UserManager<IWantMyMummyUser> tempUser, IWantMyMummyContext con)
        {
            context = ctx;
            userManager = tempUser;
            wantContext = con;
        }

        // GET: Burials
        public IActionResult Index(string locationNS, int pageNum = 1)
        { 
            int pageSize = 2;
            ViewBag.LocationNS = locationNS;
            
            
            var role = wantContext.UserRoles
                        .Where(r => r.UserId == userManager.GetUserId(User))
                        .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            var partialResult = (from b in context.Burial
                                 join bsquare in context.BurialSquare

                                 on b.BurialSquareId equals bsquare.BurialSquareId
                                 select new JoinBurialSquareViewModel
                                 {
                                    Burials = b,
                                    BurialSquare = bsquare,
                                 })
                                 .Where(x => x.BurialSquare.BurialLocationNs == locationNS || locationNS == null)
                                 .Skip((pageNum - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();

            var mummyContext = context.Burial.Include(b => b.BurialS).Include(b => b.BurialSquare);
            ViewBag.mummy = mummyContext.ToList();
            
            return View(new BurialsViewModel
            {
                JoinBurialSquareViewModel = partialResult,
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    TotalNumItems = context.Burial.Count()
                },

                LocationNS = locationNS,
            }
                );
            //return View(new BurialsViewModel
            //                {   Burials = _context.Burial
            //                                .Skip((pageNum - 1) * pageSize)
            //                                .Take(pageSize)
            //                                .ToList(),

            //                    PageNumberingInfo = new PageNumberingInfo
            //                    {
            //                        NumItemsPerPage = pageSize,
            //                        CurrentPage = pageNum,

            //                        TotalNumItems = _context.Burial.Count()
            //                    },

            //                    LocationNS = locationNS,

                                
            //                });
        }

        // GET: Burials/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var role = wantContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            if (id == null)
            {
                return NotFound();
            }

            var burial = await context.Burial
                .Include(b => b.BurialS)
                .Include(b => b.BurialSquare)
                .FirstOrDefaultAsync(m => m.BurialId == id);

            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        // GET: Burials/Create
        public IActionResult Create()
        {
            var role = wantContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            ViewData["BurialSubplot"] = new SelectList(context.BurialQuadrant, "BurialSubplot", "BurialSubplot");
            ViewData["BurialSquareId"] = new SelectList(context.BurialSquare, "BurialSquareId", "BurialSquareId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var role = wantContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            if (ModelState.IsValid)
            {
                context.Add(burial);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Create1", burial);
        }
        //on get for create1 (will be deleteing Create Actions and using Create1,2,3 etc)
        public IActionResult Create1()
        {
            var role = wantContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            ViewData["BurialSubplot"] = new SelectList(context.BurialQuadrant, "BurialSubplot", "BurialSubplot");
            ViewData["BurialSquareId"] = new SelectList(context.BurialSquare, "BurialSquareId", "BurialSquareId");

            BurialInformationViewModel viewModel = new BurialInformationViewModel
            {
                BurialSquare = context.BurialSquare.ToList(),
                BurialQuadrantsList = context.BurialQuadrant.ToList(),
                Burial = new Burial { },
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create1(string SelectedSquareId, string BurialSubplot, int BurialNumber,
            int BurialDepth, int SouthToHead, int SouthToFeet, int WestToHead, int WestToFeet, string BurialSituation,
            string BurialWrapping, string BurialWrappingMaterial, bool BurialAdult, int LengthOfRemains, int SampleNumber,
            string GenderGe, bool SexMethodSkull, double GeFunctionTotal, string HeadDirection)
        {
            BurialInformationViewModel viewModel = new BurialInformationViewModel
            {
                BurialSquare = context.BurialSquare.ToList(),
                BurialQuadrantsList = context.BurialQuadrant.ToList(),
                Burial = new Burial {
                    BurialSquareId = SelectedSquareId,
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
                },
                //SelectedSquareId = SelectedSquareId,
                //BurialSubplot = BurialSubplot,
                //BurialNumber = BurialNumber,
                //BurialDepth = BurialDepth,
                //SouthToHead = SouthToHead,
                //SouthToFeet = SouthToFeet,
                //WestToHead = WestToHead,
                //WestToFeet = WestToFeet,
                //BurialSituation = BurialSituation,
                //BurialWrapping = BurialWrapping,
                //BurialWrappingMaterial = BurialWrappingMaterial,
                //BurialAdult = BurialAdult,
                //LengthOfRemains = LengthOfRemains,
                //SampleNumber = SampleNumber,
                //GenderGe = GenderGe,
                //SexMethodSkull = SexMethodSkull,
                //GeFunctionTotal = GeFunctionTotal,
                //HeadDirection = HeadDirection,
            }; 

            Burial burial = new Burial
            {
                BurialSquareId = SelectedSquareId,
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
                       
            return RedirectToAction("Create", burial);
        }
        //Create new burial WITH a subplot
        public IActionResult CreateWith(string SelectedSquareId)
        {
            SelectedSquareId = SelectedSquareId.Replace("%2F", "/");
            ViewBag.Sid = SelectedSquareId;
            BurialInformationViewModel viewModel = new BurialInformationViewModel
            {
                BurialSquare = context.BurialSquare.ToList(),
                BurialQuadrantsList = context.BurialQuadrant.ToList(),
                Burial = new Burial { },
            };
            return View(viewModel);
        }

        //Create new burial WITHOUT a subplot
        public IActionResult CreateWithout(string SelectedSquareId)
        {
            SelectedSquareId = SelectedSquareId.Replace("%2F", "/");
            ViewBag.Sid = SelectedSquareId;

            return View();
        }

        public IActionResult CreateAdditional(string SelectedSquareId, string BurialSubplot, int BurialNumber,
            int BurialDepth, int SouthToHead, int SouthToFeet, int WestToHead, int WestToFeet, string BurialSituation,
            string BurialWrapping, string BurialWrappingMaterial, bool BurialAdult, int LengthOfRemains, int SampleNumber,
            string GenderGe, bool SexMethodSkull, double GeFunctionTotal, string HeadDirection)
        {
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
                BurialSquare = context.BurialSquare.ToList(),
                BurialQuadrantsList = context.BurialQuadrant.ToList(),
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
            var role = wantContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            if (id == null)
            {
                return NotFound();
            }

            var burial = await context.Burial.FindAsync(id);
            if (burial == null)
            {
                return NotFound();
            }
            ViewData["BurialSubplot"] = new SelectList(context.BurialQuadrant, "BurialSubplot", "BurialSubplot", burial.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(context.BurialSquare, "BurialSquareId", "BurialSquareId", burial.BurialSquareId);
            return View(burial);
        }

        // POST: Burials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurialId,BurialNumber,BurialSubplot,BurialSquareId,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,BurialWrapping,BurialWrappingMaterial,BurialAdult,LengthOfRemains,SampleNumber,GenderGe,SexMethodSkull,GeFunctionTotal,GenderBodyCol,HeadDirection,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,DateFound,AgeAtDeath,AgeMethodSkull")] Burial burial)
        {
            var role = wantContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            if (id != burial.BurialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(burial);
                    await context.SaveChangesAsync();
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
            ViewData["BurialSubplot"] = new SelectList(context.BurialQuadrant, "BurialSubplot", "BurialSubplot", burial.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(context.BurialSquare, "BurialSquareId", "BurialSquareId", burial.BurialSquareId);
            return View(burial);
        }

        // GET: Burials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var role = wantContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            } 

            if (id == null)
            {
                return NotFound();
            }

            var burial = await context.Burial
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
            var burial = await context.Burial.FindAsync(id);
            context.Burial.Remove(burial);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialExists(int id)
        {
            var role = wantContext.UserRoles
               .Where(r => r.UserId == userManager.GetUserId(User))
               .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            return context.Burial.Any(e => e.BurialId == id);
        }
    }
}
