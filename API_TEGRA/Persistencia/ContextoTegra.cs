using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.IO;

using System;
using API_TEGRA.Modelo;

namespace API_TEGRA.Persistencia
{
    public class ContextoTegra : DbContext

    {
        public ContextoTegra(DbContextOptions<ContextoTegra>options): base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Operation_Type> Operation_Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Box>()
               .HasOne(b => b.Product)
               .WithMany(q => q.Boxes)
               .HasForeignKey(f => f.Id_Product);

            modelBuilder.Entity<Operation>()
               .HasOne(b => b.Box)
               .WithMany(q => q.Operations)
               .HasForeignKey(f => f.Id_Box);

            modelBuilder.Entity<Operation>()
           .HasOne(b => b.Operation_Type)
           .WithMany(q => q.Operations)
           .HasForeignKey(f => f.Id_Operation_Type);
        }

    }
}
