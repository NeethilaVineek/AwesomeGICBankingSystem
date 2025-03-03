using AwesomeGICBankingSystem.Core.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Application.Validator
{
    public class BaseValidator
    {
        public static bool ValidateDate(string dateString, out DateTime date, out string error)
        {
            if (!DateTime.TryParseExact(dateString, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                error = ValidationConstant.DateFormatIsInvalid;
                return false;
            }
            error = string.Empty;
            return true;
        }
        public static bool ValidateDecimal(string fieldName, string numberString, out decimal rate, out string error)
        {
            if (!decimal.TryParse(numberString, out rate))
            {
                error = $"{fieldName} {ValidationConstant.FormatIsInvalid}";
                return false;
            }
            error = string.Empty;
            return true;
        }
    }
}
