using System.Collections.Generic;
using System.Linq;

internal static class FromRomanNumerals
{
  public static int Convert(string romanNumber)
  {
    var romanNumerals = SplitRomanNumerals(romanNumber);
    var decimals = ConvertToDecimal(romanNumerals);
    var negatedDecimals = NegateWhenLarger(decimals);
    return Sum(negatedDecimals);
  }

  private static char[] SplitRomanNumerals(string romanNumber)
  {
    return romanNumber.ToCharArray();
  }

  private static int[] ConvertToDecimal(IEnumerable<char> romanNumerals)
  {
    var mapping = new Dictionary<char, int> {{'I', 1}, {'V', 5},
                           {'X', 10}, {'L', 50}, {'C', 100},
                           {'D', 500}, {'M', 1000}};
    return romanNumerals.Select(x => mapping[x]).ToArray();
  }

  private static int[] NegateWhenLarger(int[] decimals)
  {
    var result = new int[decimals.Length];
    for (var i = 0; i < decimals.Length; i++)
    {
      if (i < decimals.Length - 1 && decimals[i] < decimals[i + 1])
      {
        result[i] = -decimals[i];
      }
      else
      {
        result[i] = decimals[i];
      }
    }
    return result;
  }

  private static int Sum(int[] decimals)
  {
    return decimals.Sum();
  }
}