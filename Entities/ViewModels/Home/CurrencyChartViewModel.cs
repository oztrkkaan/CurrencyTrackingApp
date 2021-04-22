using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Home
{
    public class CurrencyChartViewModel : IViewModel
    {
        public CurrencyDto CurrencyDto { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
