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
    public class BeveragesController : ControllerBase
    {
        private readonly ApplicationContext _context;
        const string cacheKey = "beverages";

        public BeveragesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Beverages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetBeverages([FromServices] IDistributedCache cache)
        {
            IEnumerable<Beverage> result;
            var cachedData = await cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(cachedData))
            {
                result = await _context.Beverages
                    .Include(i => i.Brand)
                    .Include(i => i.Kind)
                    .ToListAsync();
                await cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                });
            }
            else
            {
                result = JsonSerializer.Deserialize<IEnumerable<Beverage>>(cachedData);
            }
            return Ok(result);
        }

        // GET: api/Beverages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beverage>> GetBeverage([FromServices] IDistributedCache cache, Guid id)
        {
            var cachedKeyWithId = getCacheKeyWithId(id);
            Beverage result;

            var cachedData = await cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(cachedData))
            {
                result = await _context.Beverages
                    .Include(i => i.Brand)
                    .Include(i => i.Kind)
                    .Where(w => w.Id == id)
                    .FirstOrDefaultAsync();
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
                result = JsonSerializer.Deserialize<Beverage>(cachedData);
            }
            return Ok(result);
        }

        // PUT: api/Beverages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeverage([FromServices] IDistributedCache cache, Guid id, Beverage beverage)
        {
            if (id != beverage.Id)
            {
                return BadRequest();
            }

            _context.Entry(beverage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeverageExists(id))
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

        // POST: api/Beverages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beverage>> PostBeverage([FromServices] IDistributedCache cache, Beverage beverage)
        {
            _context.Beverages.Add(beverage);
            await _context.SaveChangesAsync();

            await cache.RemoveAsync(cacheKey);

            return CreatedAtAction("GetBeverage", new { id = beverage.Id }, beverage);
        }

        // DELETE: api/Beverages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeverage([FromServices] IDistributedCache cache, Guid id)
        {
            var beverage = await _context.Beverages.FindAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }

            _context.Beverages.Remove(beverage);
            await _context.SaveChangesAsync();

            await cache.RemoveAsync(cacheKey);
            await cache.RemoveAsync(getCacheKeyWithId(id));

            return NoContent();
        }

        private bool BeverageExists(Guid id)
        {
            return _context.Beverages.Any(e => e.Id == id);
        }

        private string getCacheKeyWithId(Guid id) => $"{cacheKey}_{id}";
    }
}
