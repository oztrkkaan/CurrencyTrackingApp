using EVDS.Constants.Enums;
using EVDS.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EVDS.Services.Concrete
{
    public class SerieManager : ISerieService
    {

        public async Task<IList<SerieResponse>> GetList(ResponseTypes responseType = ResponseTypes.Json)
        {
            HttpClient client = new HttpClient();

            var uri = Options.Host + Options.Path
                + "serieList/"
                + "&key=" + Options.ApiKey
                + "&type=" + responseType.ToString().ToLower()
                + "&code=" + DataGroup.bie_dkdovizgn;

            HttpResponseMessage response = await client.GetAsync(uri);
            string contentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<SerieResponse>>(contentString);
        }
    }
}
