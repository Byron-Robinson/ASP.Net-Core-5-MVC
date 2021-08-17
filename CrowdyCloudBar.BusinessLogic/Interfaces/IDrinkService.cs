using CrowdyCloudBar.DomainData.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Interfaces
{
    public interface IDrinkService
    {
        Task<IEnumerable<Drink>> RetreiveAllDrinksAsync();
        Task<IEnumerable<Drink>> RetrievePreferredDrinksAsync();
        Task<Drink> RetrieveDrinkByIdAsync(int id);
        Task<IEnumerable<Drink>> RetrieveDrinksByCategoryAsync(string category);
        Task<IEnumerable<Drink>> RetrieveDrinksBySearchCriteriaAsync(string searchString);
    }
}
