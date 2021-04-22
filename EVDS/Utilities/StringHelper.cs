using EVDS.Constants.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVDS.Utilities
{
   public static class StringHelper
    {
        public static string SerieCodeGenerator(string code, string operationType)
        {
            return $"TP.DK.{code}.{operationType}.YTL";
        }
    }
}
