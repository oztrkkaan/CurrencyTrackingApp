using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Constants
{
    public static class CurrencyEnum
    {

        public static class OperationTypes
        {
            public const string Buy = "A";
            public const string Sell = "S";
            public const string Cross = "C";
        }

        public static IList<ListItem> CurrencyTypeList = new List<ListItem>() {
                new ListItem {Text="Alış", Value=OperationTypes.Buy },
                new ListItem { Text = "Satış", Value = OperationTypes.Sell },
                new ListItem { Text = "Çapraz", Value = OperationTypes.Cross }
        };
        public static ListItem GetCurrencyTypeByOperationType(string operationTypeValue)
        {
            return CurrencyTypeList.SingleOrDefault(m => m.Value == operationTypeValue);
        }

    }
}
