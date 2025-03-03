using AwesomeGICBankingSystem.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Application.Validator
{
    public class TransactionValidator : BaseValidator
    {
        public static IEnumerable<string> Validate(string[] parts, out DateTime date, out decimal amount)
        {
            var errors = new List<string>();
            date = default;
            amount = default;

            if (parts.Length != 4)
            {
                errors.Add(ValidationConstant.InputShouldContainExactly4Parts);
                return errors;
            }

            if (!ValidateDate(parts[0], out date, out var dateError))
            {
                errors.Add(dateError);
            }
            if (!ValidateDecimal("Amount", parts[3], out amount, out var amountError))
            {
                errors.Add(amountError);
            }
            else if (amount <= 0)
            {
                errors.Add(ValidationConstant.AmountMustBeGreaterThanZero);
            }
            else if (decimal.Round(amount, 2) != amount)
            {
                errors.Add(ValidationConstant.AmountMustHaveAtMostTwoDecimalPlaces);
            }

            bool isValidType = parts[2] == ValidationConstant.Deposit || parts[2] == ValidationConstant.Withdrawal;
            if (!isValidType)
            {
                errors.Add(ValidationConstant.InvalidTransactionType);
            }

            return errors;
        }
    }
}
