using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateDrinkOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            await _unitOfWork.OrderRepository.InsertOrderAsync(order);
            await _unitOfWork.SavChangesAsync();
        }
    }
}
