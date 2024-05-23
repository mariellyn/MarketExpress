using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarketExpress.Controllers
{

    public class SalesController : Controller
    {
        private readonly ISalesRepository _salesRepository;
        public SalesController(ISalesRepository salesRepository) 
        
        {
            _salesRepository = salesRepository;
        
        }
        public IActionResult Index()
        {

            List<SalesModel> sales = _salesRepository.SaleAll();
            return View(sales);

        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            SalesModel sales = _salesRepository.ListIdSales(id);
            return View(sales);
        }



        public IActionResult DeleteConfirmation(int id)
        {
            SalesModel sales = _salesRepository.ListIdSales(id);
            return View(sales);
        }



        public IActionResult Delete(int id)
        {
            _salesRepository.Delete(id);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public IActionResult Add(SalesModel sales)

        {
            _salesRepository.Add(sales);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Edit(SalesModel sales)

        {
            _salesRepository.Update(sales);
            return RedirectToAction("Index");

        }
    }
}
