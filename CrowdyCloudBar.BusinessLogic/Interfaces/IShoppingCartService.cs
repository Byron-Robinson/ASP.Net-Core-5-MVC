using CrowdyCloudBar.DomainData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Interfaces
{
    public interface IShoppingCartService
    {
        ShoppingCart RetrieveShoppingCart();
        IEnumerable<ShoppingCartItem> RetrieveAllShoppingCartItemsFromShoppingCart(string ShoppingCartId);
        Task AddDrinkToShoppingCart(Drink drink);
        Task<int> RemoveDrinkFromShoppingCart(Drink drink);
        Task EmptyShoppingCart();
        decimal RetrieveShoppingCartTotal();
    }
}
