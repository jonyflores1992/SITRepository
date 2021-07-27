using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class MotivoDeParadasController : BaseController
    {
        private readonly UserContext _context;

        public MotivoDeParadasController(UserContext context)
        {
            _context = context;
        }

        // GET: MotivoDeParadas
        public async Task<IActionResult> Index()
        {
            var userContext = _context.MotivoDeParada.Include(m => m.IdTipoParadaNavigation).Include(m => m.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: MotivoDeParadas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivoDeParada = await _context.MotivoDeParada
                .Include(m => m.IdTipoParadaNavigation)
                .Include(m => m.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivoDeParada == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(motivoDeParada);
        }

        // GET: MotivoDeParadas/Create
        public IActionResult Create()
        {
            ViewData["IdTipoParada"] = new SelectList(_context.TipoParada, "Id", "TipoParada1");
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: MotivoDeParadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MotivoDeParada1,IdTipoParada,Status,CreatedAt,UpdateAt,Delete")] MotivoDeParada motivoDeParada)
        {
            if (ModelState.IsValid)
            {
                motivoDeParada.Id = Guid.NewGuid();
                _context.Add(motivoDeParada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoParada"] = new SelectList(_context.TipoParada, "Id", "TipoParada1", motivoDeParada.IdTipoParada);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", motivoDeParada.Status);
            retornarMainMenu();retornarUserMenuItems();return View(motivoDeParada);
        }

        // GET: MotivoDeParadas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivoDeParada = await _context.MotivoDeParada.FindAsync(id);
            if (motivoDeParada == null)
            {
                return NotFound();
            }
            ViewData["IdTipoParada"] = new SelectList(_context.TipoParada, "Id", "TipoParada1", motivoDeParada.IdTipoParada);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", motivoDeParada.Status);
            retornarMainMenu();retornarUserMenuItems();return View(motivoDeParada);
        }

        // POST: MotivoDeParadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MotivoDeParada1,IdTipoParada,Status,CreatedAt,UpdateAt,Delete")] MotivoDeParada motivoDeParada)
        {
            if (id != motivoDeParada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motivoDeParada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotivoDeParadaExists(motivoDeParada.Id))
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
            ViewData["IdTipoParada"] = new SelectList(_context.TipoParada, "Id", "TipoParada1", motivoDeParada.IdTipoParada);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", motivoDeParada.Status);
            retornarMainMenu();retornarUserMenuItems();return View(motivoDeParada);
        }

        // GET: MotivoDeParadas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivoDeParada = await _context.MotivoDeParada
                .Include(m => m.IdTipoParadaNavigation)
                .Include(m => m.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivoDeParada == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(motivoDeParada);
        }

        // POST: MotivoDeParadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var motivoDeParada = await _context.MotivoDeParada.FindAsync(id);
            _context.MotivoDeParada.Remove(motivoDeParada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotivoDeParadaExists(Guid id)
        {
            return _context.MotivoDeParada.Any(e => e.Id == id);
        }
    }
}
