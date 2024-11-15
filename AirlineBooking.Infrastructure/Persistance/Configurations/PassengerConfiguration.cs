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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger)); 
            builder.HasKey(x => x.Id);


            builder
                .HasOne(p => p.Seat)
                .WithOne(s => s.Passenger)
                .HasForeignKey<Passenger>(p => p.SeatId)
                .IsRequired();

            builder
                .Property(p => p.FisrName)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();
            

             builder
                .Property(p => p.LastName)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();
            

             builder
                .Property(p => p.DateOfBirth)
                .IsRequired();
            

             builder
                .Property(p => p.Nationality)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();
            

             builder
                .Property(p => p.PassportNumber)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();
            

             builder
                .Property(p => p.PhoneNumber)
                .HasMaxLength(Constants.DEFAULT_STRING_LENGTH)
                .IsRequired();
            
            builder
                .Property(p => p.Gender)
                .IsRequired();


        }
    }
}
