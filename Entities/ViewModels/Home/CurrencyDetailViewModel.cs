using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Home
{
    public class CurrencyDetailViewModel : IViewModel
    {
        public CurrencyDto CurrencyDto { get; set; }
        public IList<CurrencyRatingDto> CurrencyRatingDtos { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
