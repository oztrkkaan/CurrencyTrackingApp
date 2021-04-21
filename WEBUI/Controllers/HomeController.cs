using BusinessLogic.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WEBUI.Controllers
{
    public class HomeController : Controller
    {
     
        ICurrencyService _currencyService;
        public HomeController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {


            return View();
        }

        public IActionResult AddCurrency()
        {
            return View();
        }

    }
}
