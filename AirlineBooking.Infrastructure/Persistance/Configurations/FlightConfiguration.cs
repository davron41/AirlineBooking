using AirlineBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Infrastructure.Persistance.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable(nameof(Flight));
            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.From)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();

            builder
                .Property(f => f.To)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();

            builder
                .Property(f => f.Departure)
                .IsRequired();  

            builder
                .Property(f => f.Arrival)
                .IsRequired(false);

            builder
                .Property(f => f.Time)
                .IsRequired();

            builder
                .Property(f => f.Price)
                .IsRequired();
        }
    }
}
