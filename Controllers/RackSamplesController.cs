using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWantMyMummy.Models;

namespace IWantMyMummy.Controllers
{
    public class RackSamplesController : Controller
    {
        private readonly MummyContext _context;

        public RackSamplesController(MummyContext context)
        {
            _context = context;
        }

        // GET: RackSamples
        public async Task<IActionResult> Index()
        {
            var mummyContext = _context.RackSample.Include(r => r.Burial);
            return View(await mummyContext.ToListAsync());
        }

        // GET: RackSamples/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rackSample = await _context.RackSample
                .Include(r => r.Burial)
                .FirstOrDefaultAsync(m => m.RackShelf == id);
            if (rackSample == null)
            {
                return NotFound();
            }

            return View(rackSample);
        }

        // GET: RackSamples/Create
        public IActionResult Create()
        {
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping");
            return View();
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
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rackSample = await _context.RackSample.FindAsync(id);
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
        public async Task<IActionResult> Edit(string id, [Bind("RackShelf,RackNumber,IsBag,BurialId,TubeNumber,RankDescription,MlSize,Foci,LocationNotes,Questions,Conventional14cAgeBp,_14cCalendarDay,Calibrated95CalendarDateMax,Calibrated95CalendarDateMin,Calibrated95CalendarDateSpan,Calibrated95CalendarDateAvg,Category,Notes")] RackSample rackSample)
        {
            if (id != rackSample.RackShelf)
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
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rackSample = await _context.RackSample
                .Include(r => r.Burial)
                .FirstOrDefaultAsync(m => m.RackShelf == id);
            if (rackSample == null)
            {
                return NotFound();
            }

            return View(rackSample);
        }

        // POST: RackSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rackSample = await _context.RackSample.FindAsync(id);
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
