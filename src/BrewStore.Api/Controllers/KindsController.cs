using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewStore.Api.Data;
using BrewStore.Api.Models;

namespace BrewStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KindsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public KindsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Kinds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kind>>> GetKinds()
        {
            return await _context.Kinds.ToListAsync();
        }

        // GET: api/Kinds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kind>> GetKind(Guid id)
        {
            var kind = await _context.Kinds.FindAsync(id);

            if (kind == null)
            {
                return NotFound();
            }

            return kind;
        }

        // PUT: api/Kinds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKind(Guid id, Kind kind)
        {
            if (id != kind.Id)
            {
                return BadRequest();
            }

            _context.Entry(kind).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindExists(id))
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

        // POST: api/Kinds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kind>> PostKind(Kind kind)
        {
            _context.Kinds.Add(kind);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKind", new { id = kind.Id }, kind);
        }

        // DELETE: api/Kinds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKind(Guid id)
        {
            var kind = await _context.Kinds.FindAsync(id);
            if (kind == null)
            {
                return NotFound();
            }

            _context.Kinds.Remove(kind);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KindExists(Guid id)
        {
            return _context.Kinds.Any(e => e.Id == id);
        }
    }
}
