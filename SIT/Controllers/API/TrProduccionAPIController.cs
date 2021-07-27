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
    public class TrProduccionAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public TrProduccionAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/TrProduccionAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrProduccion>>> GetTrProduccion()
        {
            return await _context.TrProduccion.ToListAsync();
        }

        // GET: api/TrProduccionAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrProduccion>> GetTrProduccion(Guid id)
        {
            var trProduccion = await _context.TrProduccion.FindAsync(id);

            if (trProduccion == null)
            {
                return NotFound();
            }

            return trProduccion;
        }

        // PUT: api/TrProduccionAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrProduccion(Guid id, TrProduccion trProduccion)
        {
            if (id != trProduccion.Id)
            {
                return BadRequest();
            }

            _context.Entry(trProduccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrProduccionExists(id))
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

        // POST: api/TrProduccionAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TrProduccion>> PostTrProduccion(TrProduccion trProduccion)
        {
            _context.TrProduccion.Add(trProduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrProduccion", new { id = trProduccion.Id }, trProduccion);
        }

        // DELETE: api/TrProduccionAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrProduccion>> DeleteTrProduccion(Guid id)
        {
            var trProduccion = await _context.TrProduccion.FindAsync(id);
            if (trProduccion == null)
            {
                return NotFound();
            }

            _context.TrProduccion.Remove(trProduccion);
            await _context.SaveChangesAsync();

            return trProduccion;
        }

        private bool TrProduccionExists(Guid id)
        {
            return _context.TrProduccion.Any(e => e.Id == id);
        }
    }
}
