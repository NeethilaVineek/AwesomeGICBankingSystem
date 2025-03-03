using AwesomeGICBankingSystem.Core.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Application.Validator
{
    public static class AccountStatementInputValidator
    {
        public static bool Validate(string[] parts, out DateTime date, out string errorMessage)
        {
            date = default;
            errorMessage = string.Empty;

            if (parts.Length != 2)
            {
                errorMessage = ValidationConstant.InputShouldContainExactly2Parts;
                return false;
            }

            if (!DateTime.TryParseExact(parts[1], "yyyyMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                errorMessage = ValidationConstant.AccountStatementDateFormatIsInvalid;
                return false;
            }

            return true;
        }
    }
}
