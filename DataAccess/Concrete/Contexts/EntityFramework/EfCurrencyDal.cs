using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Contexts.EntityFramework
{
    public class EfCurrencyDal : EfEntityRepositoryBase<Currency, CurrencyTrackingContext>, ICurrencyDal
    {
    }
}
