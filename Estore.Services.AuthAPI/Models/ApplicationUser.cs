using Microsoft.AspNetCore.Identity;

namespace Estore.Services.AuthAPI.Models
{
	public class ApplicationUser:IdentityUser
	{
		public string Name { get; set; }
	}
}
