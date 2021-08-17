using System.Collections.Generic;

namespace CrowdyCloudBar.DomainData.Entities
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
