using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
  public  interface ICurrencyService
    {
        Task<IDataResult<IList<Currency>>> SyncCurrencyList();
       

    }
}
