using AwesomeGICBankingSystem.Core;
using AwesomeGICBankingSystem.Core.Constants;

namespace AwesomeGICBankingSystem.Application.Validator
{
    public class InterestRateService
    {
        public static decimal Calculate(Account account, DateTime month, List<InterestRule> _interestRules) 
        {
            var interest = 0m;
            var daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            var endOfMonth = new DateTime(month.Year, month.Month, daysInMonth);
            var transactions = account.Transactions;
            var balance = transactions.Where(t => t.Date < new DateTime(month.Year, month.Month, 1))
                .Sum(t => t.Type == ValidationConstant.Deposit ? t.Amount : -t.Amount); ;
            var applicableRules = _interestRules.Where(r => r.Date <= endOfMonth).OrderBy(r => r.Date).ToList();

            for (var day = 1; day <= daysInMonth; day++)
            {
                var date = new DateTime(month.Year, month.Month, day);
                var rule = applicableRules.LastOrDefault(r => r.Date <= date);
                if (rule != null)
                {
                    interest += balance * rule.Rate / 100 / 365;
                }

                var currentTransactions = account.Transactions.Where(t => t.Date == date).ToList();
                foreach (var transaction in currentTransactions)
                {
                    balance += transaction.Type == ValidationConstant.Deposit ? transaction.Amount : -transaction.Amount;
                }
            }

            return Math.Round(interest, 2);
        } 
    }
}