using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Core.Constants
{
    public class RequestInputConstant 
    {
        public const string Transaction = "Please enter transaction details in <Date> <Account> <Type> <Amount> format (or enter blank to go back to main menu):";

        public const string InterestRule = "Please enter interest rules details in <Date> <RuleId> <Rate in %> format (or enter blank to go back to main menu):";

        public const string AccountStatement = "Please enter account and month to generate the statement <Account> <Year><Month> (or enter blank to go back to main menu):";
    }
}
