using HotelBooking.Application.Interfaces;
using HotelBooking.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelBooking.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {

            return Json(null);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(User user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }

        [HttpPost("edit")]
        public IActionResult Edit(User user)
        {
           
            return Ok();
        }

    }
}
