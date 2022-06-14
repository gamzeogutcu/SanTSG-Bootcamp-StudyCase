using HotelBooking.Domain.Users;
using System.Threading.Tasks;


namespace HotelBooking.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
    }
}
