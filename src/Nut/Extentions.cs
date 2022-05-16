﻿using System;
using System.Globalization;
using System.Linq;
using Nut.TextConverters;

namespace Nut
{
    public static class Extentions
    {

        public static string ToText(this long num, string lang = Language.Default, GenderGroup genderGroup = GenderGroup.None)
        {
            var text = string.Empty;
            switch (lang)
            {
                case Language.English:
                case Culture.EnglishUS:
                case Culture.EnglishGB:
                    text = EnglishConverter.Instance.ToText(num);
                    break;
                case Language.French:
                case Culture.French:
                    text = FrenchConverter.Instance.ToText(num);
                    break;
                case Language.Russian:
                case Culture.Russian:
                    text = RussianConverter.Instance.ToText(num);
                    break;
                case Language.Spanish:
                case Culture.Spanish:
                    text = SpanishConverter.Instance.ToText(num, genderGroup);
                    break;
                case Language.Turkish:
                case Culture.Turkish:
                    text = TurkishConverter.Instance.ToText(num);
                    break;
                case Language.Ukrainian:
                case Culture.Ukrainian:
                    text = UkrainianConverter.Instance.ToText(num);
                    break;
                case Language.Bulgarian:
                case Culture.Bulgarian:
                    text = BulgarianConverter.Instance.ToText(num);
                    break;
                case Language.Amharic:
                case Culture.EthiopianAM:
                    text = AmharicConverter.Instance.ToText(num);
                    break;
                case Language.Polish:
                case Culture.Polish:
                    text = PolishConverter.Instance.ToText(num);
                    break;
                case Language.Belarusian:
                case Culture.Belarusian:
                    text = BelarusianConverter.Instance.ToText(num);
                    break;
                case Language.Latvian:
                case Culture.Latvian:
                    text = LatvianConverter.Instance.ToText(num);
                    break;
            }
            return text;
        }

        public static string ToText(this decimal num, string currency, string lang = Language.Default, Options options = new Options(), GenderGroup genderGroup = GenderGroup.None)
        {
            var text = string.Empty;
            switch (lang)
            {
                case Language.English:
                case Culture.EnglishUS:
                case Culture.EnglishGB:
                    text = EnglishConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.French:
                case Culture.French:
                    text = FrenchConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.Russian:
                case Culture.Russian:
                    text = RussianConverter.Instance.ToText(num, currency, options);
                    break;

                case Language.Polish:
                case Culture.Polish:
                    text = PolishConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.Spanish:
                case Culture.Spanish:
                    text = SpanishConverter.Instance.ToText(num, currency, options, genderGroup);
                    break;
                case Language.Turkish:
                case Culture.Turkish:
                    text = TurkishConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.Ukrainian:
                case Culture.Ukrainian:
                    text = UkrainianConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.Bulgarian:
                case Culture.Bulgarian:
                    text = BulgarianConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.Amharic:
                case Culture.EthiopianAM:
                    text = AmharicConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.Belarusian:
                case Culture.Belarusian:
                    text = BelarusianConverter.Instance.ToText(num, currency, options);
                    break;
                case Language.Latvian:
                case Culture.Latvian:
                    text = LatvianConverter.Instance.ToText(num, currency, options);
                    break;
            }
            return text;
        }

        public static string ToText(this int num, string lang = Language.Default, GenderGroup genderGroup = GenderGroup.None)
        {
            return ToText(Convert.ToInt64(num), lang.ToLower(), genderGroup);
        }

        public static string ToText(this int num, string currency, string lang)
        {
            return ToText(Convert.ToDecimal(num), currency.ToLower(), lang.ToLower());
        }

        internal static string ToFirstLetterUpper(this string text, string culture = null)
        {
            var cultureInfo = string.IsNullOrEmpty(culture) ? CultureInfo.InvariantCulture : new CultureInfo(culture);
            return text.First().ToString().ToUpper(cultureInfo) + text.Substring(1);
        }

    }
}
