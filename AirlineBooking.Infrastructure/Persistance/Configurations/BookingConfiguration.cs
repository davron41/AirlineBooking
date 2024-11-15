using AirlineBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Infrastructure.Persistance.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable(nameof(Booking));
            builder.HasKey(b => b.Id);

            builder
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.User.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        
            builder
                .HasMany(b => b.Flights)
                .WithOne(f => f.Booking)
                .HasForeignKey(f => f.Booking.Id)   
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();  

          
        }
    }
}
