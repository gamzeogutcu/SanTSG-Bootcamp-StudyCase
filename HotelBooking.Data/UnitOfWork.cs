using HotelBooking.Data.Repositories;
using HotelBooking.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
       
        void Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {

        private readonly UserDbContext _context;
        public IUserRepository Users { get; private set; }
       
        public UnitOfWork(UserDbContext context)
        {
            _context = context;

            Users = new UserRepository(context);
            
        }



        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
