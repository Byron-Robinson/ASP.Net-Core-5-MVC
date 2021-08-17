using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Data;
using CrowdyCloudBar.Repository.Interfaces;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Implementations
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly CrowdyCloudBarDbContext _crowdyCloudBarDbContext;

        public OrderDetailRepository(CrowdyCloudBarDbContext crowdyCloudBarDbContext)
        {
            _crowdyCloudBarDbContext = crowdyCloudBarDbContext;
        }

        public async Task InsertOrderDetailsAsync(OrderDetail orderDetail)
        {
            await _crowdyCloudBarDbContext.OrderDetails.AddAsync(orderDetail);
        }
    }
}
