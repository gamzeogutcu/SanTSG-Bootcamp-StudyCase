using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Web.Models.Request.Authentication
{
    public class LoginRequest
    {
            public string Agency { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
        }
    }

