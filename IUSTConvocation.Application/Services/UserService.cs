#region using

using AutoMapper;
using IUSTConvocation.Application.Abstractions.Identity;
using IUSTConvocation.Application.Abstractions.IEmailService;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.Abstractions.IServices;
using IUSTConvocation.Application.Abstractions.JWT;
using IUSTConvocation.Application.Abstractions.TemplateRenderer;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Application.Shared;
using IUSTConvocation.Application.Utils;
using IUSTConvocation.Domain.Entities;
using IUSTConvocation.Domain.Enums;
using Microsoft.Extensions.Configuration;


#endregion


namespace IUSTConvocation.Application.Services;

public class UserService : IUserService
{
	private readonly IUserRepository repository;
	private readonly IMapper mapper;
	private readonly IConfiguration configuration;
	private readonly IFileService fileService;
	private readonly IEmailService emailService;
	private readonly IContextService contextService;
	private readonly IEmailTemplateRenderer emailTemplateRenderer;
	private readonly IJwtProvider jwtProvider;
	public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration, IFileService fileService, IEmailService emailService,
		IContextService contextService,  IEmailTemplateRenderer emailTemplateRenderer, IJwtProvider jwtProvider)
	{
		this.repository = repository;
		this.mapper = mapper;
		this.configuration = configuration;
		this.fileService = fileService;
		this.emailService = emailService;
		this.contextService = contextService;
		this.emailTemplateRenderer = emailTemplateRenderer;
		this.jwtProvider = jwtProvider;
	}


	public async Task<APIResponse<SignUpResponse>> SignUp(StudentSignupRequest model)
	{

		if (await repository.FirstOrDefaultAsync<User>(x => x.Username == model.UserName) is not null)
		{
			return APIResponse<SignUpResponse>.ErrorResponse(message: "Username is already taken.", APIStatusCodes.Conflict);
		}


		if (await repository.FirstOrDefaultAsync<User>(x => x.Username == model.Email) is not null)
		{
			return APIResponse<SignUpResponse>.ErrorResponse(message: "Email already registered.", APIStatusCodes.Conflict);
		}

		var user = mapper.Map<StudentSignupRequest, User>(model);
		user.Salt = AppEncryption.GenerateSalt();
		user.Password = AppEncryption.HashPassword(model.Password, user.Salt);

		user.ConfirmationCode = await GenerateConfirmationCode();
	

        user.UserStatus = UserStatus.Pending;
		user.IsEmailVerified = false;
		user.UserRole = UserRole.Student;

        var student = mapper.Map<StudentSignupRequest, Student>(model);
        user.Student = student;

        if (await repository.InsertAsync(user) > 0)
		{
			var emailSetting = new MailSetting()
			{
				To = new List<string>() { user.Email },

				Subject = APIMessages.ConfirmEmailSubject,
				Body = await emailTemplateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.EmailConfirmation, new
				{
					UserName = user.Username,
					PhoneNumber = user.ContactNo,
					Password = model.Password,
					CompanyName = APIMessages.ProjectName,
					Link = $"{contextService.HttpContextClientURL()}{AppRoutes.ClientVerifyEmailRoute}?token={user.ConfirmationCode}",
					ConfirmationCode = user.ConfirmationCode
				})

			};

			await emailService.SendEmailAsync(emailSetting);
			return APIResponse<SignUpResponse>.SuccessResponse(mapper.Map<User, SignUpResponse>(user), "Account created successfully!", APIStatusCodes.Created);

		}
		return APIResponse<SignUpResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

	}

	public async Task<APIResponse<SignUpResponse>> AdminSignUp(UserSignUpRequest model)
	{

		if (await repository.FirstOrDefaultAsync<User>(user => user.Email == model.Email) is not null)
		{
			return APIResponse<SignUpResponse>.ErrorResponse("Email already registered", APIStatusCodes.Conflict);
		}

		if (await repository.FirstOrDefaultAsync<User>(user => user.Username == model.Email) is not null)
		{
			return APIResponse<SignUpResponse>.ErrorResponse("Username already taken", APIStatusCodes.Conflict);
		}

        User user = mapper.Map<UserSignUpRequest, User>(model);

		user.Username = model.Email;
		user.Salt = AppEncryption.GenerateSalt();
		string password = $"{model.Name + new Random().Next(999, 9999)}";
		user.Password = AppEncryption.HashPassword(password, user.Salt);
		user.UserStatus = UserStatus.Active;
		user.IsEmailVerified = true;
		user.CreatedBy = contextService.GetUserId();

		if (model.UserRole == UserRole.Student)
		{
			Student student = new()
			{
				Id = user.Id,
				Name = model.Name,
				DepartemntId=model.DepartemntId
			};
			user.Student = student;
		}

		else if (model.UserRole == UserRole.Employee)
		{
			Employee employee = new()
			{
				Id = user.Id,
                Name = model.Name,
                DepartemntId = model.DepartemntId,
                Designation = model.Designation,
			};
			user.Employee = employee;
		}

        if ((await repository.InsertAsync(user) > 0))
        {
            var emailSetting = new MailSetting()
            {
                To = new List<string>() { user.Email },

                Subject = "Welcome to IUST- IUSTConvocation system",
                Body = await emailTemplateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.WelcomeEmailWithUserInfo, new
                {
					Name= model.UserRole ==UserRole.Admin ? user.Username : model.Name,
                    UserName = user.Username,
                    Password = password,
                    PhoneNumber = user.ContactNo,
                    CompanyName = APIMessages.ProjectName,
                    Link = $"{contextService.HttpContextClientURL()}/{AppRoutes.loginRoute}",
                })
            };
            await emailService.SendEmailAsync(emailSetting);
			var userRespnse=mapper.Map<SignUpResponse>(user);
           
            return APIResponse<SignUpResponse>.SuccessResponse(userRespnse, $"Account ({model.UserRole}) Added Successfully!", APIStatusCodes.Created);
        }
            return APIResponse<SignUpResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
	}


    public async Task<APIResponse<LoginResponse>> LogIn(LoginRequest model)
	{
		var user = (await repository.FirstOrDefaultAsync<User>(user => user.Username == model.UserName));

		if (user is null) return APIResponse<LoginResponse>.ErrorResponse("Invalid Credentials", APIStatusCodes.NotFound);
       
		
		if (user.UserStatus == UserStatus.InActive)
            return APIResponse<LoginResponse>.ErrorResponse(message: "Your account is blocked please contact admin", APIStatusCodes.BadRequest);

       
		if (AppEncryption.HashPassword(model.Password, user.Salt) != user.Password)
		{
			return APIResponse<LoginResponse>.ErrorResponse(message: "Invalid credentials", APIStatusCodes.BadRequest);
		}

		var loginResponse =
			new LoginResponse
			{
				UserName = user.Username,
				UserRole = user.UserRole,
				Token = jwtProvider.GenerateToken(user),
				IsEmailVerified = user.IsEmailVerified,
			};

        if (!user.IsEmailVerified)
            return APIResponse<LoginResponse>.SuccessResponse(loginResponse, APIMessages.Auth.VerifyEmailError);

        return APIResponse<LoginResponse>.SuccessResponse(loginResponse);
    }

    public async Task<APIResponse<string>> ChangePassword(ChangePasswordRequest model)
	{
        var id = contextService.GetUserId();
		var user = await repository.FirstOrDefaultAsync<User>(user => user.Id == id);
		if (user is null) return APIResponse<string>.ErrorResponse("User not found", APIStatusCodes.NotFound);

		if (AppEncryption.HashPassword(model.OldPassword, user.Salt) != user.Password)
		{
			return APIResponse<string>.ErrorResponse("Old password is incorrect", APIStatusCodes.BadRequest);
		}

		user.Salt = AppEncryption.GenerateSalt();
		user.Password = AppEncryption.HashPassword(model.NewPassword, user.Salt);

		int returnValue = await repository.UpdateAsync<User>(user);
		if (returnValue > 0) return APIResponse<string>.SuccessResponse("Password Changed successfully", APIStatusCodes.OK);

		return APIResponse<string>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

	}

	public async Task<APIResponse<SignUpResponse>> VerifyEmail(VerifyEmailRequest model)
	{
        var user = await repository.FirstOrDefaultAsync<User>(x=>x.ConfirmationCode.Trim() == model.ConfirmationCode.Trim());

		if (user is null)  return APIResponse<SignUpResponse>.ErrorResponse("Email verification code has been expired/or recheck your email.", APIStatusCodes.BadRequest);
		
        user.IsEmailVerified = true;
        //user.UserStatus = UserStatus.Active;
        user.ConfirmationCode = string.Empty;
		int returnValue = await repository.UpdateAsync(user);

		if (returnValue > 0)
			return APIResponse<SignUpResponse>.SuccessResponse(mapper.Map<SignUpResponse>(user), "Account verified succesfully", APIStatusCodes.OK);
		
		return APIResponse<SignUpResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
    }

    public async Task<APIResponse<string>> ResendConfirmationCode()
	{
		var userId = contextService.GetUserId();
		var user = await repository.FirstOrDefaultAsync<User>(user => user.Id == userId);

		if (user is null) return APIResponse<string>.ErrorResponse("No users found", APIStatusCodes.NotFound);

		user!.ConfirmationCode = AppEncryption.GetRandomConfirmationCode();

		if (await repository.UpdateAsync<User>(user) <= 0)
		{
			return APIResponse<string>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);
		}

		string htmlTemplate = await fileService.ReadEmailTemplate("EmailConfirmation.html");

		var newHtmlTemplate = htmlTemplate.Replace("[CONFIRMATIONCODE]", user.ConfirmationCode);

		if (await emailService.SendEmailAsync(new MailSetting
		{
			To = new List<string> { user.Email },
			Subject = "Email Confirmation",
			Body = newHtmlTemplate,
		}))

			return APIResponse<string>.SuccessResponse("Check your email for verification email", ResponseMessages.EmailSent, APIStatusCodes.OK);

		return APIResponse<string>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError);

	}

	public async Task<APIResponse<SignUpResponse>> ForgotPassword(ForgotPasswordRequest model)
	{
        var user = await repository.FirstOrDefaultAsync<User>(user => user.Email == model.Email);

        if (user is null) return APIResponse<SignUpResponse>.ErrorResponse("No User found Please enter registered email", APIStatusCodes.NotFound);

		user.ResetCode = await GenerateConfirmationCode(); //AppEncryption.GetRandomConfirmationCode();
        int updateResult = await repository.UpdateAsync(user);

        if (updateResult > 0)
        {
            var emailSetting = new MailSetting()
            {
                To = new List<string>() { user.Email },

                Subject = APIMessages.PasswordResetEmailSubject,

                Body = await emailTemplateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.PasswordReset, new
                {
                    CompanyName = APIMessages.ProjectName,
                    Link = $"{contextService.HttpContextClientURL()}/{AppRoutes.ClientResetPasswordRoute}?resetCode={user.ResetCode}"
                })
            };

            await emailService.SendEmailAsync(emailSetting);
			return APIResponse<SignUpResponse>.SuccessResponse(mapper.Map<SignUpResponse>(user), ResponseMessages.EmailSent, APIStatusCodes.OK);
        }
		//var resetEmail = (await fileService.ReadEmailTemplate("PasswordReset.html")).Replace("[RESETCODE]", user.ResetCode);
		return APIResponse<SignUpResponse>.ErrorResponse(ResponseMessages.EmailSendingError, APIStatusCodes.InternalServerError);
	}

	public async Task<APIResponse<SignUpResponse>> ResetPassword(ResetPasswordRequest model)
	{

		var user = await repository.FirstOrDefaultAsync<User>(user => user.ResetCode == model.ResetCode);

		if (user is null)
			return APIResponse<SignUpResponse>.ErrorResponse("Reset code invalid or Expired", APIStatusCodes.BadRequest);


		user.Salt = AppEncryption.GenerateSalt();
		user.Password = AppEncryption.HashPassword(model.NewPassword, user.Salt);

		return await repository.UpdateAsync(user) switch
		{
			> 0 => APIResponse<SignUpResponse>.SuccessResponse(mapper.Map<SignUpResponse>(user), "Password changed successfully", APIStatusCodes.OK),
			_ => APIResponse<SignUpResponse>.ErrorResponse(ResponseMessages.ServerError, APIStatusCodes.InternalServerError)
		};

	}

	private async Task<string> GenerateConfirmationCode()
	{
		string randomValue = AppEncryption.GetRandomConfirmationCode();

		var user = await repository.FirstOrDefaultAsync<User>(x => x.ConfirmationCode == randomValue);
		while (user is not null)
		{
            randomValue = AppEncryption.GetRandomConfirmationCode();
            user = await repository.FirstOrDefaultAsync<User>(x => x.ConfirmationCode == randomValue);
        }
		return randomValue;
    }
}