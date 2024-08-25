using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EffortEntry.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using EffortEntry.Domain.Models;

namespace EffortEntry.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly IUserService _userService;
	public HomeController(ILogger<HomeController> logger, IUserService userService)
	{
		if ((new object[] { userService, logger }).Any(t => t == null))
			throw new ArgumentNullException("Missing references in HomeController");

		_userService = userService;
		_logger = logger;
	}

	[HttpGet]
	public IActionResult GetData()
	{
		try
		{
			return Ok(new { Message = "Your received message goes here" });
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "EffortEntry.Controllers.HomeController.GetData");
			return BadRequest();
		}
	}
	[HttpGet]
	public IActionResult GetAllUser()
	{
		try
		{
			return Ok(_userService.GetUsers());
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "EffortEntry.Controllers.HomeController.GetData");
			return BadRequest();
		}
	}
	[HttpPost]
	public IActionResult CreateUser([FromBody]User user)
	{
		try
		{
			return Ok(_userService.CreateUser(user));
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "EffortEntry.Controllers.HomeController.CreateUser");
			return BadRequest();
		}
	}
	[HttpPost]
	public IActionResult UpdateUser([FromBody] User user)
	{
		try
		{
			return Ok(_userService.UpdateUser(user));
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "EffortEntry.Controllers.HomeController.UpdateUser");
			return BadRequest();
		}
	}
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
