﻿using BrewStore.Data;
using BrewStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BrewStore.Api.GraphQl.Queries
{
    public class Query
    {
        private readonly ApplicationContext _context;

        public Query(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beverage>> GetBeverages(CancellationToken cancellationToken) =>
            await _context.Beverages
                .Include(i => i.Brand)
                .Include(i => i.Kind)
                .ToListAsync(cancellationToken);
    }
}