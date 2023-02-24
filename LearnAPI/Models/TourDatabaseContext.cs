using Microsoft.EntityFrameworkCore;
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
        public DbSet<ToursCities> ToursCities { get; set;}
        public DbSet<ToursSight> ToursSights { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToursCities>()
                  .HasKey(tc => new { tc.CityId, tc.TourId });
            modelBuilder.Entity<ToursCities>()
                .HasOne(t => t.Tour)
                .WithMany(tc => tc.ToursCities)
                .HasForeignKey(t => t.TourId);
            modelBuilder.Entity<ToursCities>()
                .HasOne(c => c.City)
                .WithMany(tc => tc.ToursCities)
                .HasForeignKey(c => c.CityId);

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
