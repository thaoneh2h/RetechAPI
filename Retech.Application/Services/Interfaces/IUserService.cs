﻿using Retech.Application.Models;
using Retech.Application.Models.RequestModels.Users;
using Retech.Application.Models.ResponeModels.Users;
using Retech.Core.DTOS;
using Retech.Core.Models;
using System.Security.Claims;

namespace Retech.Application.Services
{
    public interface IUserService
    {
        Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel);
        Task CreateUserWithAutoGeneratedPassword(CreateUserWithNoPasswordRequest request, string role);
        Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
        Task LoginCookiesAsync(LoginUserModel loginUserModel);
        Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel);
        Task<BaseResponseModel> ChangePasswordAsync(Guid userId, ChangePasswordModel changePasswordModel);
        Task<UserResponse> GetDetails(Guid userId);
        Task SendPhoneVerificationCode(SendCodeRequest request, Guid userId);
        Task VerifyPhoneNumber(VerifyPhoneNumberRequest request, Guid userId);
        //Task RefreshToken();
        Task Logout();
        Task LoginWithFacebookAsync(string accessToken);
        Task LoginGoogle(IEnumerable<Claim> claims);

    }
}
