using Core.Utilities.Results;
using Entities.Concrate;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICurrencyService
    {
        Task<IDataResult<IList<Currency>>> SyncCurrencyList();

        IDataResult<Currency> Create(CurrencyDto currencyDto);
      

    }
}
