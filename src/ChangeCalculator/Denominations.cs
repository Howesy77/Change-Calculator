using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ChangeCalculator
{
    internal static class DenominationsHelper
    {
        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }
    }

    public enum Denominations
    {
        [Display(Name = "Fifty pound note")]
        FiftyPound = 5000,
        [Display(Name = "Twenty pound note")]
        TwentyPound = 2000,
        [Display(Name = "Ten pound note")]
        TenPound = 1000,
        [Display(Name = "Five pound note")]
        FivePound = 500,
        [Display(Name = "Two pound coin")]
        TwoPound = 200,
        [Display(Name = "One pound coin")]
        OnePound = 100,
        [Display(Name = "Fifty pence piece")]
        FiftyPence = 50,
        [Display(Name = "Twenty pence piece")]
        TwentyPence = 20,
        [Display(Name = "Ten pence piece")]
        TenPence = 10,
        [Display(Name = "Five pence piece")]
        FivePence = 5,
        [Display(Name = "Two pence piece")]
        TwoPence = 2,
        [Display(Name = "One pence piece")]
        OnePence = 1
    }
}
