using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class ActividadsController : BaseController
    {
        private readonly UserContext _context;

        public ActividadsController(UserContext context)
        {
            _context = context;
        }

        // GET: Actividads
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Actividad.Include(a => a.IdComponenteNavigation).Include(a => a.IdGrupoRecursoNavigation).Include(a => a.IdOperacionNavigation).Include(a => a.IdProductoNavigation).Include(a => a.IdUnidadMedidaNavigation).Include(a => a.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: Actividads/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividad
                .Include(a => a.IdComponenteNavigation)
                .Include(a => a.IdGrupoRecursoNavigation)
                .Include(a => a.IdOperacionNavigation)
                .Include(a => a.IdProductoNavigation)
                .Include(a => a.IdUnidadMedidaNavigation)
                .Include(a => a.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actividad == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(actividad);
        }

        // GET: Actividads/Create
        public IActionResult Create()
        {
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion");
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo");
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1");
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1");
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: Actividads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Actividad1,Codigo,IdProducto,IdComponente,IdGrupoRecurso,IdOperacion,Instrucciones,CodigoBarra,IdUnidadMedida,FactorConversion,Er,Status")] Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                actividad.Id = Guid.NewGuid();
                _context.Add(actividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion", actividad.IdComponente);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", actividad.IdGrupoRecurso);
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", actividad.IdOperacion);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", actividad.IdProducto);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", actividad.IdUnidadMedida);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", actividad.Status);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            retornarMainMenu();retornarUserMenuItems();return View(actividad);
        }

        // GET: Actividads/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividad.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion", actividad.IdComponente);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", actividad.IdGrupoRecurso);
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", actividad.IdOperacion);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", actividad.IdProducto);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", actividad.IdUnidadMedida);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", actividad.Status);
            retornarMainMenu();retornarUserMenuItems();return View(actividad);
        }

        // POST: Actividads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Actividad1,Codigo,IdProducto,IdComponente,IdGrupoRecurso,IdOperacion,Instrucciones,CodigoBarra,IdUnidadMedida,FactorConversion,Er,Status")] Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadExists(actividad.Id))
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
            ViewData["IdComponente"] = new SelectList(_context.Componente, "Id", "Descripcion", actividad.IdComponente);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", actividad.IdGrupoRecurso);
            ViewData["IdOperacion"] = new SelectList(_context.Operacion, "Id", "Operacion1", actividad.IdOperacion);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", actividad.IdProducto);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", actividad.IdUnidadMedida);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", actividad.Status);
            retornarMainMenu();retornarUserMenuItems();return View(actividad);
        }

        // GET: Actividads/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividad
                .Include(a => a.IdComponenteNavigation)
                .Include(a => a.IdGrupoRecursoNavigation)
                .Include(a => a.IdOperacionNavigation)
                .Include(a => a.IdProductoNavigation)
                .Include(a => a.IdUnidadMedidaNavigation)
                .Include(a => a.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actividad == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(actividad);
        }

        // POST: Actividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var actividad = await _context.Actividad.FindAsync(id);
            _context.Actividad.Remove(actividad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadExists(Guid id)
        {
            return _context.Actividad.Any(e => e.Id == id);
        }
        public JsonResult FillComponentes(Guid IdProducto)
        {
            var Componentes = _context.Componente.Where(c => c.IdProducto == IdProducto);
            return Json(Componentes, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillOperacion(Guid IdGrupoRecurso)
        {
            var Operaciones = _context.Operacion.Where(c => c.IdGrupoRecurso == IdGrupoRecurso);
            return Json(Operaciones, new Newtonsoft.Json.JsonSerializerSettings());
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
