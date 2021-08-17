using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdyCloudBar.UserInterface.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IConfiguration _configuration;

        public OrderController(ShoppingCart shoppingCart, IOrderService orderService, IOrderDetailService orderDetailService, 
                               IShoppingCartService shoppingCartService, IConfiguration configuration)
        {
            _shoppingCart = shoppingCart;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _shoppingCartService = shoppingCartService;
            _configuration = configuration;
        }

        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CheckOut(Order order)
        {
            if (ModelState.IsValid)
            {

                IEnumerable<ShoppingCartItem> shoppingCartItems = _shoppingCartService.RetrieveAllShoppingCartItemsFromShoppingCart(_shoppingCart.ShoppingCartId);
                _shoppingCart.ShoppingCartItems = shoppingCartItems.ToList();

                if (_shoppingCart.ShoppingCartItems.Count == 0)
                {
                    ModelState.AddModelError("EmptyCart", _configuration["ModelStateErrors:EmptyCartMessage"]);
                }
                else
                {
                    await _orderService.CreateDrinkOrderAsync(order);

                    foreach (ShoppingCartItem cartItem in shoppingCartItems)
                    {
                        OrderDetail orderDetail = new()
                        {
                            Amount = cartItem.Amount,
                            DrinkId = cartItem.Drink.DrinkId,
                            OrderId = order.OrderId,
                            Price = cartItem.Drink.Price
                        };

                        await _orderDetailService.CreateDrinkOrderDetailAsync(orderDetail);
                    }

                    await _shoppingCartService.EmptyShoppingCart();

                    return RedirectToAction("CheckoutComplete");
                }
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.Nico = _configuration["CheckOutComplete:ViewBag"].ToUpper();
            ViewData["Interview"] = _configuration["CheckOutComplete:ViewData"].ToUpper();
            TempData["Question"] = _configuration["CheckOutComplete:TempData"].ToUpper();

            return View();
        }
    }
}
