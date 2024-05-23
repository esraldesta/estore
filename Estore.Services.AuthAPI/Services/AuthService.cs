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
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		public AuthService(AppDbContext db, 
							UserManager<ApplicationUser> userManager, 
							RoleManager<IdentityRole> roleManager,IJwtTokenGenerator jwtTokenGenerator) { 
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtTokenGenerator = jwtTokenGenerator;
		}
		async Task<string> IAuthService.Register(RegistrationRequestDto registrationRequestDto)
		{
			ApplicationUser user = new()
			{
				UserName = registrationRequestDto.Email,
				Email = registrationRequestDto.Email,
				NormalizedEmail = registrationRequestDto.Email.ToUpper(),
				Name = registrationRequestDto.Name,
				PhoneNumber = registrationRequestDto.PhoneNumber
			};
			try { 
				var result =await _userManager.CreateAsync(user,registrationRequestDto.Password);
				if (result.Succeeded)
				{
					return "";
				}
				else {
					return result.Errors.FirstOrDefault().Description;
				}
			}
			catch (Exception ex)
			{
				return "Error encountered";
			}
		}

		async Task<LoginResponseDto> IAuthService.Login(LoginRequestDto loginRequestDto)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
			bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
			if (user == null || isValid == false) {
				return new LoginResponseDto() { User=null,Token=""};
			}
			var token = _jwtTokenGenerator.GenerateToken(user);
			UserDto userDto = new() {
				Email = user.Email,
				Id = user.Id,
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};

			LoginResponseDto loginResponseDto = new LoginResponseDto() { 
				User = userDto,
				Token=token
			};
			return loginResponseDto;
		}

		public async Task<bool> assignRole(string email, string roleName)
		{
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    //create role if it does not exist
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;

        }
	}
}
