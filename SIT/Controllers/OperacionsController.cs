using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class OperacionsController : BaseController
    {
        private readonly UserContext _context;

        public OperacionsController(UserContext context)
        {
            _context = context;
        }

        // GET: Operacions
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Operacion.Include(o => o.IdGrupoRecursoNavigation).Include(o => o.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: Operacions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacion = await _context.Operacion
                .Include(o => o.IdGrupoRecursoNavigation)
                .Include(o => o.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operacion == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(operacion);
        }

        // GET: Operacions/Create
        public IActionResult Create()
        {
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo");
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: Operacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Operacion1,IdGrupoRecurso,Status,CreatedAt,UpdateAt,Delete")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                operacion.Id = Guid.NewGuid();
                _context.Add(operacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", operacion.IdGrupoRecurso);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", operacion.Status);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            retornarMainMenu();retornarUserMenuItems();return View(operacion);
        }

        // GET: Operacions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacion = await _context.Operacion.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", operacion.IdGrupoRecurso);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", operacion.Status);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            retornarMainMenu();retornarUserMenuItems();return View(operacion);
        }

        // POST: Operacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Operacion1,IdGrupoRecurso,Status,CreatedAt,UpdateAt,Delete")] Operacion operacion)
        {
            if (id != operacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperacionExists(operacion.Id))
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
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", operacion.IdGrupoRecurso);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", operacion.Status);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            retornarMainMenu();retornarUserMenuItems();return View(operacion);
        }

        // GET: Operacions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operacion = await _context.Operacion
                .Include(o => o.IdGrupoRecursoNavigation)
                .Include(o => o.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (operacion == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(operacion);
        }

        // POST: Operacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var operacion = await _context.Operacion.FindAsync(id);
            _context.Operacion.Remove(operacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperacionExists(Guid id)
        {
            return _context.Operacion.Any(e => e.Id == id);
        }

        public JsonResult FillArea(Guid IdSucursal)
        {
            var Areas = _context.Area.Where(c => c.IdSucursal == IdSucursal);
            return Json(Areas, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillSector(Guid IdArea)
        {
            var Sectores = _context.Sector.Where(c => c.IdArea == IdArea);
            return Json(Sectores, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillGrupoRecurso(Guid IdSector)
        {
            var Grupos = _context.GrupoRecurso.Where(c => c.IdSector == IdSector);
            return Json(Grupos, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
