using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.Infrastructure.Configurations
{
    public class EmailOptions
    {
        public const string SECTION_NAME = "MailSettings";
        [Required(ErrorMessage ="From is required")]
        public required string From { get; set; }
        [Required(ErrorMessage ="Smtp server is requried")]
        public required string SmtpServer { get; set; }
        [Required(ErrorMessage ="Port is required")]
        [Range(1, int.MaxValue)]
        public int Port { get; set; }
        [Required(ErrorMessage ="Username is required")]
        public required string Username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public required string Password { get; set; }



    }
}
