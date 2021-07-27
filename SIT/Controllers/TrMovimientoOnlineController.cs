using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SIT.Models;

namespace SIT.Controllers
{
    public class TrMovimientoOnlineController : BaseController
    {
        private readonly UserContext _context;

        public TrMovimientoOnlineController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Save()
        {
            try
            {
                //try save data into database
                Notify("Data saved successfully");
            }
            catch (Exception)
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public class DatosOnline
        {
            public DateTime Fecha { get; set; }
            public string Sector { get; set; }
            public string Recurso { get; set; }
        }

        // GET: TrMovimientoOnline
        public async Task<IActionResult> Index()
        {

            var userContext = _context.TrMovimiento.Include(l => l.IdRecursoNavigation.IdSectorNavigation).Include(l => l.IdSectorNavigation).Where(movimiento => movimiento.IdTipoMovimientoNavigation.TipoMovimiento1 == "Online" & movimiento.IdEstadoNavigation.EstadoMovimiento1 == "Iniciado");
           
            retornarMainMenu(); retornarUserMenuItems();
            return View(await userContext.ToListAsync());
        }

        // GET: TrMovimientoOnline/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimiento = await _context.TrMovimiento
                .Include(t => t.IdMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trMovimiento == null)
            {
                return NotFound();
            }

            return View(trMovimiento);
        }

        // GET: TrMovimientoOnline/Create
        public IActionResult Create()
        {
         

            TrMovimiento trMovimiento = new TrMovimiento();
            trMovimiento.Fecha = DateTime.Now;
            trMovimiento.IdRecurso = null;
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre",false);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1",true);
            ViewData["Componenetes"] = new SelectList(_context.Componente, "Id", "Componente1", true);
            ViewData["Operaciones"] = new SelectList(_context.Operacion, "Id", "Operacion1", true);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", true);
            ViewData["IdDetalleParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", true);
            retornarMainMenu(); retornarUserMenuItems();

            return View(trMovimiento);
        }

        // POST: TrMovimientoOnline/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrMovimiento trMovimiento)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    trMovimiento.Id = Guid.NewGuid();
                    _context.Add(trMovimiento);
                    await _context.SaveChangesAsync();
                    Notify("Ingresado Exitoso");
                    return RedirectToAction(nameof(Index));

                }

                ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre");
                retornarMainMenu(); retornarUserMenuItems();

                return View(trMovimiento);
            }
            catch (Exception)
            {

                Notify("Guardar Fallo!", notificationType: NotificationType.error);
                return RedirectToAction(nameof(Index));
            }


        }
        [HttpPost]
        public JsonResult  SaveMovimientoOLine(TrMovimiento trMovimiento)
        {
            var resultado = new BaseRespuesta();
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<SIT.Models.Recurso> ListaRecurso = _context.Recurso.Where(Recurso => Recurso.Id.ToString() == trMovimiento.IdRecurso.ToString());
                    trMovimiento.Id = Guid.NewGuid();
                    trMovimiento.IdActividad = ListaRecurso.Select(a => a.IdActividad).First();
                  
                    _context.Add(trMovimiento);
                      _context.SaveChangesAsync();
                }
                resultado.Ok = true;
                resultado.Mensaje = "Ingresado con Exito";
                resultado.Id = trMovimiento.Id;
                return Json(resultado);
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
                return Json(resultado);
                
            }
        }
        [HttpPost]
        public JsonResult SaveTrProduccion(TrProduccion trProduccion)
        {
            var resultado = new BaseRespuesta();
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<SIT.Models.TrMovimiento> ListaMovimiento = _context.TrMovimiento.Where(trMovimiento => trMovimiento.IdEstado.ToString() == "1E49CBEA-D13A-4CC4-B608-EE9E8D32ADC5" & trMovimiento.IdRecurso.ToString() == trProduccion.IdRecurso.ToString());
                    trProduccion.IdTrMovimiento = ListaMovimiento.Select(a => a.Id).First();
                    IEnumerable<SIT.Models.Actividad> ListaActividad = _context.Actividad.Where(Actividad => Actividad.Id == ListaMovimiento.Select(a => a.IdActividad).First());


                    trProduccion.Id = Guid.NewGuid();
                    trProduccion.Productiva = trProduccion.Cantidad / ListaActividad.Select(a => a.Er).First();
                    TimeSpan diferenciaHoras = new TimeSpan();
                    diferenciaHoras = (TimeSpan)(trProduccion.FinReal - trProduccion.InicioReal);
                    trProduccion.Disponibles = (float)diferenciaHoras.TotalMinutes / 60;
                    float CajasxMinutoMeta = (float)(ListaActividad.Select(a => a.Er).First() / 60);
                    float CajasxMinutoReal = (float)(trProduccion.Cantidad / diferenciaHoras.TotalMinutes);
                    trProduccion.Productividad = CajasxMinutoReal / CajasxMinutoMeta;

                    _context.Add(trProduccion);
                    _context.SaveChangesAsync();
                }
                resultado.Ok = true;
                resultado.Mensaje = "Ingresado con Exito";
                resultado.Id = (Guid)trProduccion.IdTrMovimiento;
                return Json(resultado);
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
                return Json(resultado);

            }
        }
        [HttpGet]
             public PartialViewResult GetDatosProduccion(Guid Id)
        {
            IEnumerable userContext = _context.TrProduccion.Where(trpr => trpr.IdTrMovimiento == Id).Include(t => t.IdComponenteNavigation).Include(t => t.IdProductoNavigation);
          

                return PartialView("_PartialTrProduccion", userContext);
               
                
           

        }
        [HttpGet]
        public PartialViewResult GetDatosParadas(Guid Id)
        {
            IEnumerable userContext = _context.TrParada.Where(trpr => trpr.IdTrMovimiento == Id).Include(t => t.IdDetalleDeParadaNavigation).Include(t => t.IdMotivoParadaNavigation);
            try
            {

                return PartialView("_PartialTrTablaParada", userContext);


            }
            catch (Exception ex)
            {
                return PartialView("_PartialTrTablaParada", userContext);
            }

        }
        // GET: TrMovimientoOnline/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimiento = await _context.TrMovimiento.FindAsync(id);
            if (trMovimiento == null)
            {
                return NotFound();
            }
            ViewData["IdMovimiento"] = new SelectList(_context.Movimiento, "Id", "Id", trMovimiento.IdMovimiento);
            retornarMainMenu(); retornarUserMenuItems();

            return View(trMovimiento);
        }

        // POST: TrMovimientoOnline/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Fecha,FechaHoraInicio,FechaHoraFin,IdEstado,Productividad,IdRecurso,IdMovimiento,IdActividad,CreatedAt,UpdateAt,Delete")] TrMovimiento trMovimiento)
        {
            if (id != trMovimiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trMovimiento);
                    await _context.SaveChangesAsync();
                    Notify("Actualizacion Exitosa!");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrMovimientoExists(trMovimiento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        Notify("Actualizacion Fallo!", notificationType: NotificationType.error);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMovimiento"] = new SelectList(_context.Movimiento, "Id", "Movimiento1", trMovimiento.IdMovimiento);
            return View(trMovimiento);
        }

        // GET: TrMovimientoOnline/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimiento = await _context.TrMovimiento
                .Include(t => t.IdMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trMovimiento == null)
            {
                return NotFound();
            }

            return View(trMovimiento);
        }

        // POST: TrMovimientoOnline/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var trMovimiento = await _context.TrMovimiento.FindAsync(id);
                _context.TrMovimiento.Remove(trMovimiento);
                await _context.SaveChangesAsync();
                Notify("Eliminado Exitoso");

            }
            catch (Exception)
            {

                Notify("Actualizacion Fallo!", notificationType: NotificationType.error);

            }
            return RedirectToAction(nameof(Index));

        }

        private bool TrMovimientoExists(Guid id)
        {
            return _context.TrMovimiento.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult SaveTrParada(TrParada trParada)
        {
            var resultado = new BaseRespuesta();
            try
            {
                if (ModelState.IsValid)
                {
                    trParada.Id = Guid.NewGuid();
                    //   Disponible (horafin-horainicio)/60 minutos
                    TimeSpan diferenciaHoras = new TimeSpan();
                    diferenciaHoras = (TimeSpan)(trParada.FinReal - trParada.InicioReal);
                    trParada.Horas = (float)diferenciaHoras.TotalMinutes / 60;

                    _context.Add(trParada);
                    _context.SaveChangesAsync();
                }
                resultado.Ok = true;
                resultado.Mensaje = "Ingresado con Exito";
                resultado.Id = (Guid)trParada.IdTrMovimiento;
                return Json(resultado);
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
                return Json(resultado);

            }
        }
        public JsonResult FillOperacion(Guid IdRecurso)
        {
            IEnumerable<SIT.Models.Recurso> recurso = _context.Recurso.Where(t => t.Id == IdRecurso );

            Guid Grupo = (Guid)recurso.Select(t => t.IdGrupoRecursoPrincipal).First();
            var Operaciones = _context.Operacion.Where(c => c.IdGrupoRecurso == Grupo);
            return Json(Operaciones, new Newtonsoft.Json.JsonSerializerSettings());
        }
    }
}
