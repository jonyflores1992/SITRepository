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
    public class TrParadasController : Controller
    {
        private readonly UserContext _context;

        public TrParadasController(UserContext context)
        {
            _context = context;
        }

        // GET: TrParadas
        public async Task<IActionResult> Index()
        {
            var userContext = _context.TrParada.Include(t => t.IdDetalleDeParadaNavigation).Include(t => t.IdMotivoParadaNavigation).Include(t => t.IdTrMovimientoNavigation);
            return View(await userContext.ToListAsync());
        }

        // GET: TrParadas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trParada = await _context.TrParada
                .Include(t => t.IdDetalleDeParadaNavigation)
                .Include(t => t.IdMotivoParadaNavigation)
                .Include(t => t.IdTrMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trParada == null)
            {
                return NotFound();
            }

            return View(trParada);
        }

        // GET: TrParadas/Create
        public IActionResult Create()
        {
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1");
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1");
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha");
            return View();
        }

        // POST: TrParadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMotivoParada,PeriodoTiempoInicio,PeriodoTiempoFin,InicioReal,FinReal,IdDetalleDeParada,Horas,Retroactiva,IdTrMovimiento,CreatedAt,UpdateAt,Delete")] TrParada trParada)
        {
            if (ModelState.IsValid)
            {
                trParada.Id = Guid.NewGuid();
                _context.Add(trParada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", trParada.IdDetalleDeParada);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", trParada.IdMotivoParada);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trParada.IdTrMovimiento);
            return View(trParada);
        }

        // GET: TrParadas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trParada = await _context.TrParada.FindAsync(id);
            if (trParada == null)
            {
                return NotFound();
            }
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", trParada.IdDetalleDeParada);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", trParada.IdMotivoParada);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trParada.IdTrMovimiento);
            return View(trParada);
        }

        // POST: TrParadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdMotivoParada,PeriodoTiempoInicio,PeriodoTiempoFin,InicioReal,FinReal,IdDetalleDeParada,Horas,Retroactiva,IdTrMovimiento,CreatedAt,UpdateAt,Delete")] TrParada trParada)
        {
            if (id != trParada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trParada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrParadaExists(trParada.Id))
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
            ViewData["IdDetalleDeParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", trParada.IdDetalleDeParada);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", trParada.IdMotivoParada);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trParada.IdTrMovimiento);
            return View(trParada);
        }

        // GET: TrParadas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trParada = await _context.TrParada
                .Include(t => t.IdDetalleDeParadaNavigation)
                .Include(t => t.IdMotivoParadaNavigation)
                .Include(t => t.IdTrMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trParada == null)
            {
                return NotFound();
            }

            return View(trParada);
        }

        // POST: TrParadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trParada = await _context.TrParada.FindAsync(id);
            _context.TrParada.Remove(trParada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrParadaExists(Guid id)
        {
            return _context.TrParada.Any(e => e.Id == id);
        }
    }
}
