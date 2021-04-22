using EVDS.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVDS.Entities
{
    public class EvdsCurrencyRatingRequest
    {
        public string CurrencyCode { get; set; }
        public string OperationType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ResponseType { get; set; }
    }
}
