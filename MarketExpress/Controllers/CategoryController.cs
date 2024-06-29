using MarketExpress.Filters;
using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarketExpress.Controllers
{
    [PageUserLogged]
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
            try

            {
                bool delete = _categoryRepository.Delete(id);

                if (delete)
                {
                    TempData["MessageSucess"] = "Successfully delete .";

                }

                else
                {

                    TempData["MessageError"] = "Oops, please try again.";
                }

                return RedirectToAction("Index");
            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, please try again.  Error Detail : {error.Message} ";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Add(CategoryModel category) 
        
        {
            try

            {
                if (ModelState.IsValid)
                {
                    _categoryRepository.Add(category);
                    TempData["MessageSucess"] = "Successfully registered .";
                    return RedirectToAction("Index");
                }
                return View(category);
            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(CategoryModel category)

        {
            try

            {
                if (ModelState.IsValid)
                {
                    _categoryRepository.Update(category);
                    TempData["MessageSucess"] = "Changed Successfully";
                    return RedirectToAction("Index");
                }

                return View("Edit", category);

            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }


        }

    }
}
