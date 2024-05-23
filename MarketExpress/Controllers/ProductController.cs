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
            return View(product;
        }

        public IActionResult Delete(int id)
        {
            _productRepository.Delete(id);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Add(ProductModel product)

        {
            
            _productRepository.Add(product);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Edit(ProductModel product)

        {

            _productRepository.Update(product);
            return RedirectToAction("Index");
        }
    }
}
