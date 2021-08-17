using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartService(IUnitOfWork unitOfWork, ShoppingCart shoppingCart)
        {
            _unitOfWork = unitOfWork;
            _shoppingCart = shoppingCart;
        }

        public ShoppingCart RetrieveShoppingCart()
        {
            if (string.IsNullOrEmpty(_shoppingCart.ShoppingCartId))
                _shoppingCart.ShoppingCartId = Guid.NewGuid().ToString();

            return _shoppingCart;
        }
        public IEnumerable<ShoppingCartItem> RetrieveAllShoppingCartItemsFromShoppingCart(string ShoppingCartId)
        {
            return _unitOfWork.ShoppingCartRepository.GetAllShoppingCartItems(ShoppingCartId);

        }
        public async Task AddDrinkToShoppingCart(Drink drink)
        {
            ShoppingCartItem shoppingCartItem = await RetrieveShoppingCartItemFromShoppingCart(drink.DrinkId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = _shoppingCart.ShoppingCartId,
                    Drink = drink,
                    Amount = 1
                };

                await _unitOfWork.ShoppingCartRepository.InsertShoppingCartItemAsync(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            await _unitOfWork.SavChangesAsync();
        }
        public async Task<int> RemoveDrinkFromShoppingCart(Drink drink)
        {
            ShoppingCartItem shoppingCartItem = await RetrieveShoppingCartItemFromShoppingCart(drink.DrinkId);

            int cartAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    cartAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _unitOfWork.ShoppingCartRepository.DeleteShoppingCartItem(shoppingCartItem);
                }
            }

            await _unitOfWork.SavChangesAsync();

            return cartAmount;
        }
        public async Task EmptyShoppingCart()
        {
            _unitOfWork.ShoppingCartRepository.DeleteAllShoppingCartItems(_shoppingCart.ShoppingCartId);
            await _unitOfWork.SavChangesAsync();
        }
        public decimal RetrieveShoppingCartTotal()
        {
            return _unitOfWork.ShoppingCartRepository.GetShoppingCartItemTotals(_shoppingCart.ShoppingCartId);
        }

        private async Task<ShoppingCartItem> RetrieveShoppingCartItemFromShoppingCart(int drinkId)
        {
            return await _unitOfWork.ShoppingCartRepository.GetShoppingCartItemAsync(drinkId, _shoppingCart.ShoppingCartId);

        }
    }
}
