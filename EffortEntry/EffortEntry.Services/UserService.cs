using AutoMapper;
using EffortEntry.Repository.Interfaces;
using EffortEntry.Repository.Interfaces.Base;
using EffortEntry.Services.Interfaces;
using EffortEntry.Domain.Models;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.WebUtilities;
using System.IdentityModel.Tokens.Jwt;
using EffortEntry.Domain.ViewModel;

namespace EffortEntry.Services
{
	public class UserService : IUserService
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private IUserRepository _userRepository;
		private IConfiguration _configuration;
		public UserService(
			IUserRepository userRepository,
			IMapper mapper,
			IUnitOfWork unitOfWork,
			IConfiguration configuration
			)
		{
			if ((new object[] { userRepository, mapper,
				unitOfWork,configuration}).Any(t => t == null))
				throw new ArgumentNullException("Missing references in User Service");

			_userRepository = userRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}
		public IEnumerable<User> GetUsers()
		{
			return _mapper.Map<IEnumerable<User>>(_userRepository.All());
		}

		public string login()
		{
			return GenerateToken();
		}
		private string GenerateToken()
		{
			var identity = new ClaimsIdentity("JWT");
			identity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.Name, "Test"));
			identity.AddClaim(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, "1"));
			return GenerateJWTToken(identity, 0);
		}

		private string GenerateJWTToken(ClaimsIdentity identity, int sessionDuration)
		{
			var appSettings = _configuration.GetSection("AppSettings");
			string issuerSigningKey = appSettings["IssuerSigningKey"];
			string audience = appSettings["ValidAudience"];
			string issuer = appSettings["ValidIssuer"];
			sessionDuration = Convert.ToInt32(_configuration.GetSection("AppSettings")["SessionTimeout"]);


			var secretKey = new SymmetricSecurityKey(WebEncoders.Base64UrlDecode(issuerSigningKey));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = identity,
				Expires = DateTime.UtcNow.AddMinutes(sessionDuration),
				SigningCredentials = signinCredentials,
				Audience = audience,
				Issuer = issuer
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public ResponseModel CreateUser(User user)
		{
			try
			{
				var newUser = _userRepository.Create(_mapper.Map<Repository.Models.User>(user));
				_userRepository.Save();
				return new ResponseModel
				{
					ResponseStatus = "success",
					User = _mapper.Map<User>(newUser)
				};
			}
			catch (Exception)
			{
				return new ResponseModel
				{
					ResponseStatus = "Faild",
					User = user
				};
			}
		}
		public ResponseModel UpdateUser(User user)
		{
			try
			{
				_userRepository.Update(_mapper.Map<Repository.Models.User>(user));
				_userRepository.Save();
				return new ResponseModel
				{
					ResponseStatus = "success",
					User = user
				};
			}
			catch (Exception)
			{
				return new ResponseModel
				{
					ResponseStatus = "Faild",
					User = user
				};
			}
		}
	}
}
