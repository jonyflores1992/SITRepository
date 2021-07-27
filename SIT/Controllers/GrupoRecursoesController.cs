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
    public class GrupoRecursoesController : BaseController
    {
        [Obsolete]
        private IHostingEnvironment hosting;

        private readonly UserContext _context;

        [Obsolete]
        public GrupoRecursoesController(UserContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            hosting = hostingEnvironment;
        }

        // GET: GrupoRecursoes
        public async Task<IActionResult> Index()
        {
            var userContext = _context.GrupoRecurso.Include(g => g.IdSectorNavigation).Include(r => r.IdUnidadMedidaNavigation).Include(g => g.StatusNavigation);
            retornarMainMenu();retornarUserMenuItems();
            return View(await userContext.ToListAsync());
        }

        // GET: GrupoRecursoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoRecurso = await _context.GrupoRecurso
                .Include(g => g.IdSectorNavigation)
                .Include(g => g.IdUnidadMedidaNavigation)
                .Include(g => g.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoRecurso == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(grupoRecurso);
        }

        // GET: GrupoRecursoes/Create
        public IActionResult Create()
        {
            ViewData["Sucursal"] = new SelectList(_context.Sucursal, "Id", "Sucursal1");
           
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1");
            retornarMainMenu();retornarUserMenuItems();return View();
        }

        // POST: GrupoRecursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(FileUpload grupoRecurso)
        {
            if (ModelState.IsValid)
            {

                string GuidImagen = null;
                FileStream stream = null;
                if (grupoRecurso.rutaFoto != null)
                {
                    string FicherosImagenes = //@"E:\Documentos\Visual Studio 2019\SIT\SIT\Imagenes"; 
                        @Path.Combine(hosting.WebRootPath, "images");
                    GuidImagen = Guid.NewGuid().ToString() + grupoRecurso.rutaFoto.FileName;
                    string RutaDefinitiva = Path.Combine(FicherosImagenes, GuidImagen);
                    
                    using(stream=new FileStream(RutaDefinitiva, FileMode.Create))
                    {
                        grupoRecurso.rutaFoto.CopyTo(stream);

                    }
                    stream.Close();
                }

                GrupoRecurso gruporecursos = new GrupoRecurso();
                gruporecursos.Id = Guid.NewGuid();
                gruporecursos.Grupo = grupoRecurso.Grupo;
                gruporecursos.IdSector = grupoRecurso.IdSector;
                gruporecursos.Status = grupoRecurso.Status;
                gruporecursos.IdUnidadMedida = grupoRecurso.IdUnidadMedida;
                gruporecursos.Foto = GuidImagen;
               // grupoRecurso.Id = Guid.NewGuid();
                _context.Add(gruporecursos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", grupoRecurso.IdSector);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", grupoRecurso.Status);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", grupoRecurso.IdUnidadMedida);
            retornarMainMenu();retornarUserMenuItems();return View(grupoRecurso);
        }

        // GET: GrupoRecursoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoRecurso = await _context.GrupoRecurso.FindAsync(id);
            if (grupoRecurso == null)
            {
                return NotFound();
            }
            FileUpload EditarGrupoRecurso = new FileUpload();
            EditarGrupoRecurso.Id = grupoRecurso.Id;
            EditarGrupoRecurso.Grupo = grupoRecurso.Grupo;
            EditarGrupoRecurso.IdSector = grupoRecurso.IdSector;
            EditarGrupoRecurso.Status = grupoRecurso.Status;
            EditarGrupoRecurso.IdUnidadMedida = grupoRecurso.IdUnidadMedida;
            EditarGrupoRecurso.Foto = grupoRecurso.Foto;
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", EditarGrupoRecurso.IdSector);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", EditarGrupoRecurso.Status);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", EditarGrupoRecurso.IdUnidadMedida);
            retornarMainMenu();retornarUserMenuItems();return View(EditarGrupoRecurso);
        }

        // POST: GrupoRecursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Edit(Guid id, FileUpload grupoRecurso)
        {
            if (id != grupoRecurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    string FicherosImagenes = //@"E:\Documentos\Visual Studio 2019\SIT\SIT\Imagenes"; 
                      @Path.Combine(hosting.WebRootPath, "images");

                    string RutaEliminar = null;
                    if (grupoRecurso.Foto != null)
                    {
                        RutaEliminar = Path.Combine(FicherosImagenes, grupoRecurso.Foto);
                    }
                    FileStream output = null;
                    string GuidImagen = grupoRecurso.Foto;
                    if (grupoRecurso.rutaFoto != null)
                    {
                        GuidImagen = Guid.NewGuid().ToString() + grupoRecurso.rutaFoto.FileName;
                        string RutaDefinitiva = Path.Combine(FicherosImagenes, GuidImagen);
                        using (output = new FileStream(RutaDefinitiva, FileMode.Create))
                        {
                            grupoRecurso.rutaFoto.CopyTo(output);
                        }
                    
                        output.Close();
                    }
                    GrupoRecurso nuevogrupo = new GrupoRecurso();
                    nuevogrupo.Id = grupoRecurso.Id;
                    nuevogrupo.Grupo = grupoRecurso.Grupo;
                    nuevogrupo.IdSector = grupoRecurso.IdSector;
                    nuevogrupo.Status = grupoRecurso.Status;
                    nuevogrupo.IdUnidadMedida = grupoRecurso.IdUnidadMedida;
                    nuevogrupo.Foto = GuidImagen;



                    _context.Update(nuevogrupo);
                    await _context.SaveChangesAsync();

                    if(grupoRecurso.rutaFoto != null)
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
                    if (!GrupoRecursoExists(grupoRecurso.Id))
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
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", grupoRecurso.IdSector);
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", grupoRecurso.Status);
            ViewData["IdUnidadMedida"] = new SelectList(_context.UnidadDeMedida, "Id", "UnidadDeMedida1", grupoRecurso.IdUnidadMedida);
            retornarMainMenu();retornarUserMenuItems();return View(grupoRecurso);
        }

        // GET: GrupoRecursoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoRecurso = await _context.GrupoRecurso
                .Include(g => g.IdSectorNavigation)
                .Include(g => g.IdUnidadMedidaNavigation)
                .Include(g => g.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupoRecurso == null)
            {
                return NotFound();
            }

            retornarMainMenu();retornarUserMenuItems();return View(grupoRecurso);
        }

        // POST: GrupoRecursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var grupoRecurso = await _context.GrupoRecurso.FindAsync(id);
            _context.GrupoRecurso.Remove(grupoRecurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoRecursoExists(Guid id)
        {
            return _context.GrupoRecurso.Any(e => e.Id == id);
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
    }
}
