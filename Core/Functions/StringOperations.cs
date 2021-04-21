using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Functions
{
    public static class StringOperations
    {
        public static string ToUrlFriendly(this string value)
        {
            value = value.ToLower().Replace("&", "").Replace(".", "-").Replace("ş", "s").Replace("ü", "u").Replace("ö", "o").Replace("ı", "i").Replace("ğ", "g").Replace("ç", "c").Replace(",", "").Replace(".", "").Replace("'", "").Replace("(", "").Replace(")", "").Replace("!", "");
            value = Regex.Replace(value, @"\s+", " ", RegexOptions.Compiled).Replace(" ", "-");
            return value;
        }
        public static string SuffixEA(this string value, string e, string a)
        {
            string[] consonantLetters = { "a", "ı", "o", "u", "e", "i", "ö", "ü" };
            int textLength = value.Length;
            for (int i = textLength - 1; i > 0; i--)
            {
                int counter = 0;
                foreach (var letter in consonantLetters)
                {
                    string currentLetter = value.Substring(i, 1);
                    if (currentLetter == letter)
                    {
                        return value += "'" + (counter < 4 ? a : e);
                    }
                    counter++;
                }
            }
            return value;
        }
        public static string GetFirstLetters(this string value)
        {
            if (string.IsNullOrEmpty(value))
            { return null; }
            var words = value.Split(' ');
            if (words.Length == 1)
            {
                return words[0].Substring(0, 1).ToUpper();
            }
            else if (words.Length >= 2)
            {
                return words[0].Substring(0, 1) + words[words.Length - 1].Substring(0, 1).ToUpper();
            }
            else
            {
                return string.Empty;
            }
        }
        public static string TimeDifferentText(this DateTime dateTime)
        {
            TimeSpan timeSpan = new TimeSpan();
            timeSpan = dateTime - DateTime.Now;
            if (timeSpan.TotalMinutes > 1)
            {
                if (timeSpan.TotalHours > 23)
                {
                    if (timeSpan.TotalDays == 30)
                    {
                        return Math.Floor(timeSpan.TotalDays) + " gün sonra";
                    }
                    else if (timeSpan.TotalDays > 30)
                    {
                        if (timeSpan.TotalDays > 365)
                        {
                            return dateTime.ToShortDateString().ToString();
                        }
                        else
                        {
                            return Math.Floor(timeSpan.TotalDays / 30).ToString() + " ay " + Math.Floor(timeSpan.TotalDays % 30).ToString() + " gün sonra";
                        }
                    }
                    else
                    {
                        if (timeSpan.TotalHours >= 24 && timeSpan.TotalHours < 48)
                        {
                            return "yarın";
                        }
                        else
                        {
                            return Math.Floor(timeSpan.TotalDays) + " gün sonra";
                        }
                    }
                }
                else
                {
                    return Math.Floor(timeSpan.TotalHours) + " saat sonra";
                }
            }
            else if (timeSpan.TotalMinutes <= 0 && timeSpan.TotalMinutes > -1)
            {
                return (Math.Ceiling(timeSpan.TotalSeconds) * -1).ToString() + " saniye önce";
            }
            else if (timeSpan.TotalMinutes <= -1 && timeSpan.TotalMinutes > -60)
            {
                return (Math.Ceiling(timeSpan.TotalMinutes) * -1).ToString() + " dakika önce";
            }
            else
            {
                if (timeSpan.TotalHours < -23)
                {
                    if (timeSpan.TotalHours <= -24 && timeSpan.TotalHours > -48)
                    {
                        return "dün";
                    }
                    if (timeSpan.TotalDays == 30)
                    {
                        return (Math.Ceiling(timeSpan.TotalDays) * -1).ToString() + " gün önce";
                    }
                    else if (timeSpan.TotalDays < -30)
                    {
                        if (timeSpan.TotalDays < -365)
                        {
                            return dateTime.ToShortDateString().ToString();
                        }
                        else
                        {
                            return (Math.Ceiling(timeSpan.TotalDays / 30) * -1).ToString() + " ay " + (Math.Floor(timeSpan.TotalDays % 30) * -1).ToString() + " gün önce";
                        }
                    }
                    else
                    {
                        if (timeSpan.TotalHours <= -24 && timeSpan.TotalHours > -48)
                        {
                            return "dün";
                        }
                        else
                        {
                            return (Math.Ceiling(timeSpan.TotalDays) * -1).ToString() + " gün önce";
                        }
                    }
                }
                else
                {
                    return (Math.Floor(timeSpan.TotalHours) * -1).ToString() + " saat önce";
                }
            }
        }
        public static string RemoveHtml(this string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : Regex.Replace(value, "<.*?>", String.Empty);
        }
        public static string SelectTextByMaxLength(this string value, int maxLength)
        {
            value = value.RemoveHtml();
            return value.Length < maxLength ? value : value.Substring(0, maxLength) + "...";
        }
        public static string UpperCaseFirstLetters(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.IsNullOrEmpty(value) ? "" : value.ToLower()).ToString();
        }
        public static string GetMonthName(int monthId, bool isLong = true)
        {
            List<string[]> Months = new List<string[]>();

            Months.Add(new string[] { "Ocak", "Oca" });
            Months.Add(new string[] { "Şubat", "Şub" });
            Months.Add(new string[] { "Mart", "Mar" });
            Months.Add(new string[] { "Nisan", "Nis" });
            Months.Add(new string[] { "Mayıs", "May" });
            Months.Add(new string[] { "Haziran", "Haz" });
            Months.Add(new string[] { "Temmuz", "Tem" });
            Months.Add(new string[] { "Ağustos", "Ağu" });
            Months.Add(new string[] { "Eylül", "Eyl" });
            Months.Add(new string[] { "Ekim", "Eki" });
            Months.Add(new string[] { "Kasım", "Kas" });
            Months.Add(new string[] { "Aralık", "Ara" });

            return Months.ElementAt(monthId - 1)[isLong == true ? 0 : 1];


        }
        public static string TranslateNumberToText(int number)
        {
            string tenthousandsDigit = "", thousandsDigit = "", hundredsDigit = "", tensDigit = "", unitsDigit = "";
            int step4, step3, step2, step, step5;

            step5 = number / 10000;
            number = number % 10000;
            switch (step5)
            {
                case 1: tenthousandsDigit = "on"; break;
                case 2: tenthousandsDigit = "yirmi"; break;
                case 3: tenthousandsDigit = "otuz"; break;
                case 4: tenthousandsDigit = "kırk"; break;
                case 5: tenthousandsDigit = "elli"; break;
                case 6: tenthousandsDigit = "altmış"; break;
                case 7: tenthousandsDigit = "yetmiş"; break;
                case 8: tenthousandsDigit = "seksen"; break;
                case 9: tenthousandsDigit = "doksan"; break;
            }

            step4 = number / 1000;
            number = number % 1000;
            switch (step4)
            {
                case 2: thousandsDigit = "ikibin"; break;
                case 3: thousandsDigit = "üçbin"; break;
                case 4: thousandsDigit = "dörtbin"; break;
                case 5: thousandsDigit = "beşbin"; break;
                case 6: thousandsDigit = "altıbin"; break;
                case 1: thousandsDigit = "bin"; break;
                case 7: thousandsDigit = "yedibin"; break;
                case 8: thousandsDigit = "sekizbin"; break;
                case 9: thousandsDigit = "dokuzbin"; break;
            }
            step3 = number / 100;
            number = number % 100;
            switch (step3)
            {
                case 1: hundredsDigit = "yüz"; break;
                case 2: hundredsDigit = "ikiyüz"; break;
                case 3: hundredsDigit = "üçyüz"; break;
                case 4: hundredsDigit = "dörtyüz"; break;
                case 5: hundredsDigit = "beşyüz"; break;
                case 6: hundredsDigit = "altıyüz"; break;
                case 7: hundredsDigit = "yediyüz"; break;
                case 8: hundredsDigit = "sekizyüz"; break;
                case 9: hundredsDigit = "dokuzyüz"; break;
            }
            step2 = number / 10;
            number = number % 10;
            switch (step2)
            {
                case 1: tensDigit = "on"; break;
                case 2: tensDigit = "yirmi"; break;
                case 3: tensDigit = "otuz"; break;
                case 4: tensDigit = "kırk"; break;
                case 5: tensDigit = "elli"; break;
                case 6: tensDigit = "altmış"; break;
                case 7: tensDigit = "yetmiş"; break;
                case 8: tensDigit = "seksen"; break;
                case 9: tensDigit = "doksan"; break;
            }
            step = number / 1;
            number = number % 1;
            switch (step)
            {

                case 1: unitsDigit = "bir"; break;
                case 2: unitsDigit = "iki"; break;
                case 3: unitsDigit = "üç"; break;
                case 4: unitsDigit = "dört"; break;
                case 5: unitsDigit = "beş"; break;
                case 6: unitsDigit = "altı"; break;
                case 7: unitsDigit = "yedi"; break;
                case 8: unitsDigit = "sekiz"; break;
                case 9: unitsDigit = "dokuz"; break;
            }
            if (tenthousandsDigit == "" && thousandsDigit == "" && hundredsDigit == "" && tensDigit == "" && step == 0)
            {
                unitsDigit = "sıfır";
            }

            return (tenthousandsDigit + " " + thousandsDigit + " " + hundredsDigit + " " + tensDigit + " " + unitsDigit).Trim();
        }

        public static int LengthWithoutHtml(this string value)
        {
            return string.IsNullOrEmpty(value) ? 0 : (Regex.Replace(value, "<.*?>", String.Empty)).Length;
        }
    }
}
