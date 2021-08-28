using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using BrewStore.Data;
using BrewStore.Data.Models;

namespace BrewStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KindsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        const string cacheKey = "kinds";

        public KindsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Kinds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kind>>> GetKinds([FromServices] IDistributedCache cache)
        {
            IEnumerable<Kind> result;
            var cachedData = await cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(cachedData))
            {
                result = await _context.Kinds.ToListAsync();
                await cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                });
            }
            else
            {
                result = JsonSerializer.Deserialize<IEnumerable<Kind>>(cachedData);
            }
            return Ok(result);
        }

        // GET: api/Kinds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kind>> GetKind([FromServices] IDistributedCache cache, Guid id)
        {
            var cachedKeyWithId = getCacheKeyWithId(id);
            Kind result;

            var cachedData = await cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(cachedData))
            {
                result = await _context.Kinds.FindAsync(id);

                if (result == null)
                {
                    return NotFound();
                }
                await cache.SetStringAsync(cachedKeyWithId, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                });
            }
            else
            {
                result = JsonSerializer.Deserialize<Kind>(cachedData);
            }
            return Ok(result);
        }

        // PUT: api/Kinds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKind([FromServices] IDistributedCache cache, Guid id, Kind kind)
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

            await cache.RemoveAsync(cacheKey);
            await cache.RemoveAsync(getCacheKeyWithId(id));

            return NoContent();
        }

        // POST: api/Kinds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kind>> PostKind([FromServices] IDistributedCache cache, Kind kind)
        {
            _context.Kinds.Add(kind);
            await _context.SaveChangesAsync();

            await cache.RemoveAsync(cacheKey);

            return CreatedAtAction("GetKind", new { id = kind.Id }, kind);
        }

        // DELETE: api/Kinds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKind([FromServices] IDistributedCache cache, Guid id)
        {
            var kind = await _context.Kinds.FindAsync(id);
            if (kind == null)
            {
                return NotFound();
            }

            _context.Kinds.Remove(kind);
            await _context.SaveChangesAsync();

            await cache.RemoveAsync(cacheKey);
            await cache.RemoveAsync(getCacheKeyWithId(id));

            return NoContent();
        }

        private bool KindExists(Guid id)
        {
            return _context.Kinds.Any(e => e.Id == id);
        }

        private string getCacheKeyWithId(Guid id) => $"{cacheKey}_{id}";
    }
}
