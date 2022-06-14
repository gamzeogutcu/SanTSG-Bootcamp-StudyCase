using HotelBooking.Application.Models;
using HotelBooking.Application.Services;
using HotelBooking.Application.Interfaces;
using HotelBooking.Data;
using HotelBooking.Data.Repositories.Interfaces;
using HotelBooking.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HotelBooking.Web.Controllers
{
    // to define action methods required to make a post request to the server
    // and submit user details to the server 
    public class UserController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
       
        
        public UserController(UserDbContext context, IUserRepository userRepository, IUserService userService, ILogger<UserController> logger)
        {
            _context = context;
            _userRepository = userRepository;
            _userService = userService;
            _logger = logger;
            
        }
        public IActionResult Index()
        {
            var user = _userRepository.GetAll();
            _logger.LogInformation("Listed users");
            return View(user);
            
        }
        //two steps within two Create() methods within our UserController class:
        //One method will show the <form> that the user should fill out to create a new user.
        //The second method will handle processing the posted data when the user submits the <form>
        //back to the server, and save a new user within our database
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
           
            if (ModelState.IsValid)
            {
                user.RegistrationDate = DateTime.Now;
                await _userService.CreateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public IActionResult Edit(int? id)
        {
            if (id.GetValueOrDefault() == 0)
                return NotFound();

            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();
            
            return View(user);


        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
           
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                _logger.LogInformation("Edited a user,edited user {user}", user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.SaveChanges();
            _logger.LogInformation("Deleted a user,deleted user {user}", user);
            return RedirectToAction("Index");
        }

    }
}
