using CrowdyCloudBar.DomainData.Entities;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task InsertOrderDetailsAsync(OrderDetail orderDetail);
    }
}
