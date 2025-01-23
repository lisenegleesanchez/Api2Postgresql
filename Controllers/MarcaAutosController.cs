using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api2Postgresql.Context;
using Api2Postgresql.Models;
using Api2Postgresql.Repository;

namespace Api2Postgresql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaAutosController  : ControllerBase
    {
        private readonly AutosDbContext _context;

        public MarcaAutosController(AutosDbContext context)
        {
            _context = context;
        }

        // GET: api/MarcaAutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autos>>> GetMarcaAutos()
        {
            return await _context.MarcaAutos.ToListAsync();
        }

        // GET: api/MarcaAutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autos>> GetAutos(int id)
        {
            var autos = await _context.MarcaAutos.FindAsync(id);

            if (autos == null)
            {
                return NotFound();
            }

            return autos;
        }

        // PUT: api/MarcaAutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutos(int id, Autos autos)
        {
            if (id != autos.Id)
            {
                return BadRequest();
            }

            _context.Entry(autos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutosExists(id))
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

        // POST: api/MarcaAutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autos>> PostAutos(Autos autos)
        {
            _context.MarcaAutos.Add(autos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutos", new { id = autos.Id }, autos);
        }

        // DELETE: api/MarcaAutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutos(int id)
        {
            var autos = await _context.MarcaAutos.FindAsync(id);
            if (autos == null)
            {
                return NotFound();
            }

            _context.MarcaAutos.Remove(autos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutosExists(int id)
        {
            return _context.MarcaAutos.Any(e => e.Id == id);
        }
    }
}
