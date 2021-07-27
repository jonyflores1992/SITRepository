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
    public class TrMovimientosAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public TrMovimientosAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/TrMovimientosAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrMovimiento>>> GetTrMovimiento()
        {
            return await _context.TrMovimiento.ToListAsync();
        }

        // GET: api/TrMovimientosAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrMovimiento>> GetTrMovimiento(Guid id)
        {
            var trMovimiento = await _context.TrMovimiento.FindAsync(id);

            if (trMovimiento == null)
            {
                return NotFound();
            }

            return trMovimiento;
        }

        // PUT: api/TrMovimientosAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrMovimiento(Guid id, TrMovimiento trMovimiento)
        {
            if (id != trMovimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(trMovimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrMovimientoExists(id))
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

        // POST: api/TrMovimientosAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TrMovimiento>> PostTrMovimiento(TrMovimiento trMovimiento)
        {
            _context.TrMovimiento.Add(trMovimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrMovimiento", new { id = trMovimiento.Id }, trMovimiento);
        }

        // DELETE: api/TrMovimientosAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TrMovimiento>> DeleteTrMovimiento(Guid id)
        {
            var trMovimiento = await _context.TrMovimiento.FindAsync(id);
            if (trMovimiento == null)
            {
                return NotFound();
            }

            _context.TrMovimiento.Remove(trMovimiento);
            await _context.SaveChangesAsync();

            return trMovimiento;
        }

        private bool TrMovimientoExists(Guid id)
        {
            return _context.TrMovimiento.Any(e => e.Id == id);
        }
    }
}
