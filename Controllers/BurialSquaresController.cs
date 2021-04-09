using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWantMyMummy.Models;
using IWantMyMummy.Data;
using IWantMyMummy.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace IWantMyMummy.Controllers
{
    public class BurialSquaresController : Controller
    {
        private readonly MummyContext _context;
        private IWantMyMummyContext mummyContext;
        private UserManager<IWantMyMummyUser> userManager;

        public BurialSquaresController(MummyContext context, IWantMyMummyContext con, UserManager<IWantMyMummyUser> tempUser)
        {
            _context = context;
            mummyContext = con;
            userManager = tempUser;
            
        }

        // GET: BurialSquares
        public async Task<IActionResult> Index()
        {
            var role = (mummyContext.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault());

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }
            return View(await _context.BurialSquare.ToListAsync());
        }

        // GET: BurialSquares/Details/5
        public async Task<IActionResult> Details(string id)
        {
            id = id.Replace("%2F", "/");
            if (id == null)
            {
                return NotFound();
            }

            var burialSquare = await _context.BurialSquare
                .FirstOrDefaultAsync(m => m.BurialSquareId == id);
            if (burialSquare == null)
            {
                return NotFound();
            }

            return View(burialSquare);
        }

        // GET: BurialSquares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BurialSquares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialSquareId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw")] BurialSquare burialSquare)
        {
            string strLowNS = burialSquare.LowPairNs.ToString();
            string strHighNS = burialSquare.HighPairNs.ToString();
            string strLowEW = burialSquare.LowPairEw.ToString();
            string strHighEW = burialSquare.HighPairEw.ToString();


            burialSquare.BurialSquareId = burialSquare.BurialLocationNs + " " + strLowNS + "/" + strHighNS + " " + burialSquare.BurialLocationEw + " " + strLowEW + "/" + strHighEW;

            if (ModelState.IsValid)
            {
                _context.Add(burialSquare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burialSquare);
        }

        // GET: BurialSquares/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            id = id.Replace("%2F", "/");

            if (id == null)
            {
                return NotFound();
            }

            var burialSquare = await _context.BurialSquare.FindAsync(id);
            if (burialSquare == null)
            {
                return NotFound();
            }
            string strFid = id.Replace("/", "F");
            ViewBag.Fid = strFid; 

            return View(burialSquare);
        }

        // POST: BurialSquares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BurialSquareId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw")] BurialSquare burialSquare)
        {
            id = id.Replace("F", "/");
            burialSquare.BurialSquareId = burialSquare.BurialSquareId.Replace("F", "/");


            if (id != burialSquare.BurialSquareId)
            {
                return NotFound();
            }

           if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burialSquare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialSquareExists(burialSquare.BurialSquareId))
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
            return View(burialSquare);
        }

        // GET: BurialSquares/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            id = id.Replace("%2F", "/");
            if (id == null)
            {
                return NotFound();
            }

            var burialSquare = await _context.BurialSquare
                .FirstOrDefaultAsync(m => m.BurialSquareId == id);
            if (burialSquare == null)
            {
                return NotFound();
            }

            string strFid = id.Replace("/", "F");
            ViewBag.Fid = strFid;

            return View(burialSquare);
        }

        // POST: BurialSquares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            id = id.Replace("F", "/");
            var burialSquare = await _context.BurialSquare.FindAsync(id);
            _context.BurialSquare.Remove(burialSquare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialSquareExists(string id)
        {
            return _context.BurialSquare.Any(e => e.BurialSquareId == id);
        }
    }
}
