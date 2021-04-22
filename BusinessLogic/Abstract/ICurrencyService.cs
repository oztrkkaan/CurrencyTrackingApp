using Core.Utilities.Results;
using Entities.Concrate;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICurrencyService
    {
        IDataResult<Currency> Create(CurrencyDto currencyDto);
        IDataResult<Currency> Get(Expression<Func<Currency, bool>> filter);
    }
}
