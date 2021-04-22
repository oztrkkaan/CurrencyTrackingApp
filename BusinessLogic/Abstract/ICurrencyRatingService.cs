using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICurrencyRatingService
    {
        IDataResult<IList<CurrencyRating>> GetListByCurrenyIdAndDate(int currencyId, DateTime startDate, DateTime? endDate);

        Task<IDataResult<IList<CurrencyRating>>> SaveListFromEvds(int currencyId, DateTime startDate, DateTime? endDate);

        IDataResult<IList<CurrencyRating>> AddList(IList<CurrencyRating> currencyRatings);
    }
}
