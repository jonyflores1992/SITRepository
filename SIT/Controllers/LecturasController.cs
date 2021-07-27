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
    public class LecturasController : Controller
    {
        private readonly UserContext _context;

        public LecturasController(UserContext context)
        {
            _context = context;
        }

        // GET: Lecturas
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Lectura.Include(l => l.IdActividadNavigation).Include(l => l.IdGrupoRecursoNavigation).Include(l => l.IdPuntoDeControlNavigation).Include(l => l.IdRecursoNavigation).Include(l => l.IdSectorNavigation);
            return View(await userContext.ToListAsync());
        }

        // GET: Lecturas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectura = await _context.Lectura
                .Include(l => l.IdActividadNavigation)
                .Include(l => l.IdGrupoRecursoNavigation)
                .Include(l => l.IdPuntoDeControlNavigation)
                .Include(l => l.IdRecursoNavigation)
                .Include(l => l.IdSectorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lectura == null)
            {
                return NotFound();
            }

            return View(lectura);
        }

        // GET: Lecturas/Create
        public IActionResult Create()
        {
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Id");
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Id");
            ViewData["IdPuntoDeControl"] = new SelectList(_context.PuntoDeControl, "Id", "Id");
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Id");
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1");
            return View();
        }

        // POST: Lecturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoBarra,Linea,SerialDispositivo,FechaHora,FechaHoraLector,IdRecurso,IdGrupoRecurso,Cantidad,IdSector,IdActividad,IdPuntoDeControl")] Lectura lectura)
        {
            if (ModelState.IsValid)
            {
                lectura.Id = Guid.NewGuid();
                _context.Add(lectura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Id", lectura.IdActividad);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Id", lectura.IdGrupoRecurso);
            ViewData["IdPuntoDeControl"] = new SelectList(_context.PuntoDeControl, "Id", "Id", lectura.IdPuntoDeControl);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Id", lectura.IdRecurso);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", lectura.IdSector);
            return View(lectura);
        }

        // GET: Lecturas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectura = await _context.Lectura.FindAsync(id);
            if (lectura == null)
            {
                return NotFound();
            }
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Id", lectura.IdActividad);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Id", lectura.IdGrupoRecurso);
            ViewData["IdPuntoDeControl"] = new SelectList(_context.PuntoDeControl, "Id", "Id", lectura.IdPuntoDeControl);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Id", lectura.IdRecurso);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", lectura.IdSector);
            return View(lectura);
        }

        // POST: Lecturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CodigoBarra,Linea,SerialDispositivo,FechaHora,FechaHoraLector,IdRecurso,IdGrupoRecurso,Cantidad,IdSector,IdActividad,IdPuntoDeControl")] Lectura lectura)
        {
            if (id != lectura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lectura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturaExists(lectura.Id))
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
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Id", lectura.IdActividad);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Id", lectura.IdGrupoRecurso);
            ViewData["IdPuntoDeControl"] = new SelectList(_context.PuntoDeControl, "Id", "Id", lectura.IdPuntoDeControl);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Id", lectura.IdRecurso);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", lectura.IdSector);
            return View(lectura);
        }

        // GET: Lecturas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lectura = await _context.Lectura
                .Include(l => l.IdActividadNavigation)
                .Include(l => l.IdGrupoRecursoNavigation)
                .Include(l => l.IdPuntoDeControlNavigation)
                .Include(l => l.IdRecursoNavigation)
                .Include(l => l.IdSectorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lectura == null)
            {
                return NotFound();
            }

            return View(lectura);
        }

        // POST: Lecturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lectura = await _context.Lectura.FindAsync(id);
            _context.Lectura.Remove(lectura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturaExists(Guid id)
        {
            return _context.Lectura.Any(e => e.Id == id);
        }
    }
}
