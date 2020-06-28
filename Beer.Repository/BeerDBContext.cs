using Beer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beer.Repository
{
    public sealed class BeerDBContext : DbContext
    {
        public BeerDBContext(DbContextOptions options) : base(options) { }

        public DbSet<BeerModel> Beers { get; set; }        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerModel>()
          .HasKey(a => new { a.BeerId });

            modelBuilder.Entity<BeerModel>().HasData(
             new BeerModel  { BeerId = 1, Name="Sample Beer 1", Type = "Pale Ale" },
             new BeerModel  { BeerId = 2, Name="Sample Beer 2", Type = "Stout" }             
             );            
        }
    }
}
