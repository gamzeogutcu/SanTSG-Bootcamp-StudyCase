using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Models;
using  HotelBooking.Data;
using HotelBooking.Domain.Users;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HotelBooking.Application.Services
{

    public class UserService : IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork unitOfWork, IEmailService emailService, ILogger<UserService> logger)  
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task CreateUser(User user)
        {
           
                
            _unitOfWork.Users.Add(user);

            MailRequest mail = new MailRequest()
            {
                Body = "Your registration has been successfully received.",
                Subject = "HotelBooking Registration Confirmation",
                ToEmail = user.Email
            };

            await _emailService.SendEmailAsync(mail);
            _unitOfWork.Complete();
            _logger.LogInformation("Added a new user record, added record {user}", user);
        }
    }
}
