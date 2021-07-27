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
    public class RecursoesAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public RecursoesAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/RecursoesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recurso>>> GetRecurso(string tokens)
        {
            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }

            return await _context.Recurso.ToListAsync();
        }

        // GET: api/RecursoesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recurso>> GetRecurso(Guid id, string tokens)
        {
            var recurso = await _context.Recurso.FindAsync(id);

            if (recurso == null)
            {
                return NotFound();
            }

            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }

            return recurso;
        }

        // PUT: api/RecursoesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecurso(Guid id, Recurso recurso)
        {
            if (id != recurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(recurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecursoExists(id))
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

        // POST: api/RecursoesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Recurso>> PostRecurso(Recurso recurso)
        {
            _context.Recurso.Add(recurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecurso", new { id = recurso.Id }, recurso);
        }

        // DELETE: api/RecursoesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recurso>> DeleteRecurso(Guid id)
        {
            var recurso = await _context.Recurso.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }

            _context.Recurso.Remove(recurso);
            await _context.SaveChangesAsync();

            return recurso;
        }

        private bool RecursoExists(Guid id)
        {
            return _context.Recurso.Any(e => e.Id == id);
        }
    }
}
