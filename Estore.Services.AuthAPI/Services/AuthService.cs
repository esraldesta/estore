using Estore.Services.AuthAPI.Data;
using Estore.Services.AuthAPI.Models;
using Estore.Services.AuthAPI.Models.Dto;
using Estore.Services.AuthAPI.Services.Iservice;
using Microsoft.AspNetCore.Identity;

namespace Estore.Services.AuthAPI.Services
{
	public class AuthService : IAuthService
	{
		private readonly AppDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public AuthService(AppDbContext db, 
							UserManager<ApplicationUser> userManager, 
							RoleManager<IdentityRole> roleManager) { 
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
		}
		Task<UserDto> IAuthService.Register(RegistrationRequestDto registrationRequestDto)
		{
			throw new NotImplementedException();
		}

		Task<LoginResponseDto> IAuthService.Register(LoginRequestDto loginRequestDto)
		{
			throw new NotImplementedException();
		}
	}
}
