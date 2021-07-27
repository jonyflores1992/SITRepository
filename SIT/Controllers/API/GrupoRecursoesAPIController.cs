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
    public class GrupoRecursoesAPIController : ControllerBase
    {
        private readonly UserContext _context;

        public GrupoRecursoesAPIController(UserContext context)
        {
            _context = context;
        }

        // GET: api/GrupoRecursoesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoRecurso>>> GetGrupoRecurso(string tokens)
        {
            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }

            return await _context.GrupoRecurso.ToListAsync();
        }

        // GET: api/GrupoRecursoesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoRecurso>> GetGrupoRecurso(Guid id, string tokens)
        {
            var grupoRecurso = await _context.GrupoRecurso.FindAsync(id);

            if (grupoRecurso == null)
            {
                return NotFound();
            }
            if (!tokensApi.tokenGetSucursales.Equals(tokens))
            {


                // return await (Task<ActionResult<IEnumerable<Sector>>>)Enumerable.Empty<Sector>();
                throw new Exception("Acceso no autorizado");



            }

            return grupoRecurso;
        }

        // PUT: api/GrupoRecursoesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoRecurso(Guid id, GrupoRecurso grupoRecurso)
        {
            if (id != grupoRecurso.Id)
            {
                return BadRequest();
            }

            _context.Entry(grupoRecurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrupoRecursoExists(id))
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

        // POST: api/GrupoRecursoesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GrupoRecurso>> PostGrupoRecurso(GrupoRecurso grupoRecurso)
        {
            _context.GrupoRecurso.Add(grupoRecurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrupoRecurso", new { id = grupoRecurso.Id }, grupoRecurso);
        }

        // DELETE: api/GrupoRecursoesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GrupoRecurso>> DeleteGrupoRecurso(Guid id)
        {
            var grupoRecurso = await _context.GrupoRecurso.FindAsync(id);
            if (grupoRecurso == null)
            {
                return NotFound();
            }

            _context.GrupoRecurso.Remove(grupoRecurso);
            await _context.SaveChangesAsync();

            return grupoRecurso;
        }

        private bool GrupoRecursoExists(Guid id)
        {
            return _context.GrupoRecurso.Any(e => e.Id == id);
        }
    }
}
