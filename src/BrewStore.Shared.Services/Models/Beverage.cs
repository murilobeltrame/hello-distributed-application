using System;

namespace BrewStore.Shared.Services.Models
{
    public class Beverage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public Kind Kind { get; set; }
        public Guid KindId { get; set; }
    }
}
