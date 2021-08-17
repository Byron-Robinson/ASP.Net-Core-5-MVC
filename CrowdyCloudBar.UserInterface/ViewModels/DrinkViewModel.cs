using CrowdyCloudBar.DomainData.Entities;
using System.Collections.Generic;

namespace CrowdyCloudBar.UserInterface.ViewModels
{
    public class DrinkViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<Drink> PreferredDrinks { get; set; }

    }
}
