using EVDS.Constants.Enums;
using EVDS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVDS.Services.Abstraction
{
    public interface ICurrencyRatingService
    {
        Task<IList<CurrencyRating>> GetListBySerieCodesAndDate(string[] serieCodes, DateTime startDate, DateTime endDate, ResponseTypes responseType);

    }
}
