using EVDS.Constants.Enums;
using EVDS.Entities;
using EVDS.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVDS.Services.Abstraction
{
    public interface IEvdsCurrencyService
    {
        Task<IList<EvdsCurrency>> GetList(ResponseTypes responseType = ResponseTypes.Json);
    }
}
