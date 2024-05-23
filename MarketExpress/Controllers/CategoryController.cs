using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarketExpress.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository) 
        
        {
        
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<CategoryModel> category = _categoryRepository.CategoriesAll();
            
            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            CategoryModel category = _categoryRepository.ListIdCategory(id);
            return View(category);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            CategoryModel category = _categoryRepository.ListIdCategory(id);
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Add(CategoryModel category) 
        
        { 
            _categoryRepository.Add(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel category)

        {
            _categoryRepository.Update(category);
            return RedirectToAction("Index");
        }
    }
}
