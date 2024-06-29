using MarketExpress.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MarketExpress.Controllers
{
    [PageUserLogged]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
