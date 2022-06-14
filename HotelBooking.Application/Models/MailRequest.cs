using System;
using System.Collections.Generic;
using System.Text;
//We will need parameters like Email, Subject, Body in the Request Model 
//so that these data can be passed on to the service layer. 
namespace HotelBooking.Application.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
