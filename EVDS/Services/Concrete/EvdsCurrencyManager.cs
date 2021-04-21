using EVDS.Constants.Enums;
using EVDS.Entities;
using EVDS.Services.Abstraction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EVDS.Services.Concrete
{
    public class EvdsCurrencyManager : IEvdsCurrencyService
    {

        public async Task<IList<EvdsCurrency>> GetList(ResponseTypes responseType = ResponseTypes.Json)
        {
            HttpClient client = new HttpClient();

            var uri = Options.Host + Options.Path
                + "serieList/"
                + "&key=" + Options.ApiKey
                + "&type=" + responseType.ToString().ToLower()
                + "&code=" + DataGroup.bie_dkdovizgn;

            HttpResponseMessage response = await client.GetAsync(uri);
            string contentString = await response.Content.ReadAsStringAsync();
            try
            {
              return  JsonConvert.DeserializeObject<List<EvdsCurrency>>(contentString);
            }
            catch (Exception ex)
            {
                var x = ex;
                throw;
            }
        }
    }
}
