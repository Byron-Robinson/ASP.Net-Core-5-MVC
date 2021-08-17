using CrowdyCloudBar.DomainData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> RetreiveAllCategoriesAsync();
    }
}
