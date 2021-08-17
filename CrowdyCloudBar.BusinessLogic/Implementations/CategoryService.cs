using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> RetreiveAllCategoriesAsync()
        {
            return await _unitOfWork.CategoryRepository.GetAllCategoriesAsync();
        }
    }
}
