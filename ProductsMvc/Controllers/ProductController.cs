using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsMvc.Data;
using ProductsMvc.Helpers;
using ProductsMvc.Models;
using ProductsMvc.Models.ViewModels;
using ProductsMvc.Repositories;
using ProductsMvc.Repositories.Abstractions;

namespace ProductsMvc.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductsRepository _productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["products"] = await _productsRepository.GetProductsAsync();
            return View();
        }

        public async Task<IActionResult> AddProduct()
        {
            ViewData["tags"] = await _productsRepository.GetAllTagsAsync();
            ViewData["categories"] = await _productsRepository.GetAllCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
        {
            ViewData["tags"] = await _productsRepository.GetAllTagsAsync();
            ViewData["categories"] = await _productsRepository.GetAllCategoriesAsync();
            if (ModelState.IsValid)
            {
                await _productsRepository.AddProductAsync(productViewModel);
                return RedirectToAction("AddProduct");
            }
            return View(productViewModel);
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _productsRepository.GetProductAsync(id);
            ViewData["product"] = product;
            ViewData["tags"] = await _productsRepository.GetAllTagsAsync();
            ViewData["categories"] = await _productsRepository.GetAllCategoriesAsync();
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(int id, ProductViewModel productViewModel)
        {
            _productsRepository.UpdateProductAsync(id, productViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productsRepository.RemoveProductAsync(id);
            return RedirectToAction("Index");
        }
    }
}
