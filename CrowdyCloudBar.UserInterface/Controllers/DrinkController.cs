using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.UserInterface.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdyCloudBar.UserInterface.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkService _drinkService;
        private readonly IConfiguration _configuration;

        public DrinkController(IDrinkService drinkService, IConfiguration configuration)
        {
            _drinkService = drinkService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string category)
        {
            IEnumerable<Drink> drinks;

            if (!string.IsNullOrEmpty(category))
            {
                drinks = await _drinkService.RetrieveDrinksByCategoryAsync(category);
            }
            else
            {
                drinks = await _drinkService.RetreiveAllDrinksAsync();
                category = _configuration["DrinkCategory:All-Drinks"];
            }

            DrinkViewModel model = new()
            {
                Drinks = drinks,
                CurrentCategory = category.ToUpper()
            };
            return View(model);
        }

        public async Task<IActionResult> DrinkDetails(int drinkId)
        {
            Drink drink = await _drinkService.RetrieveDrinkByIdAsync(drinkId);

            if (drink == null)
            {
                return View("Error");
            }

            return View(drink);
        }

        public async Task<IActionResult> SearchDrink(string searchString)
        {

            IEnumerable<Drink> drinks;

            if (!string.IsNullOrEmpty(searchString))
            {
                drinks = await _drinkService.RetrieveDrinksBySearchCriteriaAsync(searchString);
                if (drinks.ToList().Count == 0)
                {
                    drinks = await _drinkService.RetreiveAllDrinksAsync();
                }
            }
            else
            {
                drinks = await _drinkService.RetreiveAllDrinksAsync();
            }

            DrinkViewModel model = new()
            {
                Drinks = drinks,
                CurrentCategory = _configuration["DrinkCategory:All-Drinks"].ToUpper()
            };
            return View("Index", model);
        }
    }
}
