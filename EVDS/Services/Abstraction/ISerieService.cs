using EVDS.Constants.Enums;
using EVDS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVDS.Services.Concrete
{
    public interface ISerieService
    {
        Task<IList<SerieResponse>> GetList(ResponseTypes responseType = ResponseTypes.Json);


    }
}
