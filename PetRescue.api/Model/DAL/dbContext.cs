using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetRescue.api.Model;

namespace PetRescue.api.Model
{
    public class dbContext : DbContext
    {

        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Username=postgres;Password=123456;Database=pet_rescue;");
            }
        }

        public virtual DbSet<Specie> Specie { get; set; }
        public virtual DbSet<Age> Age { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Breed> Breed { get; set; }
        public virtual DbSet<Hair> Hair { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
    }
}
