using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVDS.Entities;
using EVDS.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBUI.Controllers
{
    public class ApiController : ControllerBase
    {
        IEvdsService _evdsService;

        public ApiController(IEvdsService evdsService)
        {
            _evdsService = evdsService;
        }
        [HttpPost]
        public async Task<IActionResult> GetListByCodeAndDate([FromBody]EvdsCurrencyRatingRequest request)
        {
            var result = await _evdsService.CurrencyRatingService.GetListByCodeAndDate(request);

            return Ok(result);
        }
    }
}
