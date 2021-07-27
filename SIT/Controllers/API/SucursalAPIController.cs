using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIT.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public SucursalAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/SectorsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursal(string tokens)
        {

            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }


            return await _context.Sucursal.ToListAsync();

        }

        // GET: api/SectorsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(Guid id)
        {
            var sucursal = await _context.Sucursal.FindAsync(id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        // PUT: api/SectorsAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(Guid id, Sucursal sucursal)
        {
            if (id != sucursal.Id)
            {
                return BadRequest();
            }

            _context.Entry(sucursal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExists(id))
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
        public async Task<ActionResult<Sucursal>> PostSucursal(Sucursal sucursal)
        {
            _context.Sucursal.Add(sucursal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSucursal", new { id = sucursal.Id }, sucursal);
        }

        // DELETE: api/SectorsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sucursal>> DeleteSucursal(Guid id)
        {
            var sucursal = await _context.Sucursal.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursal.Remove(sucursal);
            await _context.SaveChangesAsync();

            return sucursal;
        }

        private bool SucursalExists(Guid id)
        {
            return _context.Sucursal.Any(e => e.Id == id);
        }
    }
}
