using System;
using System.Collections.Generic;
using System.Text;

namespace EVDS.Services.Abstraction
{
    public interface IEvdsService
    {

        public IEvdsCurrencyService CurrencyService { get; }
        public IEvdsCurrencyRatingService CurrencyRatingService { get; }
    }
}
