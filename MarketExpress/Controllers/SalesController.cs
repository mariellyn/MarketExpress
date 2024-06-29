using MarketExpress.Filters;
using MarketExpress.Models;
using MarketExpress.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MarketExpress.Controllers
{
    [PageUserLogged]
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

        public IActionResult Ordered()
        {
            List<SalesModel> orderedSales = _salesRepository.GetOrderedSales();
            return View("Ordered", orderedSales);
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
        public IActionResult Add(SalesModel sales)

        {
            try

            {
                if (ModelState.IsValid)
                {
                    _salesRepository.Add(sales);
                    TempData["MessageSucess"] = "Successfully registered .";
                    return RedirectToAction("Index");
                }
                return View(sales);
            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Edit(SalesModel sales)

        {
            try

            {
                if (ModelState.IsValid)
                {
                    _salesRepository.Update(sales);
                    TempData["MessageSucess"] = "Changed Successfully";
                    return RedirectToAction("Index");
                }

                return View("Edit", sales);

            }

            catch (System.Exception error)
            {
                TempData["MessageError"] = $"Oops, unregistered customer, please try again, Error Detail : {error.Message}";
                return RedirectToAction("Index");
            }

        }

    }
}
