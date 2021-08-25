using System.Collections.Generic;
using System.Threading.Tasks;
using BrewStore.Shared.Services;
using BrewStore.Shared.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BrewStore.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Beverage> Beverages { get; private set; }

        public async Task OnGet([FromServices] BeverageClient client)
        {
            Beverages = await client.GetBeverages();
        }
    }
}
