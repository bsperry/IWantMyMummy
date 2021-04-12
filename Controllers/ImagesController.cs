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




namespace IWantMyMummy.Views
{
    public class ImagesController : Controller
    {
        private readonly MummyContext _context;
        private IWantMyMummyContext mummyContext;
        private UserManager<IWantMyMummyUser> userManager;



        public ImagesController(MummyContext context, IWantMyMummyContext con, UserManager<IWantMyMummyUser> tempUser)
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
            var mumCon = _context.Image.Include(i => i.Burial).Include(i => i.BurialS).Include(i => i.BurialSquare).Include(i => i.Cranial);
            return View(await mumCon.ToListAsync());
        }



        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var image = await _context.Image
                .Include(i => i.Burial)
                .Include(i => i.BurialS)
                .Include(i => i.BurialSquare)
                .Include(i => i.Cranial)
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }



            return View(image);
        }



        // GET: Images/Create
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




            ImageViewModel viewModel = new ImageViewModel
            {
                BurialId = BurialId,
                BurialList = _context.Burial.Where(x => x.BurialId == BurialId).ToList(),
                Image = new Image
                {
                    BurialId = BurialId,



                }
            };



            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping");
            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot");
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId");
            ViewData["CranialId"] = new SelectList(_context.CranialSample, "CranialId", "CranialId");
            return View(viewModel);
        }



        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,BurialId,BurialSquareId,BurialSubplot,CranialId,Image1,ImageDescription")] Image image)
        {
            if (ModelState.IsValid)
            {
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", image.BurialId);
            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot", image.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId", image.BurialSquareId);
            ViewData["CranialId"] = new SelectList(_context.CranialSample, "CranialId", "CranialId", image.CranialId);
            return View(image);
        }



        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var image = await _context.Image.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", image.BurialId);
            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot", image.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId", image.BurialSquareId);
            ViewData["CranialId"] = new SelectList(_context.CranialSample, "CranialId", "CranialId", image.CranialId);
            return View(image);
        }



        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,BurialId,BurialSquareId,BurialSubplot,CranialId,Image1,ImageDescription")] Image image)
        {
            if (id != image.ImageId)
            {
                return NotFound();
            }



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.ImageId))
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
            ViewData["BurialId"] = new SelectList(_context.Burial, "BurialId", "BurialWrapping", image.BurialId);
            ViewData["BurialSubplot"] = new SelectList(_context.BurialQuadrant, "BurialSubplot", "BurialSubplot", image.BurialSubplot);
            ViewData["BurialSquareId"] = new SelectList(_context.BurialSquare, "BurialSquareId", "BurialSquareId", image.BurialSquareId);
            ViewData["CranialId"] = new SelectList(_context.CranialSample, "CranialId", "CranialId", image.CranialId);
            return View(image);
        }



        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var image = await _context.Image
                .Include(i => i.Burial)
                .Include(i => i.BurialS)
                .Include(i => i.BurialSquare)
                .Include(i => i.Cranial)
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }



            return View(image);
        }



        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Image.FindAsync(id);
            _context.Image.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.ImageId == id);
        }
    }
}