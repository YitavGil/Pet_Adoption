using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Adoption.DAL;
using Pet_Adoption.Models;
using System.Diagnostics;

namespace Pet_Adoption.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<IActionResult> Index()
		{
			var pets = await Data.Get.Pets
				.Include(p => p.Owner)
				.Include(p => p.Images)
				.ToListAsync();
			return View(pets);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}