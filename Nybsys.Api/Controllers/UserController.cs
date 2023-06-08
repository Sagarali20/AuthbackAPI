using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nybsys.Api.Utils;
using Nybsys.DataAccess.Contracts;
using Nybsys.DataAccess.Repository;
using Nybsys.EntityModels;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.RegularExpressions;
using User = Nybsys.EntityModels.User;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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
			bool result = false;
			if (model == null)
			{
				return BadRequest();
			}

			//var users = await _userRepository.GetAll().FirstOrDefault(x => x.Username==user.Username && x.Password==user.Password);

			var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == model.Username);
			if (user == null) {

				return NotFound(new { result = result, Message ="User not found" });
			}
			if(!PasswordHasher.VerifyPassword(model.Password,user.Password))
			{
				return BadRequest(new {result= result, Message = "Password is incorrect" });
			}

			model.Token = createJwt(user);

			return Ok(new {token=model.Token, result =true, Message = "login success"});

		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] User model)
		{
			
			bool result = false;
			if (model == null)
			{
				return BadRequest();
			}

			if(CheckUsernameExits(model.Username))
			{
				return BadRequest(new { Message = "Username Already exits" });

			}

			if (CheckEmailExits(model.Email))
			{
				return BadRequest(new { Message = "Email Already exits" });

			}

			var pass = CheckPasswordStrength(model.Password);
		    if (!string.IsNullOrWhiteSpace(pass))
			{
				return BadRequest(new { Message = pass });

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

		[Authorize]
		[HttpGet]
	    public async Task<IActionResult> GetAllUser()
		{
			var alluser = _userRepository.GetAll();


			return Ok( new {users= alluser });
		}


		private  Boolean CheckUsernameExits(string username)
		{

			var user = _userRepository.GetAll().FirstOrDefault(x => x.Username == username);
			if (user == null)
				return false;
			else
				return true;
		}
		private Boolean CheckEmailExits(string email)
		{

			var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email);
			if (user == null)
				return false;
			else
				return true;
		}

		private string  CheckPasswordStrength(string password)
		{

			StringBuilder sb = new StringBuilder();


			if (!string.IsNullOrEmpty(password) && password.Length<8)
			{

				sb.Append("Minimum password length should be 8" + Environment.NewLine);

				if (!(Regex.IsMatch(password,"[a-z]")) && (Regex.IsMatch(password,"[A-Z]")) && (Regex.IsMatch(password,"[0-9]")))
				{
					sb.Append("Password should be Alphanumeric" + Environment.NewLine);
				}
				//if ((Regex.IsMatch(password,"[]")))
				//{

				//}

			}

			return sb.ToString();


		}

		private string createJwt(User user)
		{
			var jwtTokenHandler = new JwtSecurityTokenHandler();

			var key = Encoding.ASCII.GetBytes("veryverysecret.....");
			var identity = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Role,user.Role),
				new Claim(ClaimTypes.Name,$"{user.FirstName} {user.LastName}")
			});

			var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = identity,
				Expires = DateTime.Now.AddDays(1),
				SigningCredentials = credentials
			};

			var token = jwtTokenHandler.CreateToken(tokenDescriptor);
			return jwtTokenHandler.WriteToken(token);
		}
	}
}
