using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.UserInterface.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrowdyCloudBar.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkService _drinkService;

        public HomeController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        public async Task<IActionResult> Index()
        {
            DrinkViewModel model = new()
            {
                PreferredDrinks = await _drinkService.RetrievePreferredDrinksAsync()
            };

            return View(model);
        }
    }
}
