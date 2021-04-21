using BusinessLogic.Abstract;
using BusinessLogic.Utilities.AutoMapper;
using BusinessLogic.ValidationRules;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dtos;
using EVDS.Entities;
using EVDS.Services.Abstraction;
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

        public async Task<IDataResult<IList<Currency>>> SyncCurrencyList()
        {
            IList<EvdsCurrency> actualCurrencies = await _evdsService.CurrencyService.GetList();

            var existCurrencies = GetList();

            var existSerieCodes = existCurrencies.Data.Select(m => m.Code);
            var currenciesToAdd = actualCurrencies.Where(m => !existSerieCodes.Contains(m.SERIE_CODE));
            var mappedCurrencies = currenciesToAdd.Select(m => new Currency { Name = m.SERIE_NAME, Code = m.SERIE_CODE }).ToList();
            var addResult = await AddListAsync(mappedCurrencies);
            if (!addResult.Success)
            {
                return new ErrorDataResult<IList<Currency>>("Ekleme işlemi başarısız oldu.");
            }
            return new SuccessDataResult<IList<Currency>>(addResult.Data, $"{addResult.Data.Count} yeni para birimi eklendi.");
        }
        public async Task<IDataResult<IList<Currency>>> AddListAsync(IList<Currency> currencies)
        {
            var addResult = await _currencyDal.AddRangeAsync(currencies);
            return new SuccessDataResult<IList<Currency>>(addResult);
        }
        public IDataResult<IList<Currency>> GetList(Expression<Func<Currency, bool>> filter = null)
        {
            return new SuccessDataResult<IList<Currency>>(_currencyDal.GetList(filter));
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
            var addedCurrency = _currencyDal.Add(Mapping.Mapper.Map<Currency>(currencyDto));
            return new SuccessDataResult<Currency>(addedCurrency, "Para birimi başarıyla eklendi.");

        }
    }
}
