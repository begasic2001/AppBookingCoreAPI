﻿using Microsoft.EntityFrameworkCore;
namespace LearnAPI.Models
{
    public class TourDatabaseContext : DbContext
    {
        public TourDatabaseContext(DbContextOptions<TourDatabaseContext> options): base(options){

        }
        public DbSet<User> User { get; set; }  
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }   
        public DbSet<Sight> Sight { get; set; }
        public DbSet<Transport> Transport { get; set; }
        public DbSet<Tour> Tour { get; set; }
        //public DbSet<ToursCities> ToursCities { get; set;}
        public DbSet<ToursSight> ToursSights { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tour>()
                .HasMany(tc => tc.ToursCities)
                .WithOne(t => t.Tour)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<City>()
                .HasMany(tc => tc.ToursCities)
                .WithOne(c => c.City)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ToursSight>()
                  .HasKey(ts => new { ts.SightId, ts.TourId });
            modelBuilder.Entity<ToursSight>()
                .HasOne(t => t.Tour)
                .WithMany(ts => ts.ToursSights)
                .HasForeignKey(t => t.TourId);
            modelBuilder.Entity<ToursSight>()
                .HasOne(c => c.Sight)
                .WithMany(ts => ts.ToursSights)
                .HasForeignKey(c => c.SightId);
        }
    }
}
