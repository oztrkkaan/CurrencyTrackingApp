using BusinessLogic.Abstract;
using Entities.Dtos;
using Entities.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Utilities;
using WEBUI.Utilities.Toastr;
using Core.Constants.Enum;

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

        [HttpPost]
        public IActionResult AddCurrency(AddCurrencyViewModel model)
        {
            var addResult = _currencyService.Create(model.CurrencyDto);
            if (!addResult.Success)
            {
                ModelState.ValidateModel(addResult.ValidationErrors, nameof(CurrencyDto));
                return View(model);
            }
            this.AddToastrMessage("Başarılı!", addResult.Message, ToastrEnum.Type.Success);

            return RedirectToAction(nameof(CurrencyDetail), new { currencyId = addResult.Data.Id });
        }
        public IActionResult CurrencyDetail(int currencyId)
        {
            return View();
        }
    }
}
