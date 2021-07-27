using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class UnidadDeMedidasController : BaseController
    {
        private readonly UserContext _context;

        public UnidadDeMedidasController(UserContext context)
        {
            _context = context;
        }

        // GET: UnidadDeMedidas
        public async Task<IActionResult> Index()
        {
            var userContext = _context.UnidadDeMedida.Include(u => u.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: UnidadDeMedidas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadDeMedida = await _context.UnidadDeMedida
                .Include(u => u.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadDeMedida == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(unidadDeMedida);
        }

        // GET: UnidadDeMedidas/Create
        public IActionResult Create()
        {
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: UnidadDeMedidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnidadDeMedida1,Status")] UnidadDeMedida unidadDeMedida)
        {
            if (ModelState.IsValid)
            {
                unidadDeMedida.Id = Guid.NewGuid();
                _context.Add(unidadDeMedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", unidadDeMedida.Status);
            retornarMainMenu();retornarUserMenuItems();return View(unidadDeMedida);
        }

        // GET: UnidadDeMedidas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadDeMedida = await _context.UnidadDeMedida.FindAsync(id);
            if (unidadDeMedida == null)
            {
                return NotFound();
            }
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", unidadDeMedida.Status);
            retornarMainMenu();retornarUserMenuItems();return View(unidadDeMedida);
        }

        // POST: UnidadDeMedidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UnidadDeMedida1,Status")] UnidadDeMedida unidadDeMedida)
        {
            if (id != unidadDeMedida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadDeMedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadDeMedidaExists(unidadDeMedida.Id))
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
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", unidadDeMedida.Status);
            retornarMainMenu();retornarUserMenuItems();return View(unidadDeMedida);
        }

        // GET: UnidadDeMedidas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadDeMedida = await _context.UnidadDeMedida
                .Include(u => u.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadDeMedida == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(unidadDeMedida);
        }

        // POST: UnidadDeMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unidadDeMedida = await _context.UnidadDeMedida.FindAsync(id);
            _context.UnidadDeMedida.Remove(unidadDeMedida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadDeMedidaExists(Guid id)
        {
            return _context.UnidadDeMedida.Any(e => e.Id == id);
        }
    }
}
