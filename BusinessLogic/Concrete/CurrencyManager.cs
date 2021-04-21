using BusinessLogic.Abstract;
using BusinessLogic.Utilities.AutoMapper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using EVDS.Entities;
using EVDS.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

            var existSerieCodes = existCurrencies.Data.Select(m => m.SerieCode);
            var currenciesToAdd = actualCurrencies.Where(m => !existSerieCodes.Contains(m.SERIE_CODE));
            var mappedCurrencies = currenciesToAdd.Select(m => new Currency { Name = m.SERIE_NAME, SerieCode = m.SERIE_CODE }).ToList();
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

    }
}
