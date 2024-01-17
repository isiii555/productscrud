using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using ProductsMvc.Data;
using ProductsMvc.Models;
using ProductsMvc.Models.ViewModels;
using ProductsMvc.Repositories.Abstractions;

namespace ProductsMvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryController(ICategoriesRepository categories)
        {
            _categoriesRepository = Guard.Against.Null(categories);
        }
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                await _categoriesRepository.AddCategoryAsync(categoryViewModel);
                return RedirectToAction("AddCategory");
            }
            return View(categoryViewModel);
        }
    }
}
