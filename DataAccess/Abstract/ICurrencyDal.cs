﻿using Core.DataAccess;
using Entities.Concrate;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICurrencyDal : IEntityRepository<Currency>
    {

    }
}
