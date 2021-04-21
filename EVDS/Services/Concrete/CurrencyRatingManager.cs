﻿using EVDS.Constants.Enums;
using EVDS.Entities;
using EVDS.Services.Abstraction;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EVDS.Services.Concrete
{
    public class CurrencyRatingManager : ICurrencyRatingService
    {
        public async Task<IList<CurrencyRating>> GetListBySerieCodesAndDate(string[] serieCodes, DateTime startDate, DateTime endDate, ResponseTypes responseType)
        {
            HttpClient client = new HttpClient();

            var uri = Options.Host + Options.Path
               + "series=" + string.Join("-", serieCodes.Take(3))
               + "&startDate=" + startDate.ToString("dd-MM-yyyy")
               + "&endDate=" + endDate.ToString("dd-MM-yyyy")
               + "&type=" + responseType.ToString().ToLower()
               + "&key=" + Options.ApiKey;

            HttpResponseMessage response = await client.GetAsync(uri);
            string contentString = await response.Content.ReadAsStringAsync();
            var parsedJson = JObject.Parse(contentString);
            var serieRatingData = parsedJson.SelectToken("items").Children<JObject>();

            IList<CurrencyRating> serieRatingList = new List<CurrencyRating>();
            CurrencyRating newSerieRating = new CurrencyRating();

            foreach (var item in serieRatingData)
            {
                var dateValue = item.Properties().FirstOrDefault(m => m.Name == "Tarih").Value.ToString();

                foreach (var property in item.Properties())
                {
                    var regularPropertyName = property.Name.Replace("_", ".");
                    if (serieCodes.Any(m => m == regularPropertyName))
                    {
                        newSerieRating = new CurrencyRating();
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