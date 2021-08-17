using CrowdyCloudBar.BusinessLogic.Interfaces;
using CrowdyCloudBar.DomainData.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrowdyCloudBar.UserInterface.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryMenu(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Category> categories = _categoryService.RetreiveAllCategoriesAsync().Result;
            return View(categories);
        }
    }
}
