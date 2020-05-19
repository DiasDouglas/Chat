using Chat.Models;
using Chat.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetUsers();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> GetById(long id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpGet]
        [Route("get-by-email")]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            var user = await _userService.GetByEmail(email);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            var createdUser = await _userService.Create(user);

            if (createdUser == null)
                return StatusCode(500, "An error occurred while creating user.");

            return createdUser;
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            var updatedUser = await _userService.Update(user);

            if (updatedUser == null)
                return StatusCode(500, "An error occurred while updating user.");

            return updatedUser;
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(User user)
        {
            var deletedUser = await _userService.Delete(user);

            if (deletedUser == null)
                return StatusCode(500, "An error occurred while deleting user.");

            return deletedUser;
        }
    }
}
