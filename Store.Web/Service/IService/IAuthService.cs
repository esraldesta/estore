using Store.Web.Models;

namespace Store.Web.Service.IService
{
	public interface IAuthService
	{
		public Task<ResponseDto?> LoginAsync(LoginRequestDto LoginRequestDto);
		public Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
		public Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
	}
}
