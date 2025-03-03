using AwesomeGICBankingSystem.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Application.Validator
{
    public class InterestRuleValidator : BaseValidator
    {
        public static IEnumerable<string> Validate(string[] parts, out DateTime date, out decimal rate)
        {
            var errors = new List<string>();
            date = default;
            rate = default;
            if (parts.Length != 3)
            {
                errors.Add(ValidationConstant.InputShouldContainExactly3Parts);
                return errors;
            }
            if (!ValidateDate(parts[0], out date, out var dateError))
            {
                errors.Add(dateError);
            }
            if (!ValidateDecimal("Interest Rate", parts[2], out rate, out var rateError))
            {
                errors.Add(rateError);
            }
            if (rate <= 0 || rate >= 100)
            {
                errors.Add(ValidationConstant.InterestRateMustBeBetween0And100);
            }
            return errors;
        }
    }
}
