using IUSTConvocation.Application;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IUserService service;
    public UsersController(IUserService service)
    {
        this.service = service;
    }



    [HttpPost("SignUp")]
    [AllowAnonymous]
    public async Task<APIResponse<SignUpResponse>> SignUp(StudentSignupRequest model) => await service.SignUp(model);


    [HttpPost("signup-user")]
   // [Authorize(Roles = nameof(UserRole.Admin))]
    public async Task<APIResponse<SignUpResponse>> AdminSignUp(UserSignUpRequest model) => await service.AdminSignUp(model);

    [HttpPost("Login")]
    public async Task<APIResponse<LoginResponse>> LogIn([FromBody] LoginRequest model) => await service.LogIn(model);


    [Authorize]
    [HttpPost("ChangePassword")]
    public async Task<APIResponse<string>> ChangePassword([FromBody] ChangePasswordRequest model) => await service.ChangePassword(model);


    [HttpPost("verifyEmail")]
    public async Task<APIResponse<SignUpResponse>> VerifyEmail([FromBody] VerifyEmailRequest model) => await service.VerifyEmail(model);


    [HttpGet("resendConfirmationCode")]
    public async Task<APIResponse<string>> ResendConfirmationCode() => await service.ResendConfirmationCode();

    [HttpPost("forgotPassword")]
    public async Task<APIResponse<SignUpResponse>> ForgotPassword([FromBody] ForgotPasswordRequest model) => await service.ForgotPassword(model);


    [HttpPost("resetPassword")]

    public async Task<APIResponse<SignUpResponse>> ResetPassword([FromBody] ResetPasswordRequest model) => await service.ResetPassword(model);

}
