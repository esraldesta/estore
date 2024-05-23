﻿using Estore.Services.AuthAPI.Models.Dto;
using Estore.Services.AuthAPI.Services.Iservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Estore.Services.AuthAPI.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthAPIController : ControllerBase
	{

		private readonly IAuthService _authService;
		protected ResponseDto _response;

		public AuthAPIController(IAuthService authService)
		{
			_authService = authService;
			_response = new();
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model) {
			var errorMessage = await _authService.Register(model);
			if (!string.IsNullOrEmpty(errorMessage)) {
				_response.IsSuccess = false;
				_response.Message = errorMessage;
				return BadRequest(_response);
			}
			return Ok(_response);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
		{
			var loginResonse = await _authService.Login(model);
			if (loginResonse.User == null) {
				_response.IsSuccess = false;
				_response.Message = "Username or password is incorrect";
				return BadRequest(_response);
			}
			_response.Result = loginResonse;
			return Ok(_response);
		}

		[HttpPost("AssignRole")]
		public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
		{
			var assignRoleSuccessfull = await _authService.assignRole(model.Email,model.Role.ToUpper());
			if (!assignRoleSuccessfull)
			{
				_response.IsSuccess = false;
				_response.Message = "Error encountered";
				return BadRequest(_response);
			}

			return Ok(_response);
		}
	}
}
