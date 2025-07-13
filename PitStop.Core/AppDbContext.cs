using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PitStop.Core.Entities;
using System;
using System.Reflection.Metadata;

namespace PitStop.Core
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Indexes
            modelBuilder.Entity<Customer>().HasIndex(c => c.Lastname);
            modelBuilder.Entity<Customer>().HasIndex(c => c.Telephone);
            modelBuilder.Entity<Customer>().HasIndex(c => c.Mobile);
        }
    }
}
