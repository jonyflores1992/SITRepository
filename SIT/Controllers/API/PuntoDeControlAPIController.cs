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
    public class PuntoDeControlAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public PuntoDeControlAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/PuntoDeControlAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuntoDeControl>>> GetPuntoDeControls(string tokens)
        {
            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }
            return await _context.PuntoDeControl.ToListAsync();
        }

        // GET: api/PuntoDeControlAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PuntoDeControl>> GetPuntoDeControl(Guid id)
        {
            var puntoDeControl = await _context.PuntoDeControl.FindAsync(id);

            if (puntoDeControl == null)
            {
                return NotFound();
            }

            return puntoDeControl;
        }

        // PUT: api/PuntoDeControlAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuntoDeControl(Guid id, PuntoDeControl puntoDeControl)
        {
            if (id != puntoDeControl.Id)
            {
                return BadRequest();
            }

            _context.Entry(puntoDeControl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntoDeControlExists(id))
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

        // POST: api/PuntoDeControlAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PuntoDeControl>> PostPuntoDeControl(PuntoDeControl puntoDeControl)
        {
            _context.PuntoDeControl.Add(puntoDeControl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPuntoDeControl", new { id = puntoDeControl.Id }, puntoDeControl);
        }

        // DELETE: api/PuntoDeControlAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PuntoDeControl>> DeletePuntoDeControl(Guid id)
        {
            var puntoDeControl = await _context.PuntoDeControl.FindAsync(id);
            if (puntoDeControl == null)
            {
                return NotFound();
            }

            _context.PuntoDeControl.Remove(puntoDeControl);
            await _context.SaveChangesAsync();

            return puntoDeControl;
        }

        private bool PuntoDeControlExists(Guid id)
        {
            return _context.PuntoDeControl.Any(e => e.Id == id);
        }
    }
}
