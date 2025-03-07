using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services;
using Retech.Core.DTOS;
using Retech.Core.Models;


namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Lấy hồ sơ người dùng
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserProfile(Guid userId)
        {
            var profile = await _userService.GetUserProfileAsync(userId);
            return Ok(profile);
        }

        // Cập nhật hồ sơ người dùng
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserProfile(Guid userId, [FromBody] UserProfileDTO userProfileDTO)
        {
            await _userService.UpdateUserProfileAsync(userId, userProfileDTO);
            return NoContent();
        }

        // Lấy danh sách người dùng
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        // Lấy người dùng theo tên
        [HttpGet]
        [Route("GetUsersByName")]
        public async Task<IActionResult> GetUser(string name)
        {
            var user = await _userService.GetUserByNameAsync(name);
            if (user == null)
                return NotFound("User not found");
            return Ok(user);
        }

        // Thêm người dùng
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userService.AddUserAsync(user);
            return Ok("User added successfully");
        }

        // Cập nhật người dùng
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok("User updated successfully");
        }

        // Xóa người dùng
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] User user)
        {
            await _userService.DeleteUserAsync(user);
            return Ok("User deleted successfully");
        }

    }
}
