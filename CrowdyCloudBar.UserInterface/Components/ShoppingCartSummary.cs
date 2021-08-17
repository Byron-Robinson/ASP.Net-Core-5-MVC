using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.UserInterface.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrowdyCloudBar.UserInterface.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCartService shoppingCartService, ShoppingCart shoppingCart)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
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
    }
}
