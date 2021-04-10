using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IWantMyMummy.Models;
using IWantMyMummy.Models.ViewModels;




namespace IWantMyMummy.Controllers
{
    public class CranialSamplesController : Controller
    {
        private readonly MummyContext _context;



        public CranialSamplesController(MummyContext context)
        {
            _context = context;
        }



        // GET: CranialSamples
        public async Task<IActionResult> Index()
        {
            var mummyContext = _context.CranialSample.Include(c => c.Burial).Include(c => c.Rack);
            return View(await mummyContext.ToListAsync());
        }



        // GET: CranialSamples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var cranialSample = await _context.CranialSample
                .Include(c => c.Burial)
                .Include(c => c.Rack)
                .FirstOrDefaultAsync(m => m.CranialId == id);
            if (cranialSample == null)
            {
                return NotFound();
            }



            return View(cranialSample);
        }



        // GET: CranialSamples/Create
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
            CranialBurialViewModel viewModel = new CranialBurialViewModel
            {
                BurialId = BurialId,
                CranialSample = new CranialSample
                {
                    BurialId = BurialId,
                },
                BurialList = _context.Burial.Where(x => x.BurialId == BurialId).ToList(),
            };



            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping");
            ViewData["RackShelf"] = new SelectList(_context.RackSample, "RackShelf", "RackShelf");
            return View(viewModel);
        }



        // POST: CranialSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CranialId,BurialId,SampleNumber,RackShelf,RackNumber,MaxCranialLength,MaxCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizgomaticDiameter,NasionProsthion,MaxNasalBreadth,InterobitalBreadth")] CranialSample cranialSample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cranialSample);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", cranialSample.BurialId);
            ViewData["RackShelf"] = new SelectList(_context.RackSample, "RackShelf", "RackShelf", cranialSample.RackShelf);
            return View(cranialSample);
        }



        // GET: CranialSamples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var cranialSample = await _context.CranialSample.FindAsync(id);
            if (cranialSample == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", cranialSample.BurialId);
            ViewData["RackShelf"] = new SelectList(_context.RackSample, "RackShelf", "RackShelf", cranialSample.RackShelf);
            return View(cranialSample);
        }



        // POST: CranialSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CranialId,BurialId,SampleNumber,RackShelf,RackNumber,MaxCranialLength,MaxCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizgomaticDiameter,NasionProsthion,MaxNasalBreadth,InterobitalBreadth")] CranialSample cranialSample)
        {
            if (id != cranialSample.CranialId)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cranialSample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CranialSampleExists(cranialSample.CranialId))
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
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", cranialSample.BurialId);
            ViewData["RackShelf"] = new SelectList(_context.RackSample, "RackShelf", "RackShelf", cranialSample.RackShelf);
            return View(cranialSample);
        }



        // GET: CranialSamples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var cranialSample = await _context.CranialSample
                .Include(c => c.Burial)
                .Include(c => c.Rack)
                .FirstOrDefaultAsync(m => m.CranialId == id);
            if (cranialSample == null)
            {
                return NotFound();
            }



            return View(cranialSample);
        }



        // POST: CranialSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cranialSample = await _context.CranialSample.FindAsync(id);
            _context.CranialSample.Remove(cranialSample);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool CranialSampleExists(int id)
        {
            return _context.CranialSample.Any(e => e.CranialId == id);
        }
    }
}