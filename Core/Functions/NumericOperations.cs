namespace Core.Functions
{
    public static class NumericOperations
    {
        public static decimal MaskedMoneyToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            value = value.Replace("₺", "").Replace("_", "").Replace(".", "").Replace(" ", "");
            return decimal.Parse(value);
        }
    }
}
