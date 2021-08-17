using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Data;
using CrowdyCloudBar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CrowdyCloudBarDbContext _crowdyCloudBarDbContext;

        public CategoryRepository(CrowdyCloudBarDbContext crowdyCloudBarDbContext)
        {
            _crowdyCloudBarDbContext = crowdyCloudBarDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _crowdyCloudBarDbContext.Categories.OrderBy(category => category.CategoryName).ToListAsync();
        }
    }
}
