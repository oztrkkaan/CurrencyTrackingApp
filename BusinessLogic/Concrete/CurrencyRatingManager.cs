using BusinessLogic.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using EVDS.Services.Abstraction;
using System;
using System.Collections.Generic;
using EVDS.Constants.Enums;
using System.Threading.Tasks;
using System.Linq;
using BusinessLogic.Utilities.AutoMapper;
using EVDS.Entities;

namespace BusinessLogic.Concrete
{
    public class CurrencyRatingManager : ICurrencyRatingService
    {
        ICurrencyRatingDal _currencyRatingDal;
        ICurrencyService _currencyService;
        IEvdsService _evdsService;

        public CurrencyRatingManager(ICurrencyRatingDal currencyRatingDal, IEvdsService evdsService, ICurrencyService currencyService)
        {
            _currencyRatingDal = currencyRatingDal;
            _evdsService = evdsService;
            _currencyService = currencyService;
        }

        public IDataResult<IList<CurrencyRating>> AddList(IList<CurrencyRating> currencyRatings)
        {
            return new SuccessDataResult<IList<CurrencyRating>>(_currencyRatingDal.AddRange(currencyRatings));
        }

        public IDataResult<IList<CurrencyRating>> GetListByCurrenyIdAndDate(int currencyId, DateTime startDate, DateTime? endDate)
        {
            return new SuccessDataResult<IList<CurrencyRating>>(_currencyRatingDal.GetList(m =>
            m.CurrencyId == currencyId &&
            (endDate.HasValue ? m.Date >= startDate && m.Date <= endDate : m.Date == endDate)));
        }

        public async Task<IDataResult<IList<CurrencyRating>>> SaveListFromEvds(int currencyId, DateTime startDate, DateTime? endDate)
        {
            var currency = _currencyService.Get(m => m.Id == currencyId).Data;
            var existCurrencyRatingList = GetListByCurrenyIdAndDate(currencyId, startDate, endDate).Data;
            
            EvdsCurrencyRatingRequest request = new EvdsCurrencyRatingRequest()
            {
                CurrencyCode = currency.Code,
                StartDate = startDate,
                EndDate = endDate,
                OperationType = currency.OperationType,
                ResponseType = ResponseTypes.Json.ToString()
            };

            var evdsCurrencyRatings = await _evdsService.CurrencyRatingService.GetListByCodeAndDate(request);
            var existCurrencyRatingDates = existCurrencyRatingList.Select(m => m.Date);
            var doesNotExistRates = evdsCurrencyRatings.Where(m => m.CurrencyCode == currency.Code && !existCurrencyRatingDates.Contains(m.Date));
            var addListResult = AddList(doesNotExistRates.Select(m => new CurrencyRating { CurrencyId = currencyId, Date = m.Date, Rating = m.Rating }).ToList());

            return new SuccessDataResult<IList<CurrencyRating>>(existCurrencyRatingList.Concat(addListResult.Data).ToList());
        }



    }
}
