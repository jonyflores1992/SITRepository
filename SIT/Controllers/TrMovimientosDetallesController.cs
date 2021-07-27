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
    public class TrMovimientosDetallesController : Controller
    {
        private readonly UserContext _context;

        public TrMovimientosDetallesController(UserContext context)
        {
            _context = context;
        }

        // GET: TrMovimientosDetalles
        public async Task<IActionResult> Index()
        {
            var userContext = _context.TrMovimientosDetalle.Include(t => t.IdDetalleDeParadaNavigation).Include(t => t.IdMotivoParadaNavigation).Include(t => t.IdTrMovimientoNavigation);
            return View(await userContext.ToListAsync());
        }

        // GET: TrMovimientosDetalles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimientosDetalle = await _context.TrMovimientosDetalle
                .Include(t => t.IdDetalleDeParadaNavigation)
                .Include(t => t.IdMotivoParadaNavigation)
                .Include(t => t.IdTrMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trMovimientosDetalle == null)
            {
                return NotFound();
            }

            return View(trMovimientosDetalle);
        }

        // GET: TrMovimientosDetalles/Create
        public IActionResult Create()
        {
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1");
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1");
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha");
            return View();
        }

        // POST: TrMovimientosDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeriodoTiempoInicio,PeriodoTiempoFin,InicioReal,FinReal,Disponibles,IdMotivoParada,IdDetalleDeParada,Productiva,Disponible,Productividad,IdTrMovimiento,CreatedAt")] TrMovimientosDetalle trMovimientosDetalle)
        {
            if (ModelState.IsValid)
            {
                trMovimientosDetalle.Id = Guid.NewGuid();
                _context.Add(trMovimientosDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", trMovimientosDetalle.IdDetalleDeParada);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", trMovimientosDetalle.IdMotivoParada);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trMovimientosDetalle.IdTrMovimiento);
            return View(trMovimientosDetalle);
        }

        // GET: TrMovimientosDetalles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimientosDetalle = await _context.TrMovimientosDetalle.FindAsync(id);
            if (trMovimientosDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", trMovimientosDetalle.IdDetalleDeParada);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", trMovimientosDetalle.IdMotivoParada);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trMovimientosDetalle.IdTrMovimiento);
            return View(trMovimientosDetalle);
        }

        // POST: TrMovimientosDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PeriodoTiempoInicio,PeriodoTiempoFin,InicioReal,FinReal,Disponibles,IdMotivoParada,IdDetalleDeParada,Productiva,Disponible,Productividad,IdTrMovimiento,CreatedAt")] TrMovimientosDetalle trMovimientosDetalle)
        {
            if (id != trMovimientosDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trMovimientosDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrMovimientosDetalleExists(trMovimientosDetalle.Id))
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
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", trMovimientosDetalle.IdDetalleDeParada);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", trMovimientosDetalle.IdMotivoParada);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trMovimientosDetalle.IdTrMovimiento);
            return View(trMovimientosDetalle);
        }

        // GET: TrMovimientosDetalles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimientosDetalle = await _context.TrMovimientosDetalle
                .Include(t => t.IdDetalleDeParadaNavigation)
                .Include(t => t.IdMotivoParadaNavigation)
                .Include(t => t.IdTrMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trMovimientosDetalle == null)
            {
                return NotFound();
            }

            return View(trMovimientosDetalle);
        }

        // POST: TrMovimientosDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trMovimientosDetalle = await _context.TrMovimientosDetalle.FindAsync(id);
            _context.TrMovimientosDetalle.Remove(trMovimientosDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrMovimientosDetalleExists(Guid id)
        {
            return _context.TrMovimientosDetalle.Any(e => e.Id == id);
        }
    }
}
