using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers
{
    public class TrMovimientosManualController : BaseController
    {
        private readonly UserContext _context;

        public TrMovimientosManualController(UserContext context)
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
        // GET: TrMovimientosManual
        public async Task<IActionResult> Index()
        {
            var userContext = _context.TrMovimiento.Include(l => l.IdRecursoNavigation.IdSectorNavigation).Include(l => l.IdSectorNavigation).Include(l => l.IdRecursoNavigation.IdGrupoRecursoPrincipalNavigation).Include(l => l.IdGrupoRecursoNavigation).Include(l => l.IdActividadNavigation).Where(movimiento => movimiento.IdTipoMovimientoNavigation.TipoMovimiento1 == "Manual" & movimiento.IdEstadoNavigation.EstadoMovimiento1 == "Iniciado");

       
            retornarMainMenu(); retornarUserMenuItems();
            return View(await userContext.ToListAsync());
        }

        // GET: TrMovimientosManual/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimiento = await _context.TrMovimiento
                .Include(t => t.IdActividadNavigation)
                .Include(t => t.IdEstadoNavigation)
                .Include(t => t.IdGrupoRecursoNavigation)
                .Include(t => t.IdMovimientoNavigation)
                .Include(t => t.IdRecursoNavigation)
                .Include(t => t.IdSectorNavigation)
                .Include(t => t.IdTipoMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trMovimiento == null)
            {
                return NotFound();
            }

            return View(trMovimiento);
        }

        // GET: TrMovimientosManual/Create
        public IActionResult Create()
        {
            TrMovimiento trMovimiento = new TrMovimiento();
            trMovimiento.Fecha = DateTime.Now;
            trMovimiento.IdRecurso = null;
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre", false);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "Id", "Producto1", true);
            ViewData["Componenetes"] = new SelectList(_context.Componente, "Id", "Componente1", true);
            ViewData["Operaciones"] = new SelectList(_context.Operacion, "Id", "Operacion1", true);
            ViewData["IdMotivoParada"] = new SelectList(_context.MotivoDeParada, "Id", "MotivoDeParada1", true);
            ViewData["IdDetalleParada"] = new SelectList(_context.DetalleDeParada, "Id", "DetalleDeParada1", true);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", trMovimiento.IdGrupoRecurso);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", trMovimiento.IdSector);
            retornarMainMenu(); retornarUserMenuItems();
            return View(trMovimiento);
        }

        // POST: TrMovimientosManual/Create
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

       
       
        [HttpGet]
        public PartialViewResult GetDatosTabla(Guid Id)
        {
            IEnumerable<SIT.Models.TrMovimientosDetalle> userContext = _context.TrMovimientosDetalle.Include(t => t.IdTipoProduccionNavigation).Include(t => t.IdDetalleDeParadaNavigation).Include(t => t.IdMotivoParadaNavigation).Include(t => t.IdTrMovimientoNavigation).Include(t => t.IdTrMovimientoNavigation).Where(trpr => trpr.IdTrMovimiento == Id & trpr.IdTrMovimientoNavigation.IdEstadoNavigation.EstadoMovimiento1 == "Iniciado").OrderByDescending(t => t.PeriodoTiempoInicio);

            var resultado = new BaseRespuesta();
            try
            {

                TrMovimiento MovimientoTrContext = _context.TrMovimiento.Where(trpr => trpr.Id == Id).First();
                TrMovimiento trmovi = MovimientoTrContext;

                if (userContext.Count()>0)
                {
                    trmovi.Producido =(float) (userContext.Where(m => m.IdTipoProduccion.ToString() == "96472e15-3ba3-4c94-992c-1c6cc4d652db").Select(m => m.Productiva).Sum());
                    trmovi.Productividad = (float)(userContext.Where(m => m.IdTipoProduccion.ToString() == "96472e15-3ba3-4c94-992c-1c6cc4d652db").Select(m => m.Productividad).Average());
                    trmovi.Disponible = (float)(userContext.Where(m => m.IdTipoProduccion.ToString() == "96472e15-3ba3-4c94-992c-1c6cc4d652db").Select(m => m.Disponible).Sum());
                    trmovi.FechaHoraInicio = userContext.Select(m => m.PeriodoTiempoInicio).Min();
                    trmovi.FechaHoraFin = userContext.Select(m => m.PeriodoTiempoFin).Max();
                    _context.Update(trmovi);
                    _context.SaveChanges();
                }
            return PartialView("_PartialTrDetalle", userContext);

            }
            catch (Exception ex)
            {
                return PartialView("_PartialTrProduccion", userContext);
            }


}
        
        // GET: TrMovimientosManual/Edit/5
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
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Actividad1", trMovimiento.IdActividad);
            ViewData["IdEstado"] = new SelectList(_context.EstadoMovimiento, "Id", "EstadoMovimiento1", trMovimiento.IdEstado);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", trMovimiento.IdGrupoRecurso);
            ViewData["IdMovimiento"] = new SelectList(_context.Movimiento, "Id", "Movimiento1", trMovimiento.IdMovimiento);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre", trMovimiento.IdRecurso);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", trMovimiento.IdSector);
            ViewData["IdTipoMovimiento"] = new SelectList(_context.TipoMovimiento, "Id", "TipoMovimiento1", trMovimiento.IdTipoMovimiento);
            return View(trMovimiento);
        }

        // POST: TrMovimientosManual/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Fecha,FechaHoraInicio,FechaHoraFin,IdEstado,Productividad,IdRecurso,IdGrupoRecurso,IdSector,IdMovimiento,IdActividad,IdTipoMovimiento,CreatedAt,UpdateAt,Delete")] TrMovimiento trMovimiento)
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrMovimientoExists(trMovimiento.Id))
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
            ViewData["IdActividad"] = new SelectList(_context.Actividad, "Id", "Actividad1", trMovimiento.IdActividad);
            ViewData["IdEstado"] = new SelectList(_context.EstadoMovimiento, "Id", "EstadoMovimiento1", trMovimiento.IdEstado);
            ViewData["IdGrupoRecurso"] = new SelectList(_context.GrupoRecurso, "Id", "Grupo", trMovimiento.IdGrupoRecurso);
            ViewData["IdMovimiento"] = new SelectList(_context.Movimiento, "Id", "Movimiento1", trMovimiento.IdMovimiento);
            ViewData["IdRecurso"] = new SelectList(_context.Recurso, "Id", "Nombre", trMovimiento.IdRecurso);
            ViewData["IdSector"] = new SelectList(_context.Sector, "Id", "Sector1", trMovimiento.IdSector);
            ViewData["IdTipoMovimiento"] = new SelectList(_context.TipoMovimiento, "Id", "TipoMovimiento1", trMovimiento.IdTipoMovimiento);
            return View(trMovimiento);
        }

        // GET: TrMovimientosManual/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trMovimiento = await _context.TrMovimiento
                .Include(t => t.IdActividadNavigation)
                .Include(t => t.IdEstadoNavigation)
                .Include(t => t.IdGrupoRecursoNavigation)
                .Include(t => t.IdMovimientoNavigation)
                .Include(t => t.IdRecursoNavigation)
                .Include(t => t.IdSectorNavigation)
                .Include(t => t.IdTipoMovimientoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trMovimiento == null)
            {
                return NotFound();
            }

            return View(trMovimiento);
        }

        // POST: TrMovimientosManual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trMovimiento = await _context.TrMovimiento.FindAsync(id);
            _context.TrMovimiento.Remove(trMovimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrMovimientoExists(Guid id)
        {
            return _context.TrMovimiento.Any(e => e.Id == id);
        }

        [HttpPost]
        public JsonResult SaveMovimientoManual(TrMovimiento Trmovimiento)
        {
            var resultado = new BaseRespuesta();
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<SIT.Models.TrMovimiento> ListaMovimiento = _context.TrMovimiento.Include(t => t.IdEstadoNavigation).Where(trmovimiento => trmovimiento.IdEstadoNavigation.EstadoMovimiento1 == "Iniciado" & trmovimiento.IdRecurso == Trmovimiento.IdRecurso & trmovimiento.Fecha == DateTime.Today);
                    if (ListaMovimiento.Count()<=0)
                    {

                        IEnumerable<SIT.Models.Recurso> ListaRecurso = _context.Recurso.Where(Recurso => Recurso.Id == Trmovimiento.IdRecurso);
                        Trmovimiento.Id = Guid.NewGuid();
                        Trmovimiento.IdActividad = ListaRecurso.Select(a => a.IdActividad).First();

                        _context.Add(Trmovimiento);
                        _context.SaveChangesAsync();
                        resultado.Ok = true;
                        resultado.Mensaje = "Ingresado con Exito";
                        resultado.Id = Trmovimiento.Id;
                        return Json(resultado);
                    } else { 
                    resultado.Ok = true;
                    resultado.Mensaje = "Ya existe Actividad para este recurso en este dia";
                    resultado.Id = ListaMovimiento.Select(a => a.Id).First(); ;
                    return Json(resultado);
                    }
                }
                resultado.Ok = false;
                resultado.Mensaje ="Revise los datos" ;
                return Json(resultado);

            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
                return Json(resultado);

            }
        }

        public JsonResult FillGrupoRecurso(Guid IdSector)
        {
            var Grupos = _context.GrupoRecurso.Where(c => c.IdSector == IdSector);
            return Json(Grupos,  new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillRecurso(Guid IdGrupoRecurso)
        {
            var Recursos = _context.Recurso.Where(c => c.IdGrupoRecursoPrincipal == IdGrupoRecurso);
            return Json(Recursos, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillOperacion(Guid IdGrupoRecurso)
        {
            var Operaciones = _context.Operacion.Where(c => c.IdGrupoRecurso == IdGrupoRecurso);
            return Json(Operaciones, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillComponentes(Guid IdProducto)
        {
            var Componentes = _context.Componente.Where(c => c.IdProducto == IdProducto);
            return Json(Componentes, new Newtonsoft.Json.JsonSerializerSettings());
        }
        public JsonResult FillDetalleParada(Guid IdMotivoParada)
        {
            var DetalleParadas = _context.DetalleDeParada.Where(c => c.IdMotivoParada == IdMotivoParada);
            return Json(DetalleParadas, new Newtonsoft.Json.JsonSerializerSettings());
        }
        [HttpPost]
        public JsonResult SaveTrProduccion(TrProduccion trProduccion)
        {
            
            var resultado = new BaseRespuesta();
            try
            {
                //Sumando una hora
                TimeSpan horas = ((TimeSpan)(trProduccion.PeriodoTiempoFin - trProduccion.PeriodoTiempoInicio));
                System.TimeSpan duration = new System.TimeSpan(0, 1, 0, 0);
                //Buscando Trmovimiento
                IEnumerable<SIT.Models.TrMovimiento> ListaMovimiento = _context.TrMovimiento.Include(t => t.IdEstadoNavigation).Where(trMovimiento => trMovimiento.IdEstadoNavigation.EstadoMovimiento1 == "Iniciado" & trMovimiento.Id == trProduccion.IdTrMovimiento & trMovimiento.IdRecurso.ToString() == trProduccion.IdRecurso.ToString());
                //Buscando actividad realizada
                IEnumerable<SIT.Models.Actividad> ListaActividad = _context.Actividad.Where(Actividad => Actividad.Id == ListaMovimiento.Select(a => a.IdActividad).First());

                //Actualizar valores de cada hora
                trProduccion.Disponibles = ((float?)(trProduccion.Disponibles / horas.TotalHours));
                trProduccion.Cantidad = ((int)(trProduccion.Cantidad / horas.TotalHours));
                trProduccion.Productiva = (trProduccion.Cantidad / (ListaActividad.Select(a => a.Er).First()));
                trProduccion.Productividad = trProduccion.Productiva / trProduccion.Disponibles;

                //Insertando cada hora
                for (int i = 1; i <= horas.TotalHours; i++)
                {

                    if (ModelState.IsValid)
                    {
                          
                        trProduccion.Id = Guid.NewGuid();
                        trProduccion.PeriodoTiempoFin = trProduccion.PeriodoTiempoInicio + duration;
                        trProduccion.FinReal = trProduccion.PeriodoTiempoInicio + duration;
                        trProduccion.InicioReal = trProduccion.PeriodoTiempoInicio;
                          trProduccion.IdTipoProduccion = new Guid("0635A247-9429-4466-B7B0-81FC2929D49F");

                        TrParada trParada = new TrParada();

                        if (trProduccion.Productividad < 1)
                        {

                            trParada.Id = Guid.NewGuid();
                            trParada.IdMotivoParada = new Guid("DB6D3E87-0948-49BC-B9F6-92BCBEB406A3");
                            trParada.Horas = 1 - trProduccion.Productividad;
                            trParada.PeriodoTiempoInicio = trProduccion.PeriodoTiempoInicio;
                            trParada.PeriodoTiempoFin = trProduccion.PeriodoTiempoFin;
                            trParada.InicioReal = trProduccion.PeriodoTiempoInicio;
                            trParada.FinReal = trProduccion.PeriodoTiempoFin;
                            trParada.IdTrMovimiento = trProduccion.IdTrMovimiento;
                        }

                        _context.Add(trProduccion);
                        if (trProduccion.Productividad < 1)
                        {
                            _context.Add(trParada);
                        }

                        //If productividad de la hora <1 y pruct
                        _context.SaveChanges();

                        //Registrar productividad de la hora
                        IEnumerable<SIT.Models.TrMovimientosDetalle> Trmovimientodetalle = _context.TrMovimientosDetalle.Include(t => t.IdDetalleDeParadaNavigation).Include(t => t.IdMotivoParadaNavigation).Include(t => t.IdTipoProduccionNavigation).Where(trpr => trpr.IdTrMovimiento == trProduccion.IdTrMovimiento & trpr.PeriodoTiempoInicio== trProduccion.PeriodoTiempoInicio);
                        IEnumerable<SIT.Models.TrMovimientosDetalle> items= _context.TrMovimientosDetalle.Include(t => t.IdDetalleDeParadaNavigation).Include(t => t.IdMotivoParadaNavigation).Include(t => t.IdTipoProduccionNavigation).Where(trpr => trpr.IdTrMovimiento == trProduccion.IdTrMovimiento & trpr.PeriodoTiempoInicio == trProduccion.PeriodoTiempoInicio & trpr.IdTipoProduccionNavigation.TipoProduccion1 == "Productividad de Linea") ;
                        //Si aun no hay productividad de linea , insertar una nueva.
                        int item = items.Count();
                        if (item<=0)
                        {
                            TrProduccion trProduccionLinea = new TrProduccion();

                            trProduccionLinea.Id = Guid.NewGuid();
                            trProduccionLinea.IdTipoProduccion = new Guid("96472E15-3BA3-4C94-992C-1C6CC4D652DB");
                            trProduccionLinea.PeriodoTiempoInicio = trProduccion.PeriodoTiempoInicio;
                            trProduccionLinea.PeriodoTiempoFin = trProduccion.PeriodoTiempoFin;
                            trProduccionLinea.InicioReal = trProduccion.PeriodoTiempoInicio;
                            trProduccionLinea.FinReal = trProduccion.PeriodoTiempoFin;
                            trProduccionLinea.IdTrMovimiento = trProduccion.IdTrMovimiento;
                            trProduccionLinea.Disponibles = Trmovimientodetalle.Select(t => t.Disponibles).Average();
                            trProduccionLinea.Productiva = Trmovimientodetalle.Select(t => t.Productiva).Sum();
                            trProduccionLinea.Productividad = trProduccion.Productiva/ trProduccion.Disponibles;
                            //Calcular disponible, producido y productividad

                            _context.Add(trProduccionLinea);
                            _context.SaveChanges();

                        } else
                        {
                           //sino actualizar la productividad de la hora
                            IEnumerable<SIT.Models.TrMovimientosDetalle> trdetalle = _context.TrMovimientosDetalle.Include(t => t.IdDetalleDeParadaNavigation).Include(t => t.IdMotivoParadaNavigation).Include(t => t.IdTipoProduccionNavigation).Where(trpr => trpr.IdTrMovimiento == trProduccion.IdTrMovimiento & trpr.PeriodoTiempoInicio == trProduccion.PeriodoTiempoInicio & trpr.IdTipoProduccionNavigation.TipoProduccion1 == "Produccion");

                            IEnumerable<SIT.Models.TrProduccion> ProduccionTr = _context.TrProduccion.Include(t => t.IdTipoProduccionNavigation).Where(trpr => trpr.IdTrMovimiento == trProduccion.IdTrMovimiento & trpr.PeriodoTiempoInicio == trProduccion.PeriodoTiempoInicio & trpr.IdTipoProduccionNavigation.TipoProduccion1 == "Productividad de Linea");

                            TrProduccion objeto = ProduccionTr.First();
                            objeto.Disponibles = trdetalle.Select(t => t.Disponibles).Average();
                            objeto.Productiva = trdetalle.Select(t => t.Productiva).Sum();
                            objeto.Productividad = trdetalle.Select(t => t.Productiva).Sum() / trdetalle.Select(t => t.Disponibles).Average();
                           

                            _context.Update(objeto);
                            _context.SaveChanges();

                            if (objeto.Productiva < 1){
                                //Seleccionar parada compensada de la hora
                                IEnumerable<SIT.Models.TrParada> paradaCompensada = _context.TrParada.Include(t=>t.IdMotivoParadaNavigation).Include(t => t.IdDetalleDeParadaNavigation).Where(trpr => trpr.IdTrMovimiento == trProduccion.IdTrMovimiento & trpr.PeriodoTiempoInicio == trProduccion.PeriodoTiempoInicio & trpr.IdMotivoParadaNavigation.MotivoDeParada1 == "Ritmo Descompensado");
                                TrParada objetoparada = paradaCompensada.First();
                                //Actualizar parada compensada


                                objetoparada.Horas = 1 - objeto.Productiva;
                               
                              
                                _context.Update(objetoparada);
                                _context.SaveChanges();
                            }
                            else
                            {
                                IEnumerable<SIT.Models.TrParada> paradaCompensada = _context.TrParada.Include(t => t.IdMotivoParadaNavigation).Include(t => t.IdDetalleDeParadaNavigation).Where(trpr => trpr.IdTrMovimiento == trProduccion.IdTrMovimiento & trpr.PeriodoTiempoInicio == trProduccion.PeriodoTiempoInicio & trpr.IdMotivoParadaNavigation.MotivoDeParada1 == "Ritmo Descompensado");
                                IEnumerable<SIT.Models.TrParada>  objetoparadacompensada = (IEnumerable<TrParada>)paradaCompensada;
                                //Borrar parada compensada
                                foreach(TrParada element in objetoparadacompensada)
                                {
                                    _context.Remove(element);
                                   
                                }
                                _context.SaveChanges();
                            }
                        }



                        trProduccion.PeriodoTiempoInicio = trProduccion.PeriodoTiempoInicio + duration;
                }
               
                }
                resultado.Ok = true;
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
        [HttpPost]
        public JsonResult SaveTrParada(TrParada trParada)
        {
            var resultado = new BaseRespuesta();
  
            try
            {
                if (ModelState.IsValid)
                {
                    TimeSpan horas;
                    if (Double.IsNaN((double)trParada.Horas))
                    {
                        horas = ((TimeSpan)(trParada.PeriodoTiempoFin - trParada.PeriodoTiempoInicio));
                        trParada.Horas = (float?)horas.TotalHours;
                    }
                    horas = ((TimeSpan)(trParada.PeriodoTiempoFin - trParada.PeriodoTiempoInicio));

                    for (int i = 1; i <= trParada.Horas; i++)
                    { 

                    }
                        trParada.Id = Guid.NewGuid();
                    _context.Add(trParada);
                    _context.SaveChanges();


                    //Cambiar el disponible de la hora y la productividad de la linea




                }
                   resultado.Ok = true;
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

        [HttpPost]
        public JsonResult ERMovimientoManual(TrMovimiento trmovimiento)
        {
            var resultado = new BaseRespuesta();
            try
            {
           
                    IEnumerable<SIT.Models.TrMovimiento> ListaMovimiento = _context.TrMovimiento.Where(trMovimiento => trMovimiento.IdEstado.ToString() == "1E49CBEA-D13A-4CC4-B608-EE9E8D32ADC5" & trMovimiento.Id == trmovimiento.Id);
                    IEnumerable<SIT.Models.Actividad> ListaActividad = _context.Actividad.Include(t=>t.IdOperacionNavigation).Where(Actividad => Actividad.Id == ListaMovimiento.Select(a => a.IdActividad).First());
                           
                resultado.Ok = true;
                resultado.Mensaje = "Actividad: " + ListaActividad.Select(a => a.Actividad1).First().ToString() + "\n Operacion: " + ListaActividad.Select(a => a.IdOperacionNavigation.Operacion1).First().ToString()+ "\n ER: " + ListaActividad.Select(a => a.Er).First().ToString();

                return Json(resultado);
            }
            catch (Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
                return Json(resultado);

            }
        }


        public void SaveTrParadaCompensada(TrParada trParada)
        {
            var resultado = new BaseRespuesta();
            try
            {
                if (ModelState.IsValid)
                {
                    trParada.Id = Guid.NewGuid();
                     _context.Add(trParada);
                    _context.SaveChangesAsync();
                }
      
            }
            catch (Exception ex)
            {
             

            }
        }
        public void SaveTrProductividadDeLinea(TrParada trParada)
        {
            var resultado = new BaseRespuesta();
            try
            {
                if (ModelState.IsValid)
                {
                    trParada.Id = Guid.NewGuid();
                    _context.Add(trParada);
                    _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {


            }

        }
        public void UpdateTrProductividadDeLinea(TrParada trParada)
        {
            var resultado = new BaseRespuesta();
            try
            {

                if (ModelState.IsValid)
                {
                    trParada.Id = Guid.NewGuid();
                    _context.Update(trParada);
                    _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {


            }

        }

    }
}
