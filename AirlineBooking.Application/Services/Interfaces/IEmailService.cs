using AirlineBooking.Application.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Application.Services.Interfaces
{
    public interface IEmailService
    {

        void SendWelcome(EmailMessage message);
        void SendEmailConfirmation(EmailMessage message, UserInfo info);
        void SendResetPassword(EmailMessage message,UserInfo info);
    }
}
