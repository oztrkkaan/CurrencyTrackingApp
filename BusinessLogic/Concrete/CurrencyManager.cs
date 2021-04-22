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

            var addedCurrency = _currencyDal.Add(Mapping.Mapper.Map<Currency>(currencyDto));
            return new SuccessDataResult<Currency>(addedCurrency, "Para birimi başarıyla eklendi.");
        }

 
    }
}
