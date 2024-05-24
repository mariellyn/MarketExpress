using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarketExpress.Controllers
{


    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)

        {

            _productRepository = productRepository;
        }
        public IActionResult Index()
        {

            List<ProductModel> product = _productRepository.ProductAll();

            return View(product);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ProductModel product = _productRepository.ListIdProduct(id);
            return View(product);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            ProductModel product = _productRepository.ListIdProduct(id);
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            try

            {
                bool delete = _productRepository.Delete(id);

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
        public IActionResult Add(ProductModel product)

        {
            try

            {
                if (ModelState.IsValid)
                {
                    _productRepository.Add(product);
                    TempData["MessageSucess"] = "Successfully registered .";
                    return RedirectToAction("Index");
                }
                return View(product);
            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Edit(ProductModel product)

        {
            try

            {
                if (ModelState.IsValid)
                {
                    _productRepository.Update(product);
                    TempData["MessageSucess"] = "Changed Successfully";
                    return RedirectToAction("Index");
                }

                return View("Edit", product);

            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");

            }
        }
    }
}
