using System;

namespace EVDS.Entities
{
    public class EvdsCurrencyRating
    {
        public string CurrencyCode { get; set; }
        public string SerieCode { get; set; }
        public string OperationType { get; set; }
        public DateTime Date { get; set; }
        public decimal? Rating { get; set; }
    }
}
