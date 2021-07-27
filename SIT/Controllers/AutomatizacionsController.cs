using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class AutomatizacionsController : Controller
    {
        private readonly UserContext _context;

        public AutomatizacionsController(UserContext context)
        {
            _context = context;
        }

        // GET: Automatizacions
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Automatizacion.Include(a => a.IdSectorNavigation);
            return View(await userContext.ToListAsync());
        }

        // GET: Automatizacions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automatizacion = await _context.Automatizacion
                .Include(a => a.IdSectorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automatizacion == null)
            {
                return NotFound();
            }

            return View(automatizacion);
        }

        // GET: Automatizacions/Create
        public IActionResult Create()
        {
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1");
            return View();
        }

        // POST: Automatizacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdSector")] Automatizacion automatizacion)
        {
            if (ModelState.IsValid)
            {
                automatizacion.Id = Guid.NewGuid();
                _context.Add(automatizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", automatizacion.IdSector);
            return View(automatizacion);
        }

        // GET: Automatizacions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automatizacion = await _context.Automatizacion.FindAsync(id);
            if (automatizacion == null)
            {
                return NotFound();
            }
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", automatizacion.IdSector);
            return View(automatizacion);
        }

        // POST: Automatizacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nombre,IdSector")] Automatizacion automatizacion)
        {
            if (id != automatizacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automatizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomatizacionExists(automatizacion.Id))
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
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", automatizacion.IdSector);
            return View(automatizacion);
        }

        // GET: Automatizacions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automatizacion = await _context.Automatizacion
                .Include(a => a.IdSectorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automatizacion == null)
            {
                return NotFound();
            }

            return View(automatizacion);
        }

        // POST: Automatizacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var automatizacion = await _context.Automatizacion.FindAsync(id);
            _context.Automatizacion.Remove(automatizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomatizacionExists(Guid id)
        {
            return _context.Automatizacion.Any(e => e.Id == id);
        }
    }
}
