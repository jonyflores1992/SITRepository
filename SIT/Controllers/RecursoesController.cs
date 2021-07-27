using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class RecursoesController : BaseController
    {
        [Obsolete]
        private IHostingEnvironment hosting;

        private readonly UserContext _context;

        [Obsolete]
        public RecursoesController(UserContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            hosting = hostingEnvironment;
        }

        // GET: Recursoes
        public async Task<IActionResult> Index()
        {
            var userContext = _context.Recurso.Include(r => r.IdActividadNavigation).Include(r => r.IdGrupoRecursoPrincipalNavigation).Include(r => r.IdSectorNavigation).Include(r => r.IdUnidadMedidaNavigation).Include(r => r.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();return View(await userContext.ToListAsync());
        }

        // GET: Recursoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso
                .Include(r => r.IdActividadNavigation)
                .Include(r => r.IdGrupoRecursoPrincipalNavigation)
                .Include(r => r.IdSectorNavigation)
                .Include(r => r.IdUnidadMedidaNavigation)
                .Include(r => r.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(recurso);
        }

        // GET: Recursoes/Create
        public IActionResult Create()
        {
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Actividad1");
            ViewData["IdGrupoRecursoPrincipal"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo");
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1");
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: Recursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(FileUpload recurso)
        {
            if (ModelState.IsValid)
            {
                string GuidImagen = null;
                FileStream stream = null;
                if (recurso.rutaFoto != null)
                {
                    string FicherosImagenes = //@"E:\Documentos\Visual Studio 2019\SIT\SIT\Imagenes"; 
                        @Path.Combine(hosting.WebRootPath, "images");
                    GuidImagen = Guid.NewGuid().ToString() + recurso.rutaFoto.FileName;
                    string RutaDefinitiva = Path.Combine(FicherosImagenes, GuidImagen);

                    using (stream = new FileStream(RutaDefinitiva, FileMode.Create))
                    {
                        recurso.rutaFoto.CopyTo(stream);

                    }
                    stream.Close();
                }
                Recurso recurso1 = new Recurso();
                recurso1.Id = Guid.NewGuid();
                recurso1.Nombre = recurso.Nombre;
                recurso1.IdSector = recurso.IdSector;
                recurso1.IdGrupoRecursoPrincipal = recurso.IdGrupoRecursoPrincipal;
                recurso1.FechaNacimiento = recurso.FechaNacimiento;
                recurso1.IdUnidadMedida = recurso.IdUnidadMedida;
                recurso1.ProductividadDeseada = recurso.ProductividadDeseada;
                recurso1.Costo = recurso.Costo;
                recurso1.CodigoBarra = recurso.CodigoBarra;
                recurso1.Codigo = recurso.Codigo;
                recurso1.Status = recurso.Status;
                recurso1.Foto = GuidImagen;
                recurso1.IdActividad = recurso.IdActividad;
                _context.Add(recurso1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Actividad1", recurso.IdActividad);
            ViewData["IdGrupoRecursoPrincipal"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", recurso.IdGrupoRecursoPrincipal);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");

            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", recurso.IdSector);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", recurso.IdUnidadMedida);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", recurso.Status);
            retornarMainMenu();retornarUserMenuItems();return View(recurso);
        }

        // GET: Recursoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var recurso = await _context.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }
            FileUpload recurso1 = new FileUpload();
            recurso1.Id = recurso.Id;
            recurso1.Nombre = recurso.Nombre;
            recurso1.IdSector = recurso.IdSector;
            recurso1.IdGrupoRecursoPrincipal = recurso.IdGrupoRecursoPrincipal;
            recurso1.FechaNacimiento = recurso.FechaNacimiento;
            recurso1.IdUnidadMedida = recurso.IdUnidadMedida;
            recurso1.ProductividadDeseada = recurso.ProductividadDeseada;
            recurso1.Costo = recurso.Costo;
            recurso1.CodigoBarra = recurso.CodigoBarra;
            recurso1.Codigo = recurso.Codigo;
            recurso1.TurnoNoche = recurso.TurnoNoche;
            recurso1.Status = recurso.Status;
            recurso1.Foto = recurso.Foto;
            recurso1.IdActividad = recurso.IdActividad;

            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Actividad1", recurso1.IdActividad);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");

            ViewData["IdGrupoRecursoPrincipal"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", recurso1.IdGrupoRecursoPrincipal);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", recurso1.IdSector);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", recurso1.IdUnidadMedida);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", recurso1.Status);
            retornarMainMenu();retornarUserMenuItems();return View(recurso1);
        }

        // POST: Recursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Edit(Guid id, FileUpload recurso)
        {
            if (id != recurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string GuidImagen = recurso.Foto;
                    
                    FileStream stream = null;
                    
                        string FicherosImagenes = //@"E:\Documentos\Visual Studio 2019\SIT\SIT\Imagenes"; 
                            @Path.Combine(hosting.WebRootPath, "images");

                        string RutaEliminar = null;
                        if (recurso.Foto != null)
                        {
                            RutaEliminar = Path.Combine(FicherosImagenes, recurso.Foto);
                        }
                        if (recurso.rutaFoto != null)
                        {
                            GuidImagen = Guid.NewGuid().ToString() + recurso.rutaFoto.FileName;
                            string RutaDefinitiva = Path.Combine(FicherosImagenes, GuidImagen);
                            using (stream = new FileStream(RutaDefinitiva, FileMode.Create))
                            {
                                recurso.rutaFoto.CopyTo(stream);
                            }

                            stream.Close();
                        }
                    
                    Recurso recurso1 = new Recurso();
                    recurso1.Id = recurso.Id;
                    recurso1.Nombre = recurso.Nombre;
                    recurso1.IdSector = recurso.IdSector;
                    recurso1.IdGrupoRecursoPrincipal = recurso.IdGrupoRecursoPrincipal;
                    recurso1.FechaNacimiento = recurso.FechaNacimiento;
                    recurso1.IdUnidadMedida = recurso.IdUnidadMedida;
                    recurso1.ProductividadDeseada = recurso.ProductividadDeseada;
                    recurso1.Costo = recurso.Costo;
                    recurso1.CodigoBarra = recurso.CodigoBarra;
                    recurso1.Codigo = recurso.Codigo;
                    recurso1.TurnoNoche = recurso.TurnoNoche;
                    recurso1.Status = recurso.Status;
                    recurso1.Foto = GuidImagen;
                    recurso1.IdActividad = recurso.IdActividad;


                    _context.Update(recurso1);
                    await _context.SaveChangesAsync();
                    if (recurso.rutaFoto != null)
                    {
                        if (RutaEliminar != null)
                        {

                            FileInfo fi = new FileInfo(RutaEliminar);
                            if (fi != null)
                            {
                                System.IO.File.Delete(RutaEliminar);
                                fi.Delete();


                            }


                        }
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursoExists(recurso.Id))
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
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Actividad1", recurso.IdActividad);
            ViewData["IdSucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");

            ViewData["IdGrupoRecursoPrincipal"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", recurso.IdGrupoRecursoPrincipal);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", recurso.IdSector);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", recurso.IdUnidadMedida);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", recurso.Status);
            retornarMainMenu();retornarUserMenuItems();return View(recurso);
        }

        // GET: Recursoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recurso
                .Include(r => r.IdActividadNavigation)
                .Include(r => r.IdGrupoRecursoPrincipalNavigation)
                .Include(r => r.IdSectorNavigation)
                .Include(r => r.IdUnidadMedidaNavigation)
                .Include(r => r.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recurso == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(recurso);
        }

        // POST: Recursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var recurso = await _context.Recurso.FindAsync(id);
            _context.Recurso.Remove(recurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursoExists(Guid id)
        {
            return _context.Recurso.Any(e => e.Id == id);
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
        public JsonResult FillActividad(Guid IdGrupoDeRecurso)
        {
            var Actividades = _context.Actividad.Where(c => c.IdGrupoRecurso == IdGrupoDeRecurso);
            return Json(Actividades, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
