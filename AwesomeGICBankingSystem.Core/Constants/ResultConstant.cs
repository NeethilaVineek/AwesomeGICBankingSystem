using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Core.Constants
{
    public class ResultConstant
    {
        public const string AccountStatement = "| Date     | Txn Id      | Type | Amount | Balance |";
        public const string InterestRate = "| Date     | RuleId | Rate (%) |"; 
        public const string Transaction = "Please enter transaction details in <Date> <Account> <Type> <Amount> format (or enter blank to go back to main menu):";

    }
}
