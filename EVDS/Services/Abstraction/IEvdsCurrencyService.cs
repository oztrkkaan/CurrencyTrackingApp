using EVDS.Constants.Enums;
using EVDS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVDS.Services.Abstraction
{
    public interface IEvdsCurrencyService
    {
        Task<IList<EvdsCurrency>> GetList(ResponseTypes responseType = ResponseTypes.Json);
    }
}
