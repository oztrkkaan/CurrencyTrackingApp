﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EVDS.Entities
{
    public class SerieRating
    {
        public string SerieCode { get; set; }
        public DateTime Date { get; set; }
        public decimal? Rating { get; set; }
    }
}