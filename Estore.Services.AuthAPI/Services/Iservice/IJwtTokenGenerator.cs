using Estore.Services.AuthAPI.Models;

namespace Estore.Services.AuthAPI.Services.Iservice
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUser applicationUser);
	}
}
