using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class LineasController : BaseController
    {
        private readonly UserContext _context;

        public LineasController(UserContext context)
        {
            _context = context;
        }
    
        // GET: Lineas
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Linea.Include(l => l.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: Lineas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await _context.Linea
                .Include(l => l.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linea == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(linea);
        }

        // GET: Lineas/Create
        public IActionResult Create()
        {
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: Lineas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Linea1,Status")] Linea linea)
        {
            if (ModelState.IsValid)
            {
                linea.Id = Guid.NewGuid();
                _context.Add(linea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", linea.Status);
            retornarMainMenu();retornarUserMenuItems();return View(linea);
        }

        // GET: Lineas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await _context.Linea.FindAsync(id);
            if (linea == null)
            {
                return NotFound();
            }
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", linea.Status);
            retornarMainMenu();retornarUserMenuItems();return View(linea);
        }

        // POST: Lineas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Codigo,Linea1,Status")] Linea linea)
        {
            if (id != linea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineaExists(linea.Id))
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
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", linea.Status);
            retornarMainMenu();retornarUserMenuItems();return View(linea);
        }

        // GET: Lineas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await _context.Linea
                .Include(l => l.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (linea == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(linea);
        }

        // POST: Lineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var linea = await _context.Linea.FindAsync(id);
            _context.Linea.Remove(linea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineaExists(Guid id)
        {
            return _context.Linea.Any(e => e.Id == id);
        }
    }
}
