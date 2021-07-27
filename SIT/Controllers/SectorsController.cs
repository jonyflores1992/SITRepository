using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SIT.IService;
using SIT.Models;
using Syncfusion.EJ2.PivotView;
using static System.Net.WebRequestMethods;

namespace SIT.Controllers
{

    public class SectorsController : BaseController
    {
        [Obsolete]
        private IHostingEnvironment hosting;

        private readonly UserContext _context;
       
        [Obsolete]
        public SectorsController(UserContext context, IHostingEnvironment hostingEnvironment)
        {

            _context = context;
            hosting = hostingEnvironment;


        }


        // GET: Sectors
        public async Task<IActionResult> Index()
        {

            var userContext = _context.Sector.Include(s => s.StatusNavigation).Include(s => s.IdAreaNavigation);
            //ViewBag.datasource = _context.Sector.ToList();
            retornarMainMenu(); retornarUserMenuItems(); return View(await userContext.ToListAsync());
        }
       
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .Include(s => s.StatusNavigation)
                .Include(s => s.IdAreaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            retornarMainMenu(); retornarUserMenuItems(); return View(sector);
        }
        public IActionResult Create()
        {
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status");
            ViewData["Area"] = new SelectList(_context.Area, "Id", "Area1");
            retornarMainMenu(); retornarUserMenuItems(); return View();
        }

        [AcceptVerbs("Post")]
        // GET: Sectors/Details/5


        [HttpPost]
        public string SaveSector(Guid id, [Bind("Id,Sector1,Orden,Status,Foto")] Sector fileObj)
        {
            //Sector oSector = JsonConvert.DeserializeObject<Sector>(fileObj.Sector);
            //if (fileObj.file.Length > 0)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        fileObj.file.CopyTo(ms);
            //        var filebytes = ms.ToArray();
            //        oSector.Foto = filebytes;
            //        oSector = _sectorService.Save(oSector);
            //        if (oSector.Id.ToString().Length > 0)
            //        {
            //            return "Guardado";
            //        }
            //    }
            //}
            return "Fallo";
        }


        //[HttpGet]
        //public JsonResult GetSavedSector()
        //{
        //    var sector = _sectorService.getSavedStocto();
        //    sector.Fotoo = this.GetImage(Convert.ToBase64String(sector.Fotoo));
        //    return Json(sector);
        //}

        // GET: Sectors/Create



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Create(FileUpload fileObj)
        {

            if (ModelState.IsValid)
            {
                string GuidImagen = null;
                if (fileObj.rutaFoto != null)
                {
                    string FicherosImagenes = //@"E:\Documentos\Visual Studio 2019\SIT\SIT\Imagenes"; 
                        @Path.Combine(hosting.WebRootPath, "images");
                    GuidImagen = Guid.NewGuid().ToString() + fileObj.rutaFoto.FileName;
                    string RutaDefinitiva = Path.Combine(FicherosImagenes, GuidImagen);
                    fileObj.rutaFoto.CopyTo(new FileStream(RutaDefinitiva, FileMode.Create));
                }
                Sector NuevoSector = new Sector();
                NuevoSector.Sector1 = fileObj.Sector1;
                NuevoSector.Orden = fileObj.Orden;
                NuevoSector.Status = fileObj.Status;
                NuevoSector.IdArea = fileObj.IdArea;
                NuevoSector.Foto = GuidImagen;

                _context.Add(NuevoSector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", fileObj.Status);
            ViewData["Area"] = new SelectList(_context.Area, "Id", "Area1", fileObj.IdArea);

            retornarMainMenu(); retornarUserMenuItems(); return View(fileObj);
        }



        // GET: Sectors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }
            FileUpload EditarSector = new FileUpload();
            EditarSector.Id = sector.Id;
            EditarSector.Sector1 = sector.Sector1;
            EditarSector.Orden = sector.Orden;
            EditarSector.Status = sector.Status;
            EditarSector.IdArea = sector.IdArea;
            EditarSector.Foto = sector.Foto;

            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", EditarSector.Status);
            ViewData["Area"] = new SelectList(_context.Area, "Id", "Area1", EditarSector.IdArea);
            retornarMainMenu(); retornarUserMenuItems(); return View(EditarSector);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Edit(Guid id, FileUpload sector)
        {


            if (id != sector.Id)
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
                    if(sector.Foto != null)
                    {
                    RutaEliminar= Path.Combine(FicherosImagenes, sector.Foto);
                    }

                    FileStream output = null;
                    string GuidImagen = sector.Foto;
                    if (sector.rutaFoto != null)
                    {
                        GuidImagen = Guid.NewGuid().ToString() + sector.rutaFoto.FileName;
                        string RutaDefinitiva = Path.Combine(FicherosImagenes, GuidImagen);
                        using ( output=new FileStream(RutaDefinitiva, FileMode.Create))
                        {
                            sector.rutaFoto.CopyTo(output);
                        }
                        //sector.rutaFoto.CopyTo(new FileStream(RutaDefinitiva, FileMode.Create));

                        output.Close();
                    }
                    Sector NuevoSector = new Sector();

                    NuevoSector.Id = sector.Id;
                    NuevoSector.Sector1 = sector.Sector1;
                    NuevoSector.Orden = sector.Orden;
                    NuevoSector.Status = sector.Status;
                    NuevoSector.IdArea = sector.IdArea;
                    NuevoSector.Foto = GuidImagen;

                    _context.Update(NuevoSector);
                    await _context.SaveChangesAsync();
                   
                    if(sector.rutaFoto != null)
                    {
                        if(RutaEliminar != null)
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
                    if (!SectorExists(sector.Id))
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
            ViewData["Status"] = new SelectList(_context.Estatus, "Id", "Status", sector.Status);
            ViewData["Area"] = new SelectList(_context.Sucursal, "Id", "Area1", sector.IdArea);
            retornarMainMenu(); retornarUserMenuItems(); return View(sector);
        }

        // GET: Sectors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sector = await _context.Sector
                .Include(s => s.StatusNavigation)
                 .Include(s => s.IdAreaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sector == null)
            {
                return NotFound();
            }

            retornarMainMenu(); retornarUserMenuItems(); return View(sector);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sector = await _context.Sector.FindAsync(id);
            _context.Sector.Remove(sector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public byte[] GetImage(string SBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(SBase64String))
            {
                bytes = Convert.FromBase64String(SBase64String);
            }
            return bytes;
        }
        private bool SectorExists(Guid id)
        {
            return _context.Sector.Any(e => e.Id == id);
        }
    }
}
