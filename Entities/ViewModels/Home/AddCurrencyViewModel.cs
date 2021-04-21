using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Home
{
    public class AddCurrencyViewModel : IViewModel
    {
        public CurrencyDto CurrencyDto { get; set; }
    }
}
