using System;

namespace EVDS.Entities
{
    public class EvdsCurrencyRating
    {
        public string SerieCode { get; set; }
        public DateTime Date { get; set; }
        public decimal? Rating { get; set; }
    }
}
