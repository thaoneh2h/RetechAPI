using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private IUserAddressService _useraddressservice;

        public UserAddressController(IUserAddressService useraddressservice)
        {
            _useraddressservice = useraddressservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _useraddressservice.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var address = await _useraddressservice.GetByIdAsync(id);
            return address != null ? Ok(address) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserAddressDTO dto)
        {
            await _useraddressservice.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.UserAddressId }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserAddressDTO dto)
        {
            if (id != dto.UserAddressId) return BadRequest();
            await _useraddressservice.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _useraddressservice.DeleteAsync(id);
            return NoContent();
        }
    }
}
