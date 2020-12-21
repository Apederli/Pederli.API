using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pederli.Data.Concrete.EntityFreamwork.Configuration;
using Pederli.Data.Concrete.EntityFreamwork.Seeds;
using Pederli.Entity;

namespace Pederli.Data.Concrete.EntityFreamwork
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryCanfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] {1, 2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] {1, 2}));
        }
    }

    
}
