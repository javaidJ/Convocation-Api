using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;

namespace IUSTConvocation.Application.Abstractions.IServices;

public interface IUserService
{
    Task<APIResponse<SignUpResponse>> SignUp(StudentSignupRequest model);


    Task<APIResponse<LoginResponse>> LogIn(LoginRequest model);


    Task<APIResponse<SignUpResponse>> AdminSignUp(UserSignUpRequest model);


    Task<APIResponse<SignUpResponse>> ForgotPassword(ForgotPasswordRequest model);


    Task<APIResponse<string>> ChangePassword(ChangePasswordRequest model);


    Task<APIResponse<SignUpResponse>> VerifyEmail(VerifyEmailRequest model);


    Task<APIResponse<string>> ResendConfirmationCode();

    Task<APIResponse<SignUpResponse>> ResetPassword(ResetPasswordRequest model);
}
