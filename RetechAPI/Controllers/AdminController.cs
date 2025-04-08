using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services;
using Retech.Core.DTOS;
using Retech.Core.Models;

namespace Retech.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin")] //authorize only admin users
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("users/getalluser")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _adminService.GetAllUsersAsync(null);
        return Ok(users);
    }

    [HttpGet("users/getbyrole")]
    public async Task<IActionResult> GetAllUsers([FromQuery] string? role)
    {
        var users = await _adminService.GetAllUsersAsync(role);
        return Ok(users);
    }

    [HttpGet("users/getbyid/{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _adminService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDTO userDto)
    {
        var newUser = await _adminService.CreateUserAsync(userDto);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
    }

    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUserAsync(Guid id, [FromBody] UpdateUserDTO updatedUserDto)
    {
        try
        {
            var user = await _adminService.UpdateUserAsync(id, updatedUserDto);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var result = await _adminService.DeleteUserAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
