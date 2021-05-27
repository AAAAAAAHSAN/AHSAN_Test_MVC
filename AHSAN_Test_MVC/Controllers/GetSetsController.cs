using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHSAN_Test_MVC.Data;
using AHSAN_Test_MVC.Models;

namespace AHSAN_Test_MVC.Controllers
{
    public class GetSetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GetSetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GetSets
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetSet.ToListAsync());
        }

        // GET: GetSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getSet = await _context.GetSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getSet == null)
            {
                return NotFound();
            }

            return View(getSet);
        }

        // GET: GetSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GetSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Question,Answer")] GetSet getSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(getSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(getSet);
        }

        // GET: GetSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getSet = await _context.GetSet.FindAsync(id);
            if (getSet == null)
            {
                return NotFound();
            }
            return View(getSet);
        }

        // POST: GetSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,Answer")] GetSet getSet)
        {
            if (id != getSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(getSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GetSetExists(getSet.Id))
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
            return View(getSet);
        }

        // GET: GetSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var getSet = await _context.GetSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (getSet == null)
            {
                return NotFound();
            }

            return View(getSet);
        }

        // POST: GetSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var getSet = await _context.GetSet.FindAsync(id);
            _context.GetSet.Remove(getSet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GetSetExists(int id)
        {
            return _context.GetSet.Any(e => e.Id == id);
        }
    }
}
