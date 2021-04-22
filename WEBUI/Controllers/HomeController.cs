using BusinessLogic.Abstract;
using Entities.Dtos;
using Entities.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Utilities;
using WEBUI.Utilities.Toastr;
using Core.Constants.Enum;
using BusinessLogic.Utilities.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBUI.Controllers
{
    public class HomeController : Controller
    {

        ICurrencyService _currencyService;
        ICurrencyRatingService _currencyRatingService;
        public HomeController(ICurrencyService currencyService, ICurrencyRatingService currencyRatingService)
        {
            _currencyService = currencyService;
            _currencyRatingService = currencyRatingService;
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
            CurrencyDetailViewModel model = new CurrencyDetailViewModel();
            model.CurrencyDto = Mapping.Mapper.Map<CurrencyDto>(_currencyService.Get(m => m.Id == currencyId).Data);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CurrencyDetail(CurrencyDetailViewModel model)
        {
            model.CurrencyDto = Mapping.Mapper.Map<CurrencyDto>(_currencyService.Get(m => m.Id == model.CurrencyDto.Id).Data);
            model.CurrencyRatingDtos = Mapping.Mapper.Map<IList<CurrencyRatingDto>>(_currencyRatingService.GetListByCurrenyIdAndDate(model.CurrencyDto.Id, model.StartDate, model.EndDate).Data);
            var currencyRatings= await _currencyRatingService.SaveListFromEvds(model.CurrencyDto.Id, model.StartDate, model.EndDate);
            model.CurrencyRatingDtos = Mapping.Mapper.Map<IList<CurrencyRatingDto>>(currencyRatings.Data);
            return View(model);
        }

    }
}
