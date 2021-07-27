using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using com.sun.tools.corba.se.idl.toJavaPortable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class DefectosCalidadsController : BaseController
    {
        private readonly UserContext _context;

        public DefectosCalidadsController(UserContext context)
        {
            _context = context;
        }

        // GET: DefectosCalidads
        public async Task<IActionResult> Index()
        {
            var userContext = _context.DefectosCalidad.Include(r => r.StatusNavigation).Include(r => r.IdSectorNavigation).Include(r => r.IdgruporecursoNavigation).Include(r => r.IdproductoNavigation).Include(r => r.IdrecurosNavigation).Include(r => r.IdcomponenteNavigation);
           // retornarMainMenu(); retornarUserMenuItems();
            return View(await userContext.ToListAsync());
        }

        // GET: DefectosCalidads/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectosCalidad = await _context.DefectosCalidad
                .Include(r=>r.StatusNavigation)
                .Include(r => r.IdSectorNavigation)
                .Include(r => r.IdgruporecursoNavigation)
                .Include(r => r.IdproductoNavigation)
                .Include(r => r.IdrecurosNavigation)
                .Include(r => r.IdcomponenteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defectosCalidad == null)
            {
                return NotFound();
            }

            return View(defectosCalidad);
        }

        // GET: DefectosCalidads/Create
               public IActionResult CreateDefecto()
        {
            DefectosCalidad defectosCalidad = new DefectosCalidad();
            defectosCalidad.sectorCollection = _context.Sector.ToList<Sector>();
            defectosCalidad.productoCollection = _context.Producto.ToList<Producto>();
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", true);
            
                return View(defectosCalidad);
            
        }

        // GET: DefectosCalidads/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(Guid? id)
        {
            DefectosCalidad defectosCalidad = new DefectosCalidad();
            defectosCalidad.sectorCollection = _context.Sector.ToList<Sector>();
            defectosCalidad.productoCollection = _context.Producto.ToList<Producto>();
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", true);
            
            if (id == null)
            {
                return View(new DefectosCalidad());
            }
            else
            {
                var defectosCalidads = await _context.DefectosCalidad.FindAsync(id);
                if (defectosCalidads == null)
                {
                    return NotFound();
                }
                return View(defectosCalidads);

            }

        }

        // POST: DefectosCalidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDefecto([Bind("Id,IdSector,IdgrupoRecurso,IdRecurso,IdProducto,IdComponente,Codigo,Defecto,Status,DescripcionDefecto")] DefectosCalidad defectosCalidad)
        {
            if (ModelState.IsValid)
            {
                    defectosCalidad.Id = Guid.NewGuid();
                    _context.Add(defectosCalidad);
                    await _context.SaveChangesAsync();
            }

            return Json(new { Ok = true, isValid = true, html = Helper.RenderRazorViewString(this, "Index", _context.DefectosCalidad.ToList()) });

        }

        // GET: DefectosCalidads/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectosCalidad = await _context.DefectosCalidad.FindAsync(id);
            if (defectosCalidad == null)
            {
                return NotFound();
            }
            return View(defectosCalidad);
        }

        // POST: DefectosCalidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Guid id, [Bind("Id,IdSector,IdgrupoRecurso,IdRecurso,IdProducto,IdComponente,Codigo,Defecto,Status,DescripcionDefecto")] DefectosCalidad defectosCalidad)
        {
            //if (id != defectosCalidad.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                if (id == null)
                {

                    defectosCalidad.Id = Guid.NewGuid();
                    _context.Add(defectosCalidad);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(defectosCalidad);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DefectosCalidadExists(defectosCalidad.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }


                //                return RedirectToAction(nameof(Index));
                return Json(new { Ok = true, isValid = true, html = Helper.RenderRazorViewString(this,"Index",_context.DefectosCalidad.ToList()) });
            }
            //            return View(defectosCalidad);
            return Json(new { Ok = true, isValid = true, html =  Helper.RenderRazorViewString(this, "AddOrEdit",defectosCalidad) });
        }

        // GET: DefectosCalidads/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defectosCalidad = await _context.DefectosCalidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (defectosCalidad == null)
            {
                return NotFound();
            }

            return View(defectosCalidad);
        }

        // POST: DefectosCalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var resultado = new BaseRespuesta();
            var defectosCalidad = await _context.DefectosCalidad.FindAsync(id);
            _context.DefectosCalidad.Remove(defectosCalidad);
            await _context.SaveChangesAsync();

            return Json(new { Ok = true, html = Helper.RenderRazorViewString(this, "Index", _context.DefectosCalidad.ToList()) });
       //     resultado.Ok = true;
         //   resultado.Mensaje = "Eliminado con Exito";
           // return Json(resultado);
        //    return RedirectToAction(nameof(Index));
        }
        public JsonResult FillGrupoRecursos(Guid idsector)
        {
            var grupoRecursos = _context.GrupoRecurso.Where(c => c.IdSector == idsector);
            return Json(grupoRecursos, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillRecursos(Guid idGrupoRecurso)
        {
            var recursos = _context.Recurso.Where(c => c.IdGrupoRecursoPrincipal == idGrupoRecurso);
            return Json(recursos, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillComponente(Guid idproducto)
        {
            var componentes = _context.Componente.Where(c => c.IdProducto == idproducto);
            return Json(componentes, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPost]
        public JsonResult SaveDefectosCalidad(Guid Sector,Guid? GrupoRecurso,Guid? Recurso,Guid? Producto,Guid? Componente,string Codigo,string Defecto,Guid Status, string DescripcionDefecto)
        {
            var resultado = new BaseRespuesta();
            try
            {
                DefectosCalidad defectos = new DefectosCalidad();
                if (ModelState.IsValid)
                {
                    defectos.Id = Guid.NewGuid();
                    defectos.IdSector = Sector;
                    defectos.IdgrupoRecurso = GrupoRecurso;
                    defectos.IdRecurso = Recurso;
                    defectos.IdProducto = Producto;
                    defectos.IdComponente = Componente;
                    defectos.Codigo = Codigo;
                    defectos.Defecto = Defecto;
                    defectos.Status = Status;
                    defectos.DescripcionDefecto = DescripcionDefecto;

                    _context.Add(defectos);
                    _context.SaveChangesAsync();
                    resultado.Ok = true;
                    resultado.Mensaje = "Ingresado Con Exito";
                    resultado.Id = defectos.Id;
                }
                else
                {
                    resultado.Ok = false;
                    resultado.Mensaje = "Hubo un Error!";
                }
                return Json(resultado);

            }
            catch (Exception ex)
            {

                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
                return Json(resultado);
            }
        }

       
        private bool DefectosCalidadExists(Guid id)
        {
            return _context.DefectosCalidad.Any(e => e.Id == id);
        }
    }
}
