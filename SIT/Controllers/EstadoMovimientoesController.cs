using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class EstadoMovimientoesController : BaseController
    {
        private readonly UserContext _context;

        public EstadoMovimientoesController(UserContext context)
        {
            _context = context;
        }

        // GET: EstadoMovimientoes
        public async Task<IActionResult> Index()
        {
            retornarMainMenu();retornarUserMenuItems();return View(await _context.EstadoMovimiento.ToListAsync());
        }

        // GET: EstadoMovimientoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMovimiento = await _context.EstadoMovimiento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoMovimiento == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(estadoMovimiento);
        }

        // GET: EstadoMovimientoes/Create
        public IActionResult Create()
        {
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: EstadoMovimientoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstadoMovimiento1")] EstadoMovimiento estadoMovimiento)
        {
            if (ModelState.IsValid)
            {
                estadoMovimiento.Id = Guid.NewGuid();
                _context.Add(estadoMovimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            retornarMainMenu();retornarUserMenuItems();return View(estadoMovimiento);
        }

        // GET: EstadoMovimientoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMovimiento = await _context.EstadoMovimiento.FindAsync(id);
            if (estadoMovimiento == null)
            {
                return NotFound();
            }
            retornarMainMenu();retornarUserMenuItems();return View(estadoMovimiento);
        }

        // POST: EstadoMovimientoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,EstadoMovimiento1")] EstadoMovimiento estadoMovimiento)
        {
            if (id != estadoMovimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoMovimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoMovimientoExists(estadoMovimiento.Id))
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
            retornarMainMenu();retornarUserMenuItems();return View(estadoMovimiento);
        }

        // GET: EstadoMovimientoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoMovimiento = await _context.EstadoMovimiento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadoMovimiento == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(estadoMovimiento);
        }

        // POST: EstadoMovimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estadoMovimiento = await _context.EstadoMovimiento.FindAsync(id);
            _context.EstadoMovimiento.Remove(estadoMovimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoMovimientoExists(Guid id)
        {
            return _context.EstadoMovimiento.Any(e => e.Id == id);
        }
    }
}
