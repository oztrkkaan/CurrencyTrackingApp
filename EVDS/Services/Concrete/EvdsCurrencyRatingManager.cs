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
        public async Task<IList<EvdsCurrencyRating>> GetListByCodeAndDate(EvdsCurrencyRatingRequest request)
        {
            HttpClient client = new HttpClient();

            var uri = Options.Host + Options.Path
               + "series=" + StringHelper.SerieCodeGenerator(request.CurrencyCode, request.OperationType)
               + "&startDate=" + request.StartDate.ToString("dd-MM-yyyy")
               + (request.EndDate.HasValue ? "&endDate=" + request.EndDate.Value.ToString("dd-MM-yyyy") : "")
               + "&type=" + request.ResponseType.ToString().ToLower()
               + "&key=" + Options.ApiKey;

            HttpResponseMessage response = await client.GetAsync(uri);
            string contentString = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(contentString))
            {
                return new List<EvdsCurrencyRating>();
            }
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
                    if (StringHelper.SerieCodeGenerator(request.CurrencyCode, request.OperationType) == regularPropertyName)
                    {
                        newSerieRating = new EvdsCurrencyRating();
                        newSerieRating.CurrencyCode = request.CurrencyCode;
                        newSerieRating.OperationType = request.OperationType;

                        newSerieRating.Date = DateTime.ParseExact(dateValue, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        newSerieRating.SerieCode = regularPropertyName;
                        newSerieRating.Rating = (decimal?)property.Value;

                        serieRatingList.Add(newSerieRating);
                    }
                }
            }

            return serieRatingList;
        }


        public async Task<IList<EvdsCurrencyRating>> GetListByCodeAndDate(string[] currencyCodes, string operationType, DateTime startDate, DateTime? endDate = null, ResponseTypes responseType = ResponseTypes.Json)
        {
            HttpClient client = new HttpClient();
            var currencySerieCodes = currencyCodes.Select(m => m = StringHelper.SerieCodeGenerator(m, operationType)).ToArray();
            var uri = Options.Host + Options.Path
               + "series=" + string.Join("-", currencySerieCodes)
               + "&startDate=" + startDate.ToString("dd-MM-yyyy")
               + "&endDate=" + (endDate.HasValue ? endDate.Value.ToString("dd-MM-yyyy") : startDate.ToString("dd-MM-yyyy"))
               + "&type=" + responseType.ToString().ToLower()
               + "&key=" + Options.ApiKey;

            HttpResponseMessage response = await client.GetAsync(uri);
            string contentString = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(contentString))
            {
                return new List<EvdsCurrencyRating>();
            }
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
                    var currentCurrency = currencySerieCodes.FirstOrDefault(m => m == regularPropertyName);
                    if (currentCurrency != null)
                    {
                        newSerieRating = new EvdsCurrencyRating();
                        newSerieRating.CurrencyCode = currentCurrency;
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
