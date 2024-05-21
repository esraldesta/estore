using Estore.Services.AuthAPI.Models.Dto;

namespace Estore.Services.AuthAPI.Services.Iservice
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDto registrationRequestDto);
		Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
	}
}
