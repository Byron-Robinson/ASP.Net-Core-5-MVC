using CrowdyCloudBar.DomainData.Entities;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task InsertOrderAsync(Order order);
    }
}
