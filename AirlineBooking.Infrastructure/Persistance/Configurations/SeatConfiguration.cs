using AirlineBookingSystem.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Infrastructure.Persistance.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
              builder.ToTable(nameof(Seat));    
              builder.HasKey(x => x.Id);



            builder
                .HasOne(s => s.Passenger)
                .WithOne(p => p.Seat)
                .HasForeignKey<Passenger>(p => p.SeatId)
                .IsRequired();

            builder
                .Property(s => s.IsOccuped)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(s => s.SeatNumber)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();


        }
    }
}
