using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;

namespace DataAccess.Concrete.Contexts.EntityFramework
{
    public class EfCurrencyDal : EfEntityRepositoryBase<Currency, CurrencyTrackingContext>, ICurrencyDal
    {
    }
}
