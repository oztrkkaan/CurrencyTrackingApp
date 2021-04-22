using BusinessLogic.Abstract;
using BusinessLogic.Utilities.AutoMapper;
using BusinessLogic.ValidationRules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Constants;
using Entities.Dtos;
using EVDS.Entities;
using EVDS.Services.Abstraction;
using EVDS.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly IEvdsService _evdsService;
        private readonly ICurrencyDal _currencyDal;

        public CurrencyManager(IEvdsService evdsService, ICurrencyDal currencyDal)
        {
            _evdsService = evdsService;
            _currencyDal = currencyDal;
        }
        public IDataResult<Currency> Get(Expression<Func<Currency, bool>> filter)
        {
            return new SuccessDataResult<Currency>(_currencyDal.Get(filter));
        }

        public IDataResult<Currency> Create(CurrencyDto currencyDto)
        {
            var validator = new CurrencyValidator();
            var validateResult = validator.Validate(currencyDto);
            if (!validateResult.IsValid)
            {
                var errorResults = ValidationHelper.GetErrors(validateResult.Errors);
                return new ErrorDataResult<Currency>("Para birimi ekleme işlemi başarısız oldu.", errorResults);
            }
            currencyDto.Code = currencyDto.Code.ToUpper();

            var addedCurrency = _currencyDal.Add(Mapping.Mapper.Map<Currency>(currencyDto));
            return new SuccessDataResult<Currency>(addedCurrency, "Para birimi başarıyla eklendi.");
        }

        public async Task<IDataResult<IList<CurrencyDto>>> GetListWithActualRatings()
        {
            var day = DateTime.Now;
            if ((day.DayOfWeek == DayOfWeek.Saturday))
            {
                day = day.AddDays(-1);
            }
            else if ((day.DayOfWeek == DayOfWeek.Sunday))
            {
                day = day.AddDays(-2);
            }

            var currencies = _currencyDal.GetList();
            var currencyCodes = currencies.Select(m => m.Code).ToArray();
            var actualCurrencyRatings = await _evdsService.CurrencyRatingService.GetListByCodeAndDate(currencyCodes, CurrencyEnum.OperationTypes.Sell, day);
            var results = currencies.Select(m => new CurrencyDto
            {
                Id = m.Id,
                Name = m.Name,
                Code = m.Code,
                OperationType = m.OperationType,
                ActualRating = actualCurrencyRatings.FirstOrDefault(x => x.CurrencyCode == StringHelper.SerieCodeGenerator(m.Code, CurrencyEnum.OperationTypes.Sell)).Rating
            }).ToList();
            return new SuccessDataResult<IList<CurrencyDto>>(results);

        }
    }
}
