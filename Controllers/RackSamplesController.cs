using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWantMyMummy.Models;
using IWantMyMummy.Models.ViewModels;
using IWantMyMummy.Data;
using IWantMyMummy.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;




namespace IWantMyMummy.Controllers
{
    public class RackSamplesController : Controller
    {
        private readonly MummyContext _context;
        private IWantMyMummyContext mummyContext;
        private UserManager<IWantMyMummyUser> userManager;



        public RackSamplesController(MummyContext context, IWantMyMummyContext con, UserManager<IWantMyMummyUser> tempUser)
        {
            _context = context;
            mummyContext = con;
            userManager = tempUser;



        }



        // GET: RackSamples
        public async Task<IActionResult> Index()
        {
            var role = (mummyContext.UserRoles
           .Where(r => r.UserId == userManager.GetUserId(User))
           .FirstOrDefault());



            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }
            var mumCon = _context.RackSample.Include(r => r.Burial);
            return View(await mumCon.ToListAsync());
        }



        // GET: RackSamples/Details/5
        public async Task<IActionResult> Details(string RackNumber, string RackShelf)
        {
            if (RackNumber == null || RackShelf == null)
            {
                return NotFound();
            }



            var rackSample = _context.RackSample.Where(x => x.RackNumber == RackNumber && x.RackShelf == RackShelf).First();

            if (rackSample == null)
            {
                return NotFound();
            }



            return View(rackSample);
        }



        // GET: RackSamples/Create
        public IActionResult Create(int BurialId, string Burial, string Subplot, int Num)
        {
            if (BurialId <= 0)
            {
                return NotFound();
            }
            ViewBag.Id = BurialId;
            ViewBag.Burial = Burial;
            ViewBag.Subplot = Subplot;
            ViewBag.Num = Num;
            RackViewModel viewModel = new RackViewModel
            {
                BurialId = BurialId,
                RackSample = new RackSample
                {
                    BurialId = BurialId,
                },
                BurialList = _context.Burial.Where(x => x.BurialId == BurialId).ToList(),
            };

            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping");
            return View(viewModel);
        }



        // POST: RackSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RackShelf,RackNumber,IsBag,BurialId,TubeNumber,RankDescription,MlSize,Foci,LocationNotes,Questions,Conventional14cAgeBp,_14cCalendarDay,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] RackSample rackSample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rackSample);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", rackSample.BurialId);
            return View(rackSample);
        }



        // GET: RackSamples/Edit/5
        public async Task<IActionResult> Edit(string RackNumber, string RackShelf)
        {
            if (RackNumber == null || RackShelf == null)
            {
                return NotFound();
            }



            var rackSample = _context.RackSample.Where(x => x.RackNumber == RackNumber && x.RackShelf == RackShelf).First();



            if (rackSample == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", rackSample.BurialId);
            return View(rackSample);
        }



        // POST: RackSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string RackNumber, string RackShelf, [Bind("RackShelf,RackNumber,IsBag,BurialId,TubeNumber,RankDescription,MlSize,Foci,LocationNotes,Questions,Conventional14cAgeBp,_14cCalendarDay,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] RackSample rackSample)
        {
            if (RackShelf != rackSample.RackShelf || RackNumber != rackSample.RackNumber)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rackSample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RackSampleExists(rackSample.RackShelf))
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
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", rackSample.BurialId);
            return View(rackSample);
        }



        // GET: RackSamples/Delete/5
        public async Task<IActionResult> Delete(string RackNumber, string RackShelf)
        {
            if (RackNumber == null || RackShelf == null)
            {
                return NotFound();
            }



            var rackSample = _context.RackSample.Where(x => x.RackNumber == RackNumber && x.RackShelf == RackShelf).First();



            if (rackSample == null)
            {
                return NotFound();
            }



            return View(rackSample);
        }



        // POST: RackSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string RackNumber, string RackShelf)
        {
            if (RackNumber == null || RackShelf == null)
            {
                return NotFound();
            }

            var rackSample = _context.RackSample.Where(x => x.RackNumber == RackNumber && x.RackShelf == RackShelf).First();

            if (rackSample == null)
            {
                return NotFound();
            }



            _context.RackSample.Remove(rackSample);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool RackSampleExists(string id)
        {
            return _context.RackSample.Any(e => e.RackShelf == id);
        }
    }
}