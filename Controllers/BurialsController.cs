using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWantMyMummy.Models;
using Microsoft.AspNetCore.Identity;
using IWantMyMummy.Areas.Identity.Data;
using IWantMyMummy.Data;

namespace IWantMyMummy.Controllers
{
    public class BurialsController : Controller
    {
        private MummyContext _context { get; set; }
        private IWantMyMummyContext wantContext;
        private UserManager<IWantMyMummyUser> userManager;




        public BurialsController(MummyContext context, UserManager<IWantMyMummyUser> tempUser, IWantMyMummyContext con)
        {
            _context = context;
            userManager = tempUser;
            wantContext = con;
        }

        // GET: Burials
        public IActionResult Index()
        {
            int pageSize = 5;
            
            
            var role = wantContext.UserRoles
                        .Where(r => r.UserId == userManager.GetUserId(User))
                        .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }



            var mummyContext = _context.Burial.Include(b => b.BurialS).Include(b => b.BurialSquare);
            return View(mummyContext
                        .OrderByDescending(x => x.DateFound)
                );
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

            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot");
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId");
            return View();
        }

        // POST: Burials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialId,BurialNumber,BurialSubplot,BurialSquareId,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,BurialWrapping,BurialWrappingMaterial,BurialAdult,LengthOfRemains,SampleNumber,GenderGe,SexMethodSkull,GeFunctionTotal,GenderBodyCol,HeadDirection,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForemanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,DateFound,AgeAtDeath,AgeMethodSkull")] Burial burial)
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
                _context.Add(burial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot", burial.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId", burial.BurialSquareId);
            return View(burial);
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

            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot");
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId");
            return View();
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
            var role = wantContext.UserRoles
               .Where(r => r.UserId == userManager.GetUserId(User))
               .FirstOrDefault();

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            return _context.Burial.Any(e => e.BurialId == id);
        }
    }
}
