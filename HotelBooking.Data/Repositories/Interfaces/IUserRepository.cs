using HotelBooking.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        List<User> GetAll(int userId);
    }
}
