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
    public class AreasController : BaseController
    {
        private readonly UserContext _context;

        public AreasController(UserContext context)
        {
            _context = context;
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Area.Include(a => a.IdSucursalNavigation).Include(a => a.StatusNavigation);
            retornarMainMenu(); retornarUserMenuItems();
            return View(await userContext.ToListAsync());
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .Include(a => a.IdSucursalNavigation)
                .Include(a => a.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // GET: Areas/Create
        public IActionResult Create()
        {
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Area1,Status,IdSucursal,CreatedAt,UpdateAt,Delete")] Area area)
        {
            if (ModelState.IsValid)
            {
                area.Id = Guid.NewGuid();
                _context.Add(area);
                await _context.SaveChangesAsync();
                Notify("Ingresado con exito");
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1", area.IdSucursal);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", area.Status);
            return View(area);
        }

        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1", area.IdSucursal);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", area.Status);
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Area1,Status,IdSucursal,CreatedAt,UpdateAt,Delete")] Area area)
        {
            if (id != area.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.Id))
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
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1", area.IdSucursal);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", area.Status);
            return View(area);
        }

        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .Include(a => a.IdSucursalNavigation)
                .Include(a => a.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var area = await _context.Area.FindAsync(id);
            _context.Area.Remove(area);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(Guid id)
        {
            return _context.Area.Any(e => e.Id == id);
        }
    }
}
