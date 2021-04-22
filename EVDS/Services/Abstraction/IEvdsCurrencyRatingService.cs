using EVDS.Constants.Enums;
using EVDS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVDS.Services.Abstraction
{
    public interface IEvdsCurrencyRatingService
    {
        Task<IList<EvdsCurrencyRating>> GetByCodeAndDate(string currencyCode, string OperationType, DateTime startDate, DateTime? endDate, ResponseTypes responseType = ResponseTypes.Json);


    }
}
