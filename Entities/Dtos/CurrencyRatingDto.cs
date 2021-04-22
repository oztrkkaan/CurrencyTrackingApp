using Core.Entities;
using System;


namespace Entities.Dtos
{
   public class CurrencyRatingDto : IDto
    {
        public int Id { get; set; }
        public decimal? Rating { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyId { get; set; }
    }
}
