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

            var beverages = new[] {
                new Beverage{Id=Guid.NewGuid(), BrandId=adriatica.Id, KindId=beer.Id, Name="Adriática"},
                new Beverage{ Id = Guid.NewGuid(), BrandId = adriatica.Id, KindId = beer.Id, Name = "Adriática" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = andes.Id, KindId = beer.Id, Name = "Andes" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = antarctica.Id, KindId = beer.Id, Name = "Cristal" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = antarctica.Id, KindId = beer.Id, Name = "Pilsen" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = antarctica.Id, KindId = beer.Id, Name = "Subzero" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = becks.Id, KindId = beer.Id, Name = "Beck's" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = berrio.Id, KindId = beer.Id, Name = "Berrió do Piauí" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = bohemia.Id, KindId = beer.Id, Name = "14-Weiss" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = bohemia.Id, KindId = beer.Id, Name = "838 Pale Ale" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = bohemia.Id, KindId = beer.Id, Name = "Aura Lager" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = bohemia.Id, KindId = beer.Id, Name = "Imperial" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = bohemia.Id, KindId = beer.Id, Name = "Magna Pils" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = bohemia.Id, KindId = beer.Id, Name = "Puro Malte" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "Chopp" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "Duplo Malte" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "Extra Lager" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "Extra Red Lager" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "Extra Weiss" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "Malzbier" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "Refresh" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = brahma.Id, KindId = beer.Id, Name = "0" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = bucanero.Id, KindId = beer.Id, Name = "Bucanero" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = budweiser.Id, KindId = beer.Id, Name = "Budweiser" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = caracu.Id, KindId = beer.Id, Name = "Caracu" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Appia" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Berthó" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Cauim" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Cauim 016" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Demoiselle" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Eugênia" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Guanabara" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Indica" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Ithaca" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Murica" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Nassau" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Ribeirão Lager" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Rosália" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = colorado.Id, KindId = beer.Id, Name = "Vixnu" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = corona.Id, KindId = beer.Id, Name = "Corona" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = corona.Id, KindId = beer.Id, Name = "Coronita" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = esmera.Id, KindId = beer.Id, Name = "Esmera do Goiás" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = franziskaner.Id, KindId = beer.Id, Name = "Dunkel" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = franziskaner.Id, KindId = beer.Id, Name = "Hell" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = franziskaner.Id, KindId = beer.Id, Name = "Kristall-Klar" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = goose.Id, KindId = beer.Id, Name = "Ipa" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = goose.Id, KindId = beer.Id, Name = "Honkers Ale" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = goose.Id, KindId = beer.Id, Name = "Midway" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = goose.Id, KindId = beer.Id, Name = "Sofie" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = hertog.Id, KindId = beer.Id, Name = "Jan Dubbel" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = hertog.Id, KindId = beer.Id, Name = "Jan Grand Prestige" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = hertog.Id, KindId = beer.Id, Name = "Jan Tripel" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = hoegaarden.Id, KindId = beer.Id, Name = "Forbidden Fruit" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = hoegaarden.Id, KindId = beer.Id, Name = "Grand Cru" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = hoegaarden.Id, KindId = beer.Id, Name = "Wit Blanche" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = kona.Id, KindId = beer.Id, Name = "Big Wave" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = kona.Id, KindId = beer.Id, Name = "Long Board" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = leffe.Id, KindId = beer.Id, Name = "Blonde" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = leffe.Id, KindId = beer.Id, Name = "Brown" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = leffe.Id, KindId = beer.Id, Name = "Radieuse" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = leffe.Id, KindId = beer.Id, Name = "Rituel 9º" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = leffe.Id, KindId = beer.Id, Name = "Royale" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = leffe.Id, KindId = beer.Id, Name = "Ruby" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = leffe.Id, KindId = beer.Id, Name = "Vieille Cuvée" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = legitima.Id, KindId = beer.Id, Name = "Legítima" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = lowenbrau.Id, KindId = beer.Id, Name = "Löwenbräu" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = magnifica.Id, KindId = beer.Id, Name = "Magnífica" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = michelob.Id, KindId = beer.Id, Name = "Michelob Ultra" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = modelo.Id, KindId = beer.Id, Name = "Modelo" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = nortena.Id, KindId = beer.Id, Name = "Norteña" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = nossa.Id, KindId = beer.Id, Name = "Nossa" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = original.Id, KindId = beer.Id, Name = "Antarctica Original" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = patagonia.Id, KindId = beer.Id, Name = "Amber Lager" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = patagonia.Id, KindId = beer.Id, Name = "Bohemian Pilsener" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = patagonia.Id, KindId = beer.Id, Name = "Weisse" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = polar.Id, KindId = beer.Id, Name = "Polar" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = quilmes.Id, KindId = beer.Id, Name = "Quilmes" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = serramalte.Id, KindId = beer.Id, Name = "Serramalte" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = serrana.Id, KindId = beer.Id, Name = "Serrana" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = skol.Id, KindId = beer.Id, Name = "Pilsen" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = skol.Id, KindId = beer.Id, Name = "Puro Malte" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = spaten.Id, KindId = beer.Id, Name = "Spaten" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = stella.Id, KindId = beer.Id, Name = "Stella Artois" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = stella.Id, KindId = beer.Id, Name = "Stella Artois Sem Glúten" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = fidalgas.Id, KindId = beer.Id, Name = "Três Fidalgas" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "42" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Alambique County" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Belgian Witte" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Berliner" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Bohemiam Pilsner" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Dubbel" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Corn Ipa" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Lager" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Lagoinha" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Niobium" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Petroleum" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Quadruppel" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Session Citra" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Session Free" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Trippel" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "Verano" },
                new Beverage{ Id = Guid.NewGuid(), BrandId = wals.Id, KindId = beer.Id, Name = "X" },
            };

            modelBuilder.Entity<Beverage>().HasData(beverages);
        }
    }
}