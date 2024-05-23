using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                bool delete = _salesRepository.Delete(id);

                if (delete)
                {
                    TempData["MessageSucess"] = "Sale deleted successfully.";
                }
                else
                {
                    TempData["MessageError"] = "Oops, please try again.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MessageError"] = $"Oops, an error occurred while deleting the sale. Error Detail: {error.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Add(SalesModel sale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _salesRepository.Add(sale);
                    TempData["MessageSucess"] = "Sale registered successfully.";
                    return RedirectToAction("Index");
                }
                return View(sale);
            }
            catch (Exception error)
            {
                TempData["MessageError"] = $"Oops, an error occurred while registering the sale. Error Detail: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(SalesModel sale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _salesRepository.Update(sale);
                    TempData["MessageSucess"] = "Sale updated successfully";
                    return RedirectToAction("Index");
                }

                return View("Edit", sale);
            }
            catch (Exception error)
            {
                TempData["MessageError"] = $"Error updating sale: {error.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
