using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Interfaces;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Implementations
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateDrinkOrderDetailAsync(OrderDetail orderDetail)
        {
            await _unitOfWork.OrderDetailRepository.InsertOrderDetailsAsync(orderDetail);
            await _unitOfWork.SavChangesAsync();
        }
    }
}
