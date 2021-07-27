using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

namespace SIT.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public SectorsAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/SectorsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sector>>> GetSector(string tokens)
        {

            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


               // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
               throw new Exception("Acceso no autorizado");
            


            }


            return await _context.Sector.ToListAsync();

        }

        // GET: api/SectorsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sector>> GetSector(Guid id)
        {
            var sector = await _context.Sector.FindAsync(id);

            if (sector == null)
            {
                return NotFound();
            }

            return sector;
        }

        // PUT: api/SectorsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSector(Guid id, Sector sector)
        {
            if (id != sector.Id)
            {
                return BadRequest();
            }

            _context.Entry(sector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectorExists(id))
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

        // POST: api/SectorsAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Sector>> PostSector(Sector sector)
        {
            _context.Sector.Add(sector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSector", new { id = sector.Id }, sector);
        }

        // DELETE: api/SectorsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sector>> DeleteSector(Guid id)
        {
            var sector = await _context.Sector.FindAsync(id);
            if (sector == null)
            {
                return NotFound();
            }

            _context.Sector.Remove(sector);
            await _context.SaveChangesAsync();

            return sector;
        }

        private bool SectorExists(Guid id)
        {
            return _context.Sector.Any(e => e.Id == id);
        }
    }
}
