using EVDS.Constants.Enums;
using EVDS.Entities;
using EVDS.Services.Abstraction;
using EVDS.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EVDS.Services.Concrete
{
    public class EvdsCurrencyRatingManager : IEvdsCurrencyRatingService
    {
        public async Task<IList<EvdsCurrencyRating>> GetByCodeAndDate(string currencyCode, string operationType, DateTime startDate, DateTime? endDate, ResponseTypes responseType = ResponseTypes.Json)
        {
            HttpClient client = new HttpClient();

            var uri = Options.Host + Options.Path
               + "series=" + StringHelper.SerieCodeGenerator(currencyCode, operationType)
               + "&startDate=" + startDate.ToString("dd-MM-yyyy")
               + (endDate.HasValue ? "&endDate=" + endDate.Value.ToString("dd-MM-yyyy") : "")
               + "&type=" + responseType.ToString().ToLower()
               + "&key=" + Options.ApiKey;

            HttpResponseMessage response = await client.GetAsync(uri);
            string contentString = await response.Content.ReadAsStringAsync();
            var parsedJson = JObject.Parse(contentString);
            var serieRatingData = parsedJson.SelectToken("items").Children<JObject>();

            IList<EvdsCurrencyRating> serieRatingList = new List<EvdsCurrencyRating>();
            EvdsCurrencyRating newSerieRating = new EvdsCurrencyRating();

            foreach (var item in serieRatingData)
            {
                var dateValue = item.Properties().FirstOrDefault(m => m.Name == "Tarih").Value.ToString();

                foreach (var property in item.Properties())
                {
                    var regularPropertyName = property.Name.Replace("_", ".");
                    if (StringHelper.SerieCodeGenerator(currencyCode, operationType) == regularPropertyName)
                    {
                        newSerieRating = new EvdsCurrencyRating();
                        newSerieRating.CurrencyCode = currencyCode;
                        newSerieRating.OperationType = operationType;

                        newSerieRating.Date = DateTime.ParseExact(dateValue, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        newSerieRating.SerieCode = regularPropertyName;
                        newSerieRating.Rating = (decimal?)property.Value;

                        serieRatingList.Add(newSerieRating);
                    }
                }
            }

            return serieRatingList;
        }

    }
}
