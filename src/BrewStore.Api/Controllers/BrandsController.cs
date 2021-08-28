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
    public class BrandsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        const string cacheKey = "brands";

        public BrandsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands([FromServices] IDistributedCache cache)
        {
            IEnumerable<Brand> result;
            var cachedData = await cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(cachedData))
            {
                result = await _context.Brands.ToListAsync();
                await cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                });
            }
            else
            {
                result = JsonSerializer.Deserialize<IEnumerable<Brand>>(cachedData);
            }
            return Ok(result);
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand([FromServices] IDistributedCache cache, Guid id)
        {
            var cachedKeyWithId = getCacheKeyWithId(id);
            Brand result;

            var cachedData = await cache.GetStringAsync(cacheKey);
            if (string.IsNullOrWhiteSpace(cachedData))
            {
                result = await _context.Brands.FindAsync(id);

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
                result = JsonSerializer.Deserialize<Brand>(cachedData);
            }
            return Ok(result);
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand([FromServices] IDistributedCache cache, Guid id, Brand brand)
        {
            if (id != brand.Id)
            {
                return BadRequest();
            }

            _context.Entry(brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand([FromServices] IDistributedCache cache, Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();

            await cache.RemoveAsync(cacheKey);

            return CreatedAtAction("GetBrand", new { id = brand.Id }, brand);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand([FromServices] IDistributedCache cache, Guid id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();

            await cache.RemoveAsync(cacheKey);
            await cache.RemoveAsync(getCacheKeyWithId(id));

            return NoContent();
        }

        private bool BrandExists(Guid id)
        {
            return _context.Brands.Any(e => e.Id == id);
        }

        private string getCacheKeyWithId(Guid id) => $"{cacheKey}_{id}";
    }
}
