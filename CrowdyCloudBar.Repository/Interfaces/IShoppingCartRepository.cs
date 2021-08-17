using CrowdyCloudBar.DomainData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Interfaces
{
    public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCartItem> GetAllShoppingCartItems(string cartId);
        Task<ShoppingCartItem> GetShoppingCartItemAsync(int drinkId, string cartId);
        Task InsertShoppingCartItemAsync(ShoppingCartItem shoppingCartItem);
        void DeleteShoppingCartItem(ShoppingCartItem shoppingCartItem);
        void DeleteAllShoppingCartItems(string cartId);
        decimal GetShoppingCartItemTotals(string cartId);

    }
}
