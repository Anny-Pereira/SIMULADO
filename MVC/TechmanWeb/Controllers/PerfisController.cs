using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechmanWeb.Data;
using TechmanWeb.Models;

namespace TechmanWeb.Controllers
{
    public class PerfisController : Controller
    {
        private readonly Contexto _context;

        public PerfisController(Contexto context)
        {
            _context = context;
        }

        // GET: Perfis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perfis.ToListAsync());
        }

        // GET: Perfis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfis = await _context.Perfis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfis == null)
            {
                return NotFound();
            }

            return View(perfis);
        }

        // GET: Perfis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Perfil")] Perfis perfis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfis);
        }

        // GET: Perfis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfis = await _context.Perfis.FindAsync(id);
            if (perfis == null)
            {
                return NotFound();
            }
            return View(perfis);
        }

        // POST: Perfis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Perfil")] Perfis perfis)
        {
            if (id != perfis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfisExists(perfis.Id))
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
            return View(perfis);
        }

        // GET: Perfis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfis = await _context.Perfis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfis == null)
            {
                return NotFound();
            }

            return View(perfis);
        }

        // POST: Perfis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfis = await _context.Perfis.FindAsync(id);
            _context.Perfis.Remove(perfis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfisExists(int id)
        {
            return _context.Perfis.Any(e => e.Id == id);
        }
    }
}
