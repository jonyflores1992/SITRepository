using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class EstatusController : BaseController
    {
        private readonly UserContext _context;

        public EstatusController(UserContext context)
        {
            _context = context;
        }

        // GET: Estatus
        public async Task<IActionResult> Index()
        {
            retornarMainMenu();retornarUserMenuItems();return View(await _context.Estatus.ToListAsync());
        }

        // GET: Estatus/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatus = await _context.Estatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatus == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(estatus);
        }

        // GET: Estatus/Create
        public IActionResult Create()
        {
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: Estatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] Estatus estatus)
        {
            if (ModelState.IsValid)
            {
                estatus.Id = Guid.NewGuid();
                _context.Add(estatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            retornarMainMenu();retornarUserMenuItems();return View(estatus);
        }

        // GET: Estatus/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatus = await _context.Estatus.FindAsync(id);
            if (estatus == null)
            {
                return NotFound();
            }
            retornarMainMenu();retornarUserMenuItems();return View(estatus);
        }

        // POST: Estatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Status")] Estatus estatus)
        {
            if (id != estatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstatusExists(estatus.Id))
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
            retornarMainMenu();retornarUserMenuItems();return View(estatus);
        }

        // GET: Estatus/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estatus = await _context.Estatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatus == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(estatus);
        }

        // POST: Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estatus = await _context.Estatus.FindAsync(id);
            _context.Estatus.Remove(estatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstatusExists(Guid id)
        {
            return _context.Estatus.Any(e => e.Id == id);
        }
    }
}
