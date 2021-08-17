using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Data;
using CrowdyCloudBar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly CrowdyCloudBarDbContext _crowdyCloudBarDbContext;

        public ShoppingCartRepository(CrowdyCloudBarDbContext crowdyCloudBarDbContext)
        {
            _crowdyCloudBarDbContext = crowdyCloudBarDbContext;
        }

        public void DeleteAllShoppingCartItems(string cartId)
        {
            IEnumerable<ShoppingCartItem> cartItems = _crowdyCloudBarDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == cartId);
            _crowdyCloudBarDbContext.ShoppingCartItems.RemoveRange(cartItems);
        }

        public void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            _crowdyCloudBarDbContext.ShoppingCartItems.Remove(shoppingCartItem);
        }

        public IEnumerable<ShoppingCartItem> GetAllShoppingCartItems(string cartId)
        {
            return _crowdyCloudBarDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == cartId).Include(cart => cart.Drink).ToList();
        }

        public Task<ShoppingCartItem> GetShoppingCartItemAsync(int drinkId, string cartId)
        {
            return _crowdyCloudBarDbContext.ShoppingCartItems.FirstOrDefaultAsync(cart => cart.Drink.DrinkId == drinkId && cart.ShoppingCartId == cartId);
        }

        public decimal GetShoppingCartItemTotals(string cartId)
        {
            return _crowdyCloudBarDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == cartId).Select(cart => cart.Drink.Price * cart.Amount).Sum();
        }

        public async Task InsertShoppingCartItemAsync(ShoppingCartItem shoppingCartItem)
        {
            await _crowdyCloudBarDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
        }
    }
}
