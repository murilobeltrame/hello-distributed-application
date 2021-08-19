using BrewStore.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BrewStore.Api.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var beer = new Kind { Id = Guid.NewGuid(), Name = "Beer" };
            var wine = new Kind { Id = Guid.NewGuid(), Name = "Wine" };
            var kinds = new[] { beer, wine };

            modelBuilder.Entity<Kind>().HasData(kinds);

            var adriatica = new Brand { Id = Guid.NewGuid(), Name = "Adriatica" };
            var andes = new Brand { Id = Guid.NewGuid(), Name = "Andes" };
            var antarctica = new Brand { Id = Guid.NewGuid(), Name = "Antarctica" };
            var becks = new Brand { Id = Guid.NewGuid(), Name = "Beck`s" };
            var berrio = new Brand { Id = Guid.NewGuid(), Name = "Berrió" };
            var bohemia = new Brand { Id = Guid.NewGuid(), Name = "Bohemia" };
            var brahma = new Brand { Id = Guid.NewGuid(), Name = "Brahma" };
            var bucanero = new Brand { Id = Guid.NewGuid(), Name = "Bucanero" };
            var budweiser = new Brand { Id = Guid.NewGuid(), Name = "Budweiser" };
            var caracu = new Brand { Id = Guid.NewGuid(), Name = "Caracu" };
            var colorado = new Brand { Id = Guid.NewGuid(), Name = "Colorado" };
            var corona = new Brand { Id = Guid.NewGuid(), Name = "Corona" };
            var esmera = new Brand { Id = Guid.NewGuid(), Name = "Esmera" };
            var franziskaner = new Brand { Id = Guid.NewGuid(), Name = "Franziskaner" };
            var goose = new Brand { Id = Guid.NewGuid(), Name = "Goose Island" };
            var hertog = new Brand { Id = Guid.NewGuid(), Name = "Hertog Jan" };
            var hoegaarden = new Brand { Id = Guid.NewGuid(), Name = "Hoegaarden" };
            var kona = new Brand { Id = Guid.NewGuid(), Name = "Kona" };
            var leffe = new Brand { Id = Guid.NewGuid(), Name = "Leffe" };
            var legitima = new Brand { Id = Guid.NewGuid(), Name = "Legítima" };
            var lowenbrau = new Brand { Id = Guid.NewGuid(), Name = "Löwenbräu" };
            var magnifica = new Brand { Id = Guid.NewGuid(), Name = "Magnífica" };
            var michelob = new Brand { Id = Guid.NewGuid(), Name = "Michelob" };
            var modelo = new Brand { Id = Guid.NewGuid(), Name = "Modelo" };
            var nortena = new Brand { Id = Guid.NewGuid(), Name = "Norteña" };
            var nossa = new Brand { Id = Guid.NewGuid(), Name = "Nossa" };
            var original = new Brand { Id = Guid.NewGuid(), Name = "Original" };
            var patagonia = new Brand { Id = Guid.NewGuid(), Name = "Patagonia" };
            var polar = new Brand { Id = Guid.NewGuid(), Name = "Polar" };
            var quilmes = new Brand { Id = Guid.NewGuid(), Name = "Quilmes" };
            var serramalte = new Brand { Id = Guid.NewGuid(), Name = "Serramalte" };
            var serrana = new Brand { Id = Guid.NewGuid(), Name = "Serrana" };
            var skol = new Brand { Id = Guid.NewGuid(), Name = "Skol" };
            var spaten = new Brand { Id = Guid.NewGuid(), Name = "Spaten" };
            var stella = new Brand { Id = Guid.NewGuid(), Name = "Stella Artois" };
            var fidalgas = new Brand { Id = Guid.NewGuid(), Name = "Três Fidalgas" };
            var wals = new Brand { Id = Guid.NewGuid(), Name = "Wäls" };
            var dante = new Brand { Id = Guid.NewGuid(), Name = "Dante Robino" };
            var babe = new Brand { Id = Guid.NewGuid(), Name = "Babe" };
            var brands = new[] {
                adriatica, andes, antarctica,
                becks, berrio, bohemia, brahma, bucanero, budweiser,
                caracu, colorado, corona,
                esmera,
                franziskaner,
                goose,
                hertog, hoegaarden,
                kona,
                leffe, legitima, lowenbrau,
                magnifica, michelob, modelo,
                nortena, nossa,
                original,
                patagonia, polar,
                quilmes,
                serramalte, serrana, skol, spaten, stella,
                fidalgas,
                wals,
                dante, babe
            };

            modelBuilder.Entity<Brand>().HasData(brands);
        }
    }
}