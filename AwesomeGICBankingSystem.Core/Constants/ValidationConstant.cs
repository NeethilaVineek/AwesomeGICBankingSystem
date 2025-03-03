using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Core.Constants
{
    public class ValidationConstant
    {
        public const string InputShouldContainExactly2Parts = "Input should contain exactly 2 parts.";
        public const string InputShouldContainExactly3Parts = "Input should contain exactly 3 parts.";
        public const string InputShouldContainExactly4Parts = "Input should contain exactly 4 parts.";
        public const string DateFormatIsInvalid = "Date format is invalid. Expected format is yyyyMMdd."; 
        public const string AccountStatementDateFormatIsInvalid = "Date format is invalid. Expected format is yyyyMM."; 
        public const string FormatIsInvalid = "is in invalid format."; 
        public const string AmountMustBeGreaterThanZero = "Amount must be greater than zero.";
        public const string AmountMustHaveAtMostTwoDecimalPlaces = "Amount must have atmost two decimal places.";
        public const string InvalidTransactionType = "Invalid Transaction Type.";
        public const string InterestRateMustBeBetween0And100 = "Interest Rate must be between 0 and 100.";
        public const string TransactionDeclined = "Insufficient balance. Transaction declined."; 
        public const string Deposit = "D";
        public const string Withdrawal = "W";
        public const string AccountNotFound = "Account not found.";
    }
}
