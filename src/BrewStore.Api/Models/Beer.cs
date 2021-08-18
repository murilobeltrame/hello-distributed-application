using System;

namespace BrewStore.Models
{
    public record Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
    }
}