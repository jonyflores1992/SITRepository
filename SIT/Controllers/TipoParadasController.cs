using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class TipoParadasController : BaseController
    {
        private readonly UserContext _context;

        public TipoParadasController(UserContext context)
        {
            _context = context;
        }

        // GET: TipoParadas
        public async Task<IActionResult> Index()
        {
            retornarMainMenu();retornarUserMenuItems();return View(await _context.TipoParada.ToListAsync());
        }

        // GET: TipoParadas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoParada = await _context.TipoParada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoParada == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(tipoParada);
        }

        // GET: TipoParadas/Create
        public IActionResult Create()
        {
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: TipoParadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoParada1,Id")] TipoParada tipoParada)
        {
            if (ModelState.IsValid)
            {
                tipoParada.Id = Guid.NewGuid();
                _context.Add(tipoParada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            retornarMainMenu();retornarUserMenuItems();return View(tipoParada);
        }

        // GET: TipoParadas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoParada = await _context.TipoParada.FindAsync(id);
            if (tipoParada == null)
            {
                return NotFound();
            }
            retornarMainMenu();retornarUserMenuItems();return View(tipoParada);
        }

        // POST: TipoParadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TipoParada1,Id")] TipoParada tipoParada)
        {
            if (id != tipoParada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoParada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoParadaExists(tipoParada.Id))
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
            retornarMainMenu();retornarUserMenuItems();return View(tipoParada);
        }

        // GET: TipoParadas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoParada = await _context.TipoParada
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoParada == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(tipoParada);
        }

        // POST: TipoParadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoParada = await _context.TipoParada.FindAsync(id);
            _context.TipoParada.Remove(tipoParada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoParadaExists(Guid id)
        {
            return _context.TipoParada.Any(e => e.Id == id);
        }
    }
}
