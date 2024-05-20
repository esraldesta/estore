using Estore.Services.AuthAPI.Models.Dto;

namespace Estore.Services.AuthAPI.Services.Iservice
{
	public interface IAuthService
	{
		Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
		Task<LoginResponseDto> Register(LoginRequestDto loginRequestDto);
	}
}
