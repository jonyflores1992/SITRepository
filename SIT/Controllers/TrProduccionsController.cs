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
    public class TrProduccionsController : Controller
    {
        private readonly UserContext _context;

        public TrProduccionsController(UserContext context)
        {
            _context = context;
        }

        // GET: TrProduccions
        public async Task<IActionResult> Index()
        {
            var userContext = _context.TrProduccion.Include(t => t.IdComponenteNavigation).Include(t => t.IdGrupoRecursoNavigation).Include(t => t.IdOperacionNavigation).Include(t => t.IdProductoNavigation).Include(t => t.IdRecursoNavigation).Include(t => t.IdTrMovimientoNavigation);
            return View(await userContext.ToListAsync());
        }

        // GET: TrProduccions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trProduccion = await _context.TrProduccion
                .Include(t => t.IdComponenteNavigation)
                .Include(t => t.IdGrupoRecursoNavigation)
                .Include(t => t.IdOperacionNavigation)
                .Include(t => t.IdProductoNavigation)
                .Include(t => t.IdRecursoNavigation)
                .Include(t => t.IdTrMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trProduccion == null)
            {
                return NotFound();
            }

            return View(trProduccion);
        }

        // GET: TrProduccions/Create
        public IActionResult Create()
        {
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion");
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo");
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1");
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre");
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha");
            return View();
        }

        // POST: TrProduccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeriodoTiempoInicio,PeriodoTiempoFin,InicioReal,FinReal,IdProducto,IdComponente,IdOperacion,Productiva,Disponible,Productividad,Cantidad,IdRecurso,IdGrupoRecurso,IdTrMovimiento,CreatedAt,UpdateAt,Delete")] TrProduccion trProduccion)
        {
            if (ModelState.IsValid)
            {
                trProduccion.Id = Guid.NewGuid();
                _context.Add(trProduccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion", trProduccion.IdComponente);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", trProduccion.IdGrupoRecurso);
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", trProduccion.IdOperacion);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", trProduccion.IdProducto);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre", trProduccion.IdRecurso);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trProduccion.IdTrMovimiento);
            return View(trProduccion);
        }

        // GET: TrProduccions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trProduccion = await _context.TrProduccion.FindAsync(id);
            if (trProduccion == null)
            {
                return NotFound();
            }
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion", trProduccion.IdComponente);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", trProduccion.IdGrupoRecurso);
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", trProduccion.IdOperacion);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", trProduccion.IdProducto);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre", trProduccion.IdRecurso);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trProduccion.IdTrMovimiento);
            return View(trProduccion);
        }

        // POST: TrProduccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PeriodoTiempoInicio,PeriodoTiempoFin,InicioReal,FinReal,IdProducto,IdComponente,IdOperacion,Productiva,Disponible,Productividad,Cantidad,IdRecurso,IdGrupoRecurso,IdTrMovimiento,CreatedAt,UpdateAt,Delete")] TrProduccion trProduccion)
        {
            if (id != trProduccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trProduccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrProduccionExists(trProduccion.Id))
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
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion", trProduccion.IdComponente);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", trProduccion.IdGrupoRecurso);
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", trProduccion.IdOperacion);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", trProduccion.IdProducto);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre", trProduccion.IdRecurso);
            ViewData["IdTrMovimiento"] = new SelectList(_context.TrMovimiento, "Id", "Fecha", trProduccion.IdTrMovimiento);
            return View(trProduccion);
        }

        // GET: TrProduccions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trProduccion = await _context.TrProduccion
                .Include(t => t.IdComponenteNavigation)
                .Include(t => t.IdGrupoRecursoNavigation)
                .Include(t => t.IdOperacionNavigation)
                .Include(t => t.IdProductoNavigation)
                .Include(t => t.IdRecursoNavigation)
                .Include(t => t.IdTrMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trProduccion == null)
            {
                return NotFound();
            }

            return View(trProduccion);
        }

        // POST: TrProduccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trProduccion = await _context.TrProduccion.FindAsync(id);
            _context.TrProduccion.Remove(trProduccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrProduccionExists(Guid id)
        {
            return _context.TrProduccion.Any(e => e.Id == id);
        }
    }
}
