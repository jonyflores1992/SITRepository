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
    public class LecturaAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public LecturaAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/LecturaAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lectura>>> GetLectura()
        {
            return await _context.Lectura.ToListAsync();
        }

        // GET: api/LecturaAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lectura>> GetLectura(Guid id)
        {
            var lectura = await _context.Lectura.FindAsync(id);

            if (lectura == null)
            {
                return NotFound();
            }

            return lectura;
        }

        // PUT: api/LecturaAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLectura(Guid id, Lectura lectura)
        {
            if (id != lectura.Id)
            {
                return BadRequest();
            }

            _context.Entry(lectura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturaExists(id))
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

        // POST: api/LecturaAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lectura>> PostLectura(Lectura lectura)
        {
            _context.Lectura.Add(lectura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLectura", new { id = lectura.Id }, lectura);
        }

        // DELETE: api/LecturaAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lectura>> DeleteLectura(Guid id)
        {
            var lectura = await _context.Lectura.FindAsync(id);
            if (lectura == null)
            {
                return NotFound();
            }

            _context.Lectura.Remove(lectura);
            await _context.SaveChangesAsync();

            return lectura;
        }

        private bool LecturaExists(Guid id)
        {
            return _context.Lectura.Any(e => e.Id == id);
        }
    }
}
