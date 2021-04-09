using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWantMyMummy.Models;
using IWantMyMummy.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using IWantMyMummy.Areas.Identity.Data;
using IWantMyMummy.Data;

namespace IWantMyMummy.Controllers
{
    public class BurialQuadrantsController : Controller
    {
        private readonly MummyContext _context;
        private UserManager<IWantMyMummyUser> userManager;
        private IWantMyMummyContext mummyContext;

        public BurialQuadrantsController(MummyContext context, IWantMyMummyContext con, UserManager<IWantMyMummyUser> tempUser)
        {
            _context = context;
            mummyContext = con;
            userManager = tempUser;
        }

        // GET: BurialQuadrants
        public async Task<IActionResult> Index()
        {
            var role = (mummyContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault());

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            return View(await _context.BurialQuadrant.ToListAsync());
        }

        // GET: BurialQuadrants/Details/5
        public async Task<IActionResult> Details(string id, string subid)
        {
            id = id.Replace("%2F", "/");

            if (id == null|| subid ==null)
            {
                return NotFound();
            }

            var burialQuadrant = _context.BurialQuadrant.Where(x => x.BurialSquareId == id && x.BurialSubplot == subid).First();
            //var burialQuadrant = await _context.BurialQuadrant.FirstOrDefaultAsync(m => m.BurialSubplot == id);
            if (burialQuadrant == null)
            {
                return NotFound();
            }

            return View(burialQuadrant);
        }

        // GET: BurialQuadrants/Create
        public IActionResult Create()
        {
            //before view model
            //return View();
            //with view model

            List<string> AvailableSubplots = new List<string> {"NE","NW", "SE", "SW" };
            ViewBag.AvailPlots = AvailableSubplots;
            //List<string> uniqueList = new List<string> { };
            //ViewBag.UniqueList = uniqueList;

            return View(new BurialInformationViewModel
            {
                BurialSquare = _context.BurialSquare.ToList(),
                BurialQuadrant = new BurialQuadrant { 
                    BurialSquareId = "",
                    BurialSubplot = "",
                },
                BurialQuadrantsList = _context.BurialQuadrant.ToList(),
                // not using currently Subplots = {},
            });
        }

        // POST: BurialQuadrants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialSquareId,BurialSubplot")] BurialQuadrant burialQuadrant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(burialQuadrant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burialQuadrant);
        }

       //No one gets to edit the Quadrants


        // GET: BurialQuadrants/Delete/5 only admin can do this function
        public async Task<IActionResult> Delete(string id,string subid)
        {
            id = id.Replace("%2F", "/");

            if (id == null || subid==null)
            {
                return NotFound();
            }

            var burialQuadrant = _context.BurialQuadrant.Where(x => x.BurialSquareId == id && x.BurialSubplot == subid).First();

            if (burialQuadrant == null)
            {
                return NotFound();
            }

            string strFid = id.Replace("/", "F");
            ViewBag.Fid = strFid;

            return View(burialQuadrant);
        }

        // POST: BurialQuadrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id, string subid)
        {
            id = id.Replace("F", "/");

            var burialQuadrant = _context.BurialQuadrant.Where(x => x.BurialSquareId == id && x.BurialSubplot == subid).First();
            _context.BurialQuadrant.Remove(burialQuadrant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialQuadrantExists(string id)
        {
            return _context.BurialQuadrant.Any(e => e.BurialSubplot == id);
        }
    }
}
