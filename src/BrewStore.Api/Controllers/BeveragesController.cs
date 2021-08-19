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
    public class BeveragesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BeveragesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Beverages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetBeverages()
        {
            return await _context.Beverages.ToListAsync();
        }

        // GET: api/Beverages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beverage>> GetBeverage(Guid id)
        {
            var beverage = await _context.Beverages.FindAsync(id);

            if (beverage == null)
            {
                return NotFound();
            }

            return beverage;
        }

        // PUT: api/Beverages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeverage(Guid id, Beverage beverage)
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

            return NoContent();
        }

        // POST: api/Beverages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beverage>> PostBeverage(Beverage beverage)
        {
            _context.Beverages.Add(beverage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeverage", new { id = beverage.Id }, beverage);
        }

        // DELETE: api/Beverages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeverage(Guid id)
        {
            var beverage = await _context.Beverages.FindAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }

            _context.Beverages.Remove(beverage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeverageExists(Guid id)
        {
            return _context.Beverages.Any(e => e.Id == id);
        }
    }
}
