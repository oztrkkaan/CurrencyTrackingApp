using Core.DataAccess;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICurrencyDal : IEntityRepository<Currency>
    {
    }
}
