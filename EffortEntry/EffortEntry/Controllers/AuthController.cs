using EffortEntry.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EffortEntry.Controllers
{
	[AllowAnonymous]
	public class AuthController : Controller
	{
		private readonly ILogger<AuthController> _logger;
		private readonly IUserService _userService;
		public AuthController(ILogger<AuthController> logger, IUserService userService)
		{
			if ((new object[] { userService, logger }).Any(t => t == null))
				throw new ArgumentNullException("Missing references in AuthController");

			_userService = userService;
			_logger = logger;
		}
		[HttpPost]
		public IActionResult Login()
		{
			try
			{
				return Ok(_userService.login());
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "EffortEntry.Controllers.HomeController.GetData");
				return BadRequest();
			}
		}
	}
}
