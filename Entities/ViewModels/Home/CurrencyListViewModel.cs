using Entities.Concrate;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Home
{
    public class CurrencyListViewModel : IViewModel
    {
        public IList<CurrencyDto> Currencies{ get; set; }
    }
}
