using AirlineBookingSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace AirlineBookingSystem.Infrastructure.Persistance
{
    public class AirlineBookingDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<Seat> Seats => Set<Seat>();
        public DbSet<Passenger> Passes => Set<Passenger>();

        public AirlineBookingDbContext(DbContextOptions<AirlineBookingDbContext> options) 
            : base(options)
        {   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            #region

            modelBuilder.Entity<IdentityUser<Guid>>(e =>
            {
                e.ToTable("User");

            });

            modelBuilder.Entity<IdentityUserClaim<Guid>>(e =>
            {
                e.ToTable("UserClaim");
            });

            modelBuilder.Entity<IdentityUserLogin<Guid>>(e =>
            {
                e.ToTable("UserLogin");
            });

            modelBuilder.Entity<IdentityUserToken<Guid>>(e =>
            {
                e.ToTable("UserToken");
            });

            modelBuilder.Entity<IdentityRole<Guid>>(e =>
            {
                e.ToTable("Role");
            });

            modelBuilder.Entity<IdentityRoleClaim<Guid>>(e =>
            {
                e.ToTable("RoleClaim");
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>(e =>
            {
                e.ToTable("UserRole");
            });

            #endregion

        }
    }
}
