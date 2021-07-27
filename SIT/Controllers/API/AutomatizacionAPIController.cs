using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomatizacionAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public AutomatizacionAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/AutomatizacionAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Automatizacion>>> GetAutomatizacion(string tokens)
        {


            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }
        return await _context.Automatizacion.ToListAsync();
        }

        // GET: api/AutomatizacionAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Automatizacion>> GetAutomatizacion(Guid id, string tokens)
        {
            var automatizacion = await _context.Automatizacion.FindAsync(id);

            if (automatizacion == null)
            {
                return NotFound();
            }

            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }
            return automatizacion;
        }

        // PUT: api/AutomatizacionAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutomatizacion(Guid id, Automatizacion automatizacion)
        {
            if (id != automatizacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(automatizacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomatizacionExists(id))
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

        // POST: api/AutomatizacionAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Automatizacion>> PostAutomatizacion(Automatizacion automatizacion)
        {
            _context.Automatizacion.Add(automatizacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutomatizacion", new { id = automatizacion.Id }, automatizacion);
        }

        // DELETE: api/AutomatizacionAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Automatizacion>> DeleteAutomatizacion(Guid id)
        {
            var automatizacion = await _context.Automatizacion.FindAsync(id);
            if (automatizacion == null)
            {
                return NotFound();
            }

            _context.Automatizacion.Remove(automatizacion);
            await _context.SaveChangesAsync();

            return automatizacion;
        }

        private bool AutomatizacionExists(Guid id)
        {
            return _context.Automatizacion.Any(e => e.Id == id);
        }
    }
}
