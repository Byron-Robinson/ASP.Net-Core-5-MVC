using CrowdyCloudBar.DomainData.Entities;
using CrowdyCloudBar.Repository.Data;
using CrowdyCloudBar.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdyCloudBar.Repository.Implementations
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly CrowdyCloudBarDbContext _crowdyCloudBarDbContext;

        public DrinkRepository(CrowdyCloudBarDbContext crowdyCloudBarDbContext)
        {
            _crowdyCloudBarDbContext = crowdyCloudBarDbContext;
        }

        public async Task<IEnumerable<Drink>> GetAllDrinksAsync()
        {
            return await _crowdyCloudBarDbContext.Drinks.Include(item => item.Category).OrderBy(drink => drink.Name).ToListAsync();
        }
        public async Task<IEnumerable<Drink>> GetPreferredDrinksAsync()
        {
            return await _crowdyCloudBarDbContext.Drinks.Where(drink => drink.IsPreferredDrink).Include(item => item.Category).OrderBy(drink => drink.Name).ToListAsync();
        }
        public async Task<Drink> GetDrinkByIdAsync(int id)
        {
            return await _crowdyCloudBarDbContext.Drinks.FindAsync(id);
        }

        public async Task<IEnumerable<Drink>> GetDrinksByCategoryAsync(string category)
        {
            return await _crowdyCloudBarDbContext.Drinks.Where(drink => drink.Category.CategoryName.Equals(category)).OrderBy(drink => drink.Name).ToListAsync();
        }

        public async Task<IEnumerable<Drink>> GetDrinksBySearchCriteriaAsync(string searchString)
        {
            return await _crowdyCloudBarDbContext.Drinks.Where(drink => drink.Name.ToLower().Contains(searchString.ToLower())).OrderBy(drink => drink.Name).ToListAsync();
        }
    }
}
