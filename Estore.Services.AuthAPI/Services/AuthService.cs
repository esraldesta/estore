﻿using Estore.Services.AuthAPI.Data;
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
			// token
			UserDto userDto = new() {
				Email = user.Email,
				Id = user.Id,
				Name = user.Name,
				PhoneNumber = user.PhoneNumber
			};

			LoginResponseDto loginResponseDto = new LoginResponseDto() { 
				User = userDto,
				Token=""
			};
			return loginResponseDto;
		}
	}
}
