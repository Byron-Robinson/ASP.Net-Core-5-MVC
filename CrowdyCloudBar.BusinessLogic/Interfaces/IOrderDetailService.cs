using CrowdyCloudBar.DomainData.Entities;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Interfaces
{
    public interface IOrderDetailService
    {
        Task CreateDrinkOrderDetailAsync(OrderDetail orderDetail);
    }
}
