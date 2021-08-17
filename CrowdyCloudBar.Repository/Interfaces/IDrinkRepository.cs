using CrowdyCloudBar.DomainData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Interfaces
{
    public interface IDrinkRepository
    {
        Task<IEnumerable<Drink>> GetAllDrinksAsync();
        Task<IEnumerable<Drink>> GetPreferredDrinksAsync();
        Task<Drink> GetDrinkByIdAsync(int id);
        Task<IEnumerable<Drink>> GetDrinksByCategoryAsync(string category);
        Task<IEnumerable<Drink>> GetDrinksBySearchCriteriaAsync(string searchString);

    }
}
