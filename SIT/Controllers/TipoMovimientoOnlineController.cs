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
    public class TipoMovimientoOnlineController : Controller
    {
        private readonly UserContext _context;

        public TipoMovimientoOnlineController(UserContext context)
        {
            _context = context;
        }

        // GET: TipoMovimientoOnline
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMovimiento.ToListAsync());
        }

        // GET: TipoMovimientoOnline/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimiento = await _context.TipoMovimiento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMovimiento == null)
            {
                return NotFound();
            }

            return View(tipoMovimiento);
        }

        // GET: TipoMovimientoOnline/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimientoOnline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoMovimiento1,Foto,CreatedAt,UpdateAt,Delete")] TipoMovimiento tipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                tipoMovimiento.Id = Guid.NewGuid();
                _context.Add(tipoMovimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMovimiento);
        }

        // GET: TipoMovimientoOnline/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimiento = await _context.TipoMovimiento.FindAsync(id);
            if (tipoMovimiento == null)
            {
                return NotFound();
            }
            return View(tipoMovimiento);
        }

        // POST: TipoMovimientoOnline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TipoMovimiento1,Foto,CreatedAt,UpdateAt,Delete")] TipoMovimiento tipoMovimiento)
        {
            if (id != tipoMovimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMovimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimientoExists(tipoMovimiento.Id))
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
            return View(tipoMovimiento);
        }

        // GET: TipoMovimientoOnline/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimiento = await _context.TipoMovimiento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMovimiento == null)
            {
                return NotFound();
            }

            return View(tipoMovimiento);
        }

        // POST: TipoMovimientoOnline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoMovimiento = await _context.TipoMovimiento.FindAsync(id);
            _context.TipoMovimiento.Remove(tipoMovimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimientoExists(Guid id)
        {
            return _context.TipoMovimiento.Any(e => e.Id == id);
        }
    }
}
