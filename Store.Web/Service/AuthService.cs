using Store.Web.Models;
using Store.Web.Service.IService;
using Store.Web.Utility;
namespace Store.Web.Service
{
	public class AuthService : IAuthService
	{

		private readonly IBaseService _baseService;
		public AuthService(IBaseService baseService)
		{
			_baseService = baseService;
		}
		public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.POST,
				Data = registrationRequestDto,
				Url = SD.AuthAPIBase + "/api/auth/AssignRole"

			});
		}

		public async Task<ResponseDto?> LoginAsync(LoginRequestDto LoginRequestDto)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.POST,
				Data = LoginRequestDto,
				Url = SD.AuthAPIBase + "/api/auth/login"

			});
		}

		public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.POST,
				Data = registrationRequestDto,
				Url = SD.AuthAPIBase + "/api/auth/register"

			});
		}
	}
}
