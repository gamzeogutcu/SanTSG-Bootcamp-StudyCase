using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Domain.Users
{
   public class User
    {
        //User informations
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual DateTime? RegistrationDate { get; set; } 

        public bool IsActive { get; set; } = false;
    }
}
