//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Retech.Application.Common.Email;
//using Retech.Core.DTOS;
//using Retech.Core.Identify;
//using Retech.Core.Models;
//using Retech.Core.Settings;
//using Retech.DataAccess.Repositories;
//using StackExchange.Redis;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Threading.Tasks;

//namespace Retech.Application.Services;

//public class UserService(
//    IMapper mapper,
//    UserManager<ApplicationUser> userManager,
//    SignInManager<ApplicationUser> signInManager,
//    ITemplateService templateService,
//    IEmailService emailService,
//    RoleManager<Role> roleManager,
//    SmtpSettings smtpSettings,
//    IHttpContextAccessor httpContextAccessor,
//    JwtSettings jwtSettings,
//    IUnitOfWork unitOfWork,
//    ISMSService smsService,
//    IFacebookAuthService facebookAuthService)
//    : IUserService
//{
//    private readonly IUserRepository _userRepository;

//    public UserService(IUserRepository userRepository)
//    {
//        _userRepository = userRepository;
//    }

//    // Phương thức lấy thông tin hồ sơ người dùng
//    public async Task<UserProfileDTO> GetUserProfileAsync(Guid userId)
//    {
//        var user = await _userRepository.GetByIdAsync(userId); // Sử dụng UserRepository để lấy dữ liệu
//        if (user == null)
//            throw new Exception("User not found.");

//        return new UserProfileDTO
//        {
//            UserName = user.UserName,
//            Email = user.Email,
//            PhoneNumber = user.PhoneNumber,
//            Address = user.Address,
//            Gender = user.Gender,
//            BirthDate = user.BirthDate,
//            ProfilePicture = user.ProfilePicture // Cung cấp ảnh đại diện
//        };
//    }

//    // Phương thức cập nhật hồ sơ người dùng
//    public async Task UpdateUserProfileAsync(Guid userId, UserProfileDTO userProfileDTO)
//    {
//        var user = await _userRepository.GetByIdAsync(userId);
//        if (user == null)
//            throw new Exception("User not found.");

//        user.UserName = userProfileDTO.UserName;
//        user.Email = userProfileDTO.Email;
//        user.PhoneNumber = userProfileDTO.PhoneNumber;
//        user.Address = userProfileDTO.Address;
//        user.Gender = userProfileDTO.Gender;
//        user.BirthDate = userProfileDTO.BirthDate;
//        user.ProfilePicture = userProfileDTO.ProfilePicture;

//        await _userRepository.SaveAsync(user); // Lưu thay đổi vào cơ sở dữ liệu
//    }


//    public async Task<List<User>> GetUsersAsync()
//    {
//        return await _userRepository.GetAllUsersAsync();
//    }

//    public async Task<User> GetUserByNameAsync(string name)
//    {
//        return await _userRepository.GetUserByNameAsync(name);
//    }

//    public async Task<User> GetUserByEmailAsync(string email)
//    {
//        var user = await _userRepository.GetUserByEmailAsync(email);
//        if (user == null)
//            throw new Exception("User not found.");
//        return user;
//    }

//    public async Task AddUserAsync(User user)
//    {
//        await _userRepository.AddUserAsync(user);
//    }

//    public async Task UpdateUserAsync(User user)
//    {
//        await _userRepository.UpdateUserAsync(user);
//    }

//    public async Task DeleteUserAsync(User user)
//    {
//        await _userRepository.DeleteUserAsync(user);
//    }


//}
