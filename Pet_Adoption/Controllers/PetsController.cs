using Microsoft.AspNetCore.Mvc;
using Pet_Adoption.DAL;
using Pet_Adoption.Models;

namespace Pet_Adoption.Controllers
{
	public class PetsController : Controller
	{
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Name,Type,Age,SetImage")] Pet pet)
		{
			if (ModelState.IsValid)
			{
				if (pet.SetImage != null)
				{
					pet.AddImage(pet.SetImage);
				}
				Data.Get.Add(pet);
				await Data.Get.SaveChangesAsync();
				return RedirectToAction("Index", "Home");
			}
			return View(pet);
		}
	}
}