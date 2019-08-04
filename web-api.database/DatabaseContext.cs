using System;
using Microsoft.EntityFrameworkCore;
using web_api.database.Entities;
using web_api.database.EntityConfiguration;

namespace web_api.database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=db;Port=5432;Database=web-api-storage;Username=bloguser;Password=bloguser");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
