using EVDS.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVDS.Services.Concrete
{
    public class EvdsService : IEvdsService
    {
        //private readonly IEvdsCurrencyService _evdsCurrencyService;
        //private readonly IEvdsCurrencyRatingService _evdsCurrencyRatingService;

        //public EvdsService(IEvdsCurrencyService evdsCurrencyService, IEvdsCurrencyRatingService evdsCurrencyRatingService)
        //{
        //    _evdsCurrencyService = evdsCurrencyService;
        //    _evdsCurrencyRatingService = evdsCurrencyRatingService;
        //}

        IEvdsCurrencyService IEvdsService.CurrencyService => new EvdsCurrencyManager();
        IEvdsCurrencyRatingService IEvdsService.CurrencyRatingService => new EvdsCurrencyRatingManager();
    
    }
}
