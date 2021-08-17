using CrowdyCloudBar.DomainData.Entities;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        Task CreateDrinkOrderAsync(Order order);
    }
}
