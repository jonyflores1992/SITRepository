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
    public class OperacionsAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public OperacionsAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/OperacionsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operacion>>> GetOperacion(string tokens)
        {
            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }
            return await _context.Operacion.ToListAsync();
        }

        // GET: api/OperacionsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operacion>> GetOperacion(Guid id)
        {
            var operacion = await _context.Operacion.FindAsync(id);

            if (operacion == null)
            {
                return NotFound();
            }

            return operacion;
        }

        // PUT: api/OperacionsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacion(Guid id, Operacion operacion)
        {
            if (id != operacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(operacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionExists(id))
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

        // POST: api/OperacionsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Operacion>> PostOperacion(Operacion operacion)
        {
            _context.Operacion.Add(operacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacion", new { id = operacion.Id }, operacion);
        }

        // DELETE: api/OperacionsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operacion>> DeleteOperacion(Guid id)
        {
            var operacion = await _context.Operacion.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }

            _context.Operacion.Remove(operacion);
            await _context.SaveChangesAsync();

            return operacion;
        }

        private bool OperacionExists(Guid id)
        {
            return _context.Operacion.Any(e => e.Id == id);
        }
    }
}
