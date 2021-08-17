using CrowdyCloudBar.DomainData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
