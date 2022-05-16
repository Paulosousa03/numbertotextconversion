using System;
using System.Linq;
using System.Text;
using Nut.Models;

namespace Nut.TextConverters
{
  public sealed class LatvianConverter : BaseConverter
  {

    private static readonly Lazy<LatvianConverter> Lazy = new Lazy<LatvianConverter>(() => new LatvianConverter());
    public static LatvianConverter Instance => Lazy.Value;

    public override string CultureName => Culture.Latvian;

    public LatvianConverter()
    {
      Initialize();
    }
    
    protected override long Append(long num, long scale, StringBuilder builder)
    {
      if (num > scale - 1)
      {
        var baseScale = num / scale;

        if (scale != 1000 || baseScale != 1)
        {
          AppendLessThanOneThousand(baseScale, builder);
        }

        builder.AppendFormat("{0} ", ScaleTexts[scale][0]);
        num = num - (baseScale * scale);
      }
      return num;
    }

    protected override long AppendTens(long num, StringBuilder builder)
    {
      if (num > 20)
      {

        if (num == 80)
        {
          builder.AppendFormat("{0}", NumberTexts[num][1]);
          return 0;
        }

        var tens = ((int)(num / 10)) * 10;

        if (tens == 70 || tens == 90)
        {
          tens = tens - 10;

          if (num - tens == 11)
          {
            builder.AppendFormat("{0} ", NumberTexts[tens][0]);
            builder.AppendFormat("{0} ", NumberTexts[num - tens][1]);
            return 0;
          }

          builder.AppendFormat("{0}-", NumberTexts[tens][0]);

        }
        else
        {
          builder.AppendFormat("{0} ", NumberTexts[tens][0]);

          var etUnList = new long[] { 21, 31, 41, 51, 61 };
          if (etUnList.Contains(num))
          {
            builder.AppendFormat("{0} ", NumberTexts[num - tens][1]);
            return 0;
          }
        }

        num = num - tens;
      }
      return num;
    }

    protected override long AppendHundreds(long num, StringBuilder builder)
    {
        if (num > 99)
        {
            var hundreds = num / 100;
            if (hundreds != 1)
                builder.AppendFormat("{0} {1} ", NumberTexts[hundreds][0], NumberTexts[100][0]);
            else
                builder.AppendFormat("{0} ", NumberTexts[100][0]);
            num = num - (hundreds * 100);
        }
        return num;
    }

    private void Initialize()
    {
      NumberTexts.Add(0, new[] { "nulle" });
      NumberTexts.Add(1, new[] { "viens" });
      NumberTexts.Add(2, new[] { "divi" });
      NumberTexts.Add(3, new[] { "trīs" });
      NumberTexts.Add(4, new[] { "četri" });
      NumberTexts.Add(5, new[] { "pieci" });
      NumberTexts.Add(6, new[] { "seši" });
      NumberTexts.Add(7, new[] { "septini" });
      NumberTexts.Add(8, new[] { "astoņi" });
      NumberTexts.Add(9, new[] { "deviņi" });
      NumberTexts.Add(10, new[] { "desmit" });
      NumberTexts.Add(11, new[] { "vienpadsmit" });
      NumberTexts.Add(12, new[] { "divpadsmit" });
      NumberTexts.Add(13, new[] { "trīspadsmit" });
      NumberTexts.Add(14, new[] { "četrpadsmit" });
      NumberTexts.Add(15, new[] { "piecpadsmit" });
      NumberTexts.Add(16, new[] { "sešpadsmit" });
      NumberTexts.Add(17, new[] { "septiņpadsmit" });
      NumberTexts.Add(18, new[] { "astoņpadsmit" });
      NumberTexts.Add(19, new[] { "deviņpadsmit" });
      NumberTexts.Add(20, new[] { "divdesmit" });
      NumberTexts.Add(30, new[] { "trīsdesmit" });
      NumberTexts.Add(40, new[] { "četrdesmit" });
      NumberTexts.Add(50, new[] { "piecdesmit" });
      NumberTexts.Add(60, new[] { "sešdesmit" });
      NumberTexts.Add(80, new[] { "astoņdesmit" });
      NumberTexts.Add(100, new[] { "simts" });

      ScaleTexts.Add(1000000000, new[] { "miljards" });
      ScaleTexts.Add(1000000, new[] { "miljons" });
      ScaleTexts.Add(1000, new[] { "tūkstoš" });
    }

    protected override CurrencyModel GetCurrencyModel(string currency)
    {
      switch (currency)
      {
        case Currency.EUR:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "euro", "euros" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "centime", "centimes" } }
          };
        case Currency.USD:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "dollar", "dollars" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "centime", "centimes" } }
          };
        case Currency.RUB:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "rouble", "roubles" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "kopeck ", "kopecks" } }
          };
        case Currency.TRY:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "livre turques", "livres turques" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "kuruş", "kuruş" } }
          };
        case Currency.UAH:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "hryvnia ukrainienne", "hryvnias ukrainienne" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "kopiyka", "kopiyka" } }
          };
        case Currency.ETB:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "Birr", "Birr" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "centime", "centimes" } }
          };
        case Currency.PLN:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "zloty", "zloty" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "groszy", "groszy" } }
          };
        case Currency.BYN:
          return new CurrencyModel
          {
            Currency = currency,
            Names = new[] { "rouble biélorusse", "roubles biélorusses" },
            SubUnitCurrency = new BaseCurrencyModel { Names = new[] { "kopeck ", "kopecks" } }
          };
      }
      return null;
    }
  }
}