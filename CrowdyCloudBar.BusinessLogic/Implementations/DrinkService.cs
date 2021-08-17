using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrowdyCloudBar.BusinessLogic.Implementations
{
    public class DrinkService : IDrinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DrinkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Drink>> RetreiveAllDrinksAsync()
        {
            return await _unitOfWork.DrinkRepository.GetAllDrinksAsync();
        }

        public async Task<Drink> RetrieveDrinkByIdAsync(int id)
        {
            return await _unitOfWork.DrinkRepository.GetDrinkByIdAsync(id);
        }

        public async Task<IEnumerable<Drink>> RetrievePreferredDrinksAsync()
        {
            return await _unitOfWork.DrinkRepository.GetPreferredDrinksAsync();
        }

        public async Task<IEnumerable<Drink>> RetrieveDrinksByCategoryAsync(string category)
        {
            return await _unitOfWork.DrinkRepository.GetDrinksByCategoryAsync(category);
        }
        public async Task<IEnumerable<Drink>> RetrieveDrinksBySearchCriteriaAsync(string searchString)
        {
            return await _unitOfWork.DrinkRepository.GetDrinksBySearchCriteriaAsync(searchString);
        }
    }
}
