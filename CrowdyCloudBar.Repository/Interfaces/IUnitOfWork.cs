using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IDrinkRepository DrinkRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IShoppingCartRepository ShoppingCartRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }

        Task<bool> SavChangesAsync();
    }
}
