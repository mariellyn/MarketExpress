using Microsoft.AspNetCore.Mvc;

namespace MarketExpress.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
