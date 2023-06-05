using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nybsys.Api.Utils;
using Nybsys.DataAccess.Contracts;
using Nybsys.DataAccess.Repository;
using Nybsys.EntityModels;
using User = Nybsys.EntityModels.User;

namespace Nybsys.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{

		private readonly IUserRepository _userRepository;
		public UserController(IUserRepository userRepository) {
		
		   _userRepository = userRepository;
		}

		[HttpPost("authenticate")]
		public async Task<IActionResult> Authenticate([FromBody] User model)
		{
			if (model == null)
			{
				return BadRequest();
			}

			//var users = await _userRepository.GetAll().FirstOrDefault(x => x.Username==user.Username && x.Password==user.Password);

			var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);
			if (user == null) {

				return NotFound(new {Message="User not found" });
			}
			return Ok(new {Message="login success"});

		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] User model)
		{
			
			bool result = false;
			if (model == null)
			{
				return BadRequest();
			}
			
			string Message = "";
			try
			{
				model.Password= PasswordHasher.HashPassword(model.Password);
				model.Role = "User";
				model.Token = "";
				result = _userRepository.Create(model);

				return Ok(new { result = result, Message = "Save successfully" });
			}
			catch (Exception ex)
			{
				return Ok(new { result = false, ex.Message });
			}
		}





	}
}
