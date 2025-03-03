using AwesomeGICBankingSystem.Application.Validator;
using AwesomeGICBankingSystem.Core.Constants;
using AwesomeGICBankingSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Application
{
    public class PrintResultService
    {
        public static void PrintAccountStatement(Account account, List<InterestRule> interestRules, DateTime? month = null)
        {
            Console.WriteLine($"Account: {account.Id}");
            Console.WriteLine(ResultConstant.AccountStatement);
            var transactions = account.Transactions;
            if (month.HasValue)
            {
                transactions = [.. transactions.Where(t => t.Date.Year == month.Value.Year && t.Date.Month == month.Value.Month)];
            }

            foreach (var transaction in transactions)
            {
                Console.WriteLine($"| {transaction.Date:yyyyMMdd} | {transaction.Id} | {transaction.Type} | {transaction.Amount,7:F2} | {transaction.Balance,7:F2} |");
            }

            if (month.HasValue)
            {
                var interest = InterestRateService.Calculate(account, month.Value, interestRules);
                if (interest > 0)
                {
                    Console.WriteLine($"| {month.Value:yyyyMM}30 |            | I    | {interest,7:F2} | {account.Balance + interest,7:F2} |");
                }
            }
        }

        public static void PrintInterestRules(List<InterestRule> interestRules)
        {
            Console.WriteLine("Interest rules:");
            Console.WriteLine(ResultConstant.InterestRate);
            foreach (var rule in interestRules.OrderBy(r => r.Date))
            {
                Console.WriteLine($"| {rule.Date:yyyyMMdd} | {rule.RuleId} | {rule.Rate,8:F2} |");
            }
        }
        public static void PrintErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}
