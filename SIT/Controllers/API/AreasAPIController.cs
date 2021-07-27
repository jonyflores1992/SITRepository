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
    public class AreasAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public AreasAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/AreasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetArea(string tokens)
        {
            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }
            return await _context.Area.ToListAsync();
        }

        // GET: api/AreasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(Guid id)
        {
            var area = await _context.Area.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return area;
        }

        // PUT: api/AreasAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArea(Guid id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            _context.Entry(area).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaExists(id))
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

        // POST: api/AreasAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(Area area)
        {
            _context.Area.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArea", new { id = area.Id }, area);
        }

        // DELETE: api/AreasAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Area>> DeleteArea(Guid id)
        {
            var area = await _context.Area.FindAsync(id);
            if (area == null)
            {
                return NotFound();
            }

            _context.Area.Remove(area);
            await _context.SaveChangesAsync();

            return area;
        }

        private bool AreaExists(Guid id)
        {
            return _context.Area.Any(e => e.Id == id);
        }
    }
}
