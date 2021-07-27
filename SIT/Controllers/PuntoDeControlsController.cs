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
    public class PuntoDeControlsController : BaseController
    {
        private readonly UserContext _context;

        public PuntoDeControlsController(UserContext context)
        {
            _context = context;
        }

        // GET: PuntoDeControls
        public async Task<IActionResult> Index()
        {
            var userContext = _context.PuntoDeControl.Include(p => p.IdOperacionNavigation);
            retornarMainMenu(); retornarUserMenuItems();
            return View(await userContext.ToListAsync());
        }

        // GET: PuntoDeControls/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoDeControl = await _context.PuntoDeControl
                .Include(p => p.IdOperacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puntoDeControl == null)
            {
                return NotFound();
            }
            retornarMainMenu(); retornarUserMenuItems();
            return View(puntoDeControl);
        }

        // GET: PuntoDeControls/Create
        public IActionResult Create()
        {
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1");
            return View();
        }

        // POST: PuntoDeControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PuntoDeControl1,DescripcionUbicacion,Lat,Long,IdOperacion")] PuntoDeControl puntoDeControl)
        {
            if (ModelState.IsValid)
            {
                puntoDeControl.Id = Guid.NewGuid();
                _context.Add(puntoDeControl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", puntoDeControl.IdOperacion);
            retornarMainMenu(); retornarUserMenuItems();
            return View(puntoDeControl);
        }

        // GET: PuntoDeControls/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoDeControl = await _context.PuntoDeControl.FindAsync(id);
            if (puntoDeControl == null)
            {
                return NotFound();
            }
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", puntoDeControl.IdOperacion);
            retornarMainMenu(); retornarUserMenuItems();
            return View(puntoDeControl);
        }

        // POST: PuntoDeControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PuntoDeControl1,DescripcionUbicacion,Lat,Long,IdOperacion")] PuntoDeControl puntoDeControl)
        {
            if (id != puntoDeControl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puntoDeControl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuntoDeControlExists(puntoDeControl.Id))
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
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", puntoDeControl.IdOperacion);
            return View(puntoDeControl);
        }

        // GET: PuntoDeControls/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntoDeControl = await _context.PuntoDeControl
                .Include(p => p.IdOperacionNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puntoDeControl == null)
            {
                return NotFound();
            }
            retornarMainMenu(); retornarUserMenuItems();
            return View(puntoDeControl);
        }

        // POST: PuntoDeControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var puntoDeControl = await _context.PuntoDeControl.FindAsync(id);
            _context.PuntoDeControl.Remove(puntoDeControl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuntoDeControlExists(Guid id)
        {
            return _context.PuntoDeControl.Any(e => e.Id == id);
        }
    }
}
