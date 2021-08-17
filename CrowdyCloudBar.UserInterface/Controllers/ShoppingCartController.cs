using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.UserInterface.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdyCloudBar.UserInterface.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ShoppingCart _shoppingCart;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IDrinkService _drinkService;

        public ShoppingCartController(ShoppingCart shoppingCart, IShoppingCartService shoppingCartService, IDrinkService drinkService)
        {
            _shoppingCart = shoppingCart;
            _shoppingCartService = shoppingCartService;
            _drinkService = drinkService;
        }
        public IActionResult Index()
        {
            IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCartService.RetrieveAllShoppingCartItemsFromShoppingCart(_shoppingCart.ShoppingCartId);
            _shoppingCart.ShoppingCartItems = shoppingCartItems.ToList();

            ShoppingCartViewModel model = new()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCartService.RetrieveShoppingCartTotal()
            };

            return View(model);
        }

        public async Task<IActionResult> AddDrinkToShoppingCart(int drinkId)
        {
            _shoppingCart = _shoppingCartService.RetrieveShoppingCart();
            Drink selectedDrink = await _drinkService.RetrieveDrinkByIdAsync(drinkId);

            if (selectedDrink != null)
            {
                await _shoppingCartService.AddDrinkToShoppingCart(selectedDrink);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveDrinkFromShoppingCart(int drinkId)
        {
            Drink selectedDrink = await _drinkService.RetrieveDrinkByIdAsync(drinkId);

            if (selectedDrink != null)
            {
                await _shoppingCartService.RemoveDrinkFromShoppingCart(selectedDrink);
            }

            return RedirectToAction("Index");
        }
    }
}
