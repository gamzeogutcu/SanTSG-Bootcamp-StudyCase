using HotelBooking.Application.Models;
using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{//Service classes that is actually responsible to send Mails
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
