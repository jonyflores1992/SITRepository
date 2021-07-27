using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class DetalleDeParadasController : BaseController
    {
        private readonly UserContext _context;

        public DetalleDeParadasController(UserContext context)
        {
            _context = context;
        }

        // GET: DetalleDeParadas
        public async Task<IActionResult> Index()
        {
            var userContext = _context.DetalleDeParada.Include(d => d.IdGrupoDeRecursoNavigation).Include(d => d.IdMotivoParadaNavigation).Include(d => d.IdSectorNavigation).Include(d => d.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: DetalleDeParadas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleDeParada = await _context.DetalleDeParada
                .Include(d => d.IdGrupoDeRecursoNavigation)
                .Include(d => d.IdMotivoParadaNavigation)
                .Include(d => d.IdSectorNavigation)
                .Include(d => d.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleDeParada == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(detalleDeParada);
        }

        // GET: DetalleDeParadas/Create
        public IActionResult Create()
        {
            ViewData["IdGrupoDeRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo");
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1");
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1");
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: DetalleDeParadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DetalleDeParada1,Codigo,IdSector,IdGrupoDeRecurso,IdMotivoParada,Status")] DetalleDeParada detalleDeParada)
        {
            if (ModelState.IsValid)
            {
                detalleDeParada.Id = Guid.NewGuid();
                _context.Add(detalleDeParada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrupoDeRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", detalleDeParada.IdGrupoDeRecurso);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", detalleDeParada.IdMotivoParada);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", detalleDeParada.IdSector);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", detalleDeParada.Status);
            retornarMainMenu();retornarUserMenuItems();return View(detalleDeParada);
        }

        // GET: DetalleDeParadas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleDeParada = await _context.DetalleDeParada.FindAsync(id);
            if (detalleDeParada == null)
            {
                return NotFound();
            }
            ViewData["IdGrupoDeRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", detalleDeParada.IdGrupoDeRecurso);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", detalleDeParada.IdMotivoParada);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", detalleDeParada.IdSector);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", detalleDeParada.Status);
            retornarMainMenu();retornarUserMenuItems();return View(detalleDeParada);
        }

        // POST: DetalleDeParadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DetalleDeParada1,Codigo,IdSector,IdGrupoDeRecurso,IdMotivoParada,Status")] DetalleDeParada detalleDeParada)
        {
            if (id != detalleDeParada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleDeParada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleDeParadaExists(detalleDeParada.Id))
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
            ViewData["IdGrupoDeRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", detalleDeParada.IdGrupoDeRecurso);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", detalleDeParada.IdMotivoParada);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", detalleDeParada.IdSector);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", detalleDeParada.Status);
            retornarMainMenu();retornarUserMenuItems();return View(detalleDeParada);
        }

        // GET: DetalleDeParadas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleDeParada = await _context.DetalleDeParada
                .Include(d => d.IdGrupoDeRecursoNavigation)
                .Include(d => d.IdMotivoParadaNavigation)
                .Include(d => d.IdSectorNavigation)
                .Include(d => d.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleDeParada == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(detalleDeParada);
        }

        // POST: DetalleDeParadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var detalleDeParada = await _context.DetalleDeParada.FindAsync(id);
            _context.DetalleDeParada.Remove(detalleDeParada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleDeParadaExists(Guid id)
        {
            return _context.DetalleDeParada.Any(e => e.Id == id);
        }
    }
}
