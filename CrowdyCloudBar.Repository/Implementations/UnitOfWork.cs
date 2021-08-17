using CrowdyCloudBar.Repository.Data;
using CrowdyCloudBar.Repository.Interfaces;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrowdyCloudBarDbContext _crowdyCloudBarDbContext;

        public IDrinkRepository DrinkRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IShoppingCartRepository ShoppingCartRepository { get; set; }
        public IOrderDetailRepository OrderDetailRepository { get; set; }

        public UnitOfWork(CrowdyCloudBarDbContext crowdyCloudBarDbContext, IDrinkRepository drinkRepository, ICategoryRepository categoryRepository,
                          IShoppingCartRepository shoppingCartRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository
)
        {
            _crowdyCloudBarDbContext = crowdyCloudBarDbContext;

            DrinkRepository = drinkRepository;
            CategoryRepository = categoryRepository;
            ShoppingCartRepository = shoppingCartRepository;
            OrderRepository = orderRepository;
            OrderDetailRepository = orderDetailRepository;
        }

        public async Task<bool> SavChangesAsync()
        {
            return await _crowdyCloudBarDbContext.SaveChangesAsync() > 0;
        }
    }
}
