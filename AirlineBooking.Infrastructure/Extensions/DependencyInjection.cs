using AirlineBooking.Application.Services.Interfaces;
using AirlineBooking.Infrastructure.Configurations;
using AirlineBookingSystem.Domain.Repositories;
using AirlineBookingSystem.Infrastructure.Persistance;
using AirlineBookingSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineBooking.Infrastructure.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<ISeatRepository, SeatRepository>();
        services.AddScoped<IPassengerRepository, PassengerRepository>();
   


        services.AddScoped<IEmailService, IEmailService>();

        services.AddDbContext<AirlineBookingDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AirlineBookingDbContextConnection")));

        services
            .AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;


                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;


                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            })

            .AddEntityFrameworkStores<AirlineBookingDbContext>()
            .AddDefaultTokenProviders();


        services
            .AddOptions<EmailOptions>()
            .Bind(configuration.GetSection(EmailOptions.SECTION_NAME))
            .ValidateDataAnnotations()
            .ValidateOnStart();



        return services;
    }
}
