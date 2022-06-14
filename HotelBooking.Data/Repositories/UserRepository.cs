
using DiyetisyeniSec.Data.Repositories;
using HotelBooking.Data.Repositories.Interfaces;
using HotelBooking.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }


        public List<User> GetAll(int userId)
        {
            return _context.Users.Where(x => x.Id == userId)
                  .ToList();


        }
    }
}
       