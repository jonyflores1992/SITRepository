using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SIT.Models;
using SIT.Utils;

namespace SIT.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrLecturasController : ControllerBase
    {
        private readonly UserContext _context;

        public TrLecturasController(UserContext context)
        {
            _context = context;
        }

        // GET: api/TrLecturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lectura>>> GetTrLectura(string tokens)
        {
            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }

            return await _context.Lectura.ToListAsync();
        }

        // GET: api/TrLecturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lectura>> GetTrLectura(Guid id)
        {
            var trLectura = await _context.Lectura.FindAsync(id);

            if (trLectura == null)
            {
                return NotFound();
            }

            return trLectura;
        }

        // PUT: api/TrLecturas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrLectura(Guid id, Lectura trLectura)
        {
            if (id != trLectura.Id)
            {
                return BadRequest();
            }

            _context.Entry(trLectura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrLecturaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrLecturas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]

        public  HttpResponseMessage PostTrLectura(string tokens, [FromBody] List<Lectura> trLectura)
        {

            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {
                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");
            }
            var response = new HttpResponseMessage();
            try
            {
                foreach (var item in trLectura)
                {
                    // _context.TrLectura.Add(item);
                    //await _context.SaveChangesAsync();

                    string query = string.Format("Execute dbo.msSP_Insert_Lectura '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}"
                                           , item.CodigoBarra, item.IdPuntoDeControl, item.FechaHoraLector, item.IdSector
                                           , item.IdGrupoRecurso, item.SerialDispositivo, item.Cantidad);

                     _context.Database.ExecuteSqlCommand(query);
                }

                response = new HttpResponseMessage(HttpStatusCode.Accepted);
                response.Content = new StringContent(JsonConvert.SerializeObject(
                                   new Response() { IsSuccess = true, Message = "Success", Result = 1 }));


            }
            catch (Exception e)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject(new Response() { IsSuccess = false, Message = "Error", Result = -1 }));
            }

            return response;

        }
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<Response> PostTrLectura(string tokens,[FromBody] List<Lectura> trLectura)
        //{

        //    if (!tokensApi.tokenGetSucursales.Equals(tokens))
        //    {


        //        // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
        //        throw new Exception("Acceso no autorizado");



        //    }
        //    try
        //    {
        //        foreach (var item in trLectura)
        //        {
        //            // _context.TrLectura.Add(item);
        //            //await _context.SaveChangesAsync();

        //            string query = string.Format("Execute dbo.msSP_Insert_Lectura '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}"
        //                                   , item.CodigoBarra, item.IdPuntoDeControl, item.FechaHoraLector, item.IdSector
        //                                   , item.IdGrupoRecurso, item.SerialDispositivo, item.Cantidad);

        //            await _context.Database.ExecuteSqlCommandAsync(query);
        //        }
        //        return new Response() {
        //         IsSuccess=true,
        //          Message="Success",
        //          Result=1
        //        };

        //    }
        //    catch (Exception e)
        //    {
        //        return new Response()
        //        {
        //            IsSuccess = false,
        //            Message = e.Message,
        //            Result = -1
        //        };
        //        //
        //    }




        //}

        // DELETE: api/TrLecturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lectura>> DeleteTrLectura(Guid id)
        {
            var trLectura = await _context.Lectura.FindAsync(id);
            if (trLectura == null)
            {
                return NotFound();
            }

            _context.Lectura.Remove(trLectura);
            await _context.SaveChangesAsync();

            return trLectura;
        }

        private bool TrLecturaExists(Guid id)
        {
            return _context.Lectura.Any(e => e.Id == id);
        }

        //public Response InsertEntrega(List<Lectura> data)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        using (var db = new IndicadoresEntities())
        //        {
        //            foreach (var item in data)
        //            {
        //                var detalle = item.DetalleEntregas;
        //                string query = $"Execute [RRHH].[msSP_Insert_DetalleEntregas_Api] '{detalle.Identidad}', '{detalle.Fecha.ToString("yyyyMMdd")}', {1}" +
        //                    $", {detalle.Cantidad}, {detalle.Peso}, {detalle.IdUsuario}, {detalle.IdFinca}, '{detalle._Guid}'";
        //                db.Database.ExecuteSqlCommand(query);
        //            }

        //            response.IsSuccess = true;
        //            response.Message = "OK";
        //            response.Result = 1;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = ex.Message.ToString();
        //        response.Result = -1;
        //    }

        //    return response;
        //}




    }
}
