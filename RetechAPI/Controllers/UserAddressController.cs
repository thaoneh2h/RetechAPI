using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Retech.Application.Services;
using Retech.Core.Models;

namespace Retech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;

        public UserAddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        // Lấy danh sách địa chỉ của người dùng
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAddresses(Guid userId)
        {
            var addresses = await _userAddressService.GetUserAddressesAsync(userId);
            return Ok(addresses);
        }

        // Lấy địa chỉ cụ thể theo ID
        [HttpGet("address/{userAddressId}")]
        public async Task<IActionResult> GetUserAddress(Guid userAddressId)
        {
            var address = await _userAddressService.GetUserAddressAsync(userAddressId);
            if (address == null)
            {
                return NotFound("Address not found");
            }
            return Ok(address);
        }

        // Thêm địa chỉ người dùng
        [HttpPost]
        public async Task<IActionResult> AddUserAddress([FromBody] UserAddress userAddress)
        {
            await _userAddressService.AddUserAddressAsync(userAddress);
            return Ok("Address added successfully");
        }

        // Cập nhật địa chỉ người dùng
        [HttpPut]
        public async Task<IActionResult> UpdateUserAddress([FromBody] UserAddress userAddress)
        {
            await _userAddressService.UpdateUserAddressAsync(userAddress);
            return Ok("Address updated successfully");
        }

        // Xóa địa chỉ người dùng
        [HttpDelete("{userAddressId}")]
        public async Task<IActionResult> DeleteUserAddress(Guid userAddressId)
        {
            await _userAddressService.DeleteUserAddressAsync(userAddressId);
            return Ok("Address deleted successfully");
        }
    }
    //Thêm địa chỉ: API POST để thêm địa chỉ mới cho người dùng.
    //Cập nhật địa chỉ: API PUT để cập nhật thông tin địa chỉ người dùng.
    //Xóa địa chỉ: API DELETE để xóa địa chỉ người dùng.
    //Lấy danh sách địa chỉ: API GET để lấy tất cả các địa chỉ của người dùng.
    //Lấy địa chỉ theo ID: API GET để lấy địa chỉ cụ thể theo ID
}
