using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrate;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCurrencyDal : EfEntityRepositoryBase<Currency, CurrencyTrackingContext>, ICurrencyDal
    {
     
    }
}
