using EVDS.Constants.Enums;
using EVDS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVDS.Services.Abstraction
{
    public interface IEvdsCurrencyRatingService
    {
        Task<IList<EvdsCurrencyRating>> GetListByCodeAndDate(EvdsCurrencyRatingRequest request);

        Task<IList<EvdsCurrencyRating>> GetListByCodeAndDate(string[] currencyCodes, string operationType, DateTime startDate, DateTime? endDate = null, ResponseTypes responseType = ResponseTypes.Json);

    }
}
