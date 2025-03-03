using AwesomeGICBankingSystem.Application.Validator;
using AwesomeGICBankingSystem.Core;
using AwesomeGICBankingSystem.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Application
{
    public class BankService()
    {
        private readonly Dictionary<string, Account> _accounts = [];
        public readonly List<InterestRule> _interestRules = [];

        public void InputTransactions()
        {
            while (true)
            {
                Console.WriteLine(RequestInputConstant.Transaction);
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) break;

                var parts = input.Split(' ');
                var errors = TransactionValidator.Validate(parts, out var date, out var amount);
                if (errors.Any())
                {
                    PrintResultService.PrintErrors(errors);
                    continue;
                }
                var accountId = parts[1];
                var type = parts[2].ToUpper();
                if (!_accounts.TryGetValue(accountId, out Account? account))
                {
                    account = new Account(accountId);
                    _accounts[accountId] = account;
                }

                if (type == ValidationConstant.Withdrawal && account.Balance < amount)
                {
                    Console.WriteLine(ValidationConstant.TransactionDeclined);
                    continue;
                }

                account.AddTransaction(date, type, amount);
                PrintResultService.PrintAccountStatement(account, _interestRules);
            }
        }

        public void DefineInterestRules()
        {
            while (true)
            {
                Console.WriteLine(RequestInputConstant.InterestRule);
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;

                var parts = input.Split(' ');
                var errors = InterestRuleValidator.Validate(parts, out var date, out var rate);
                if (errors.Any())
                {
                    PrintResultService.PrintErrors(errors);
                    continue;
                }

                var ruleId = parts[1];
                _interestRules.RemoveAll(r => r.Date == date);
                _interestRules.Add(new InterestRule(date, ruleId, rate));
                PrintResultService.PrintInterestRules(_interestRules);
            }
        }
        public void PrintStatement()
        {
            Console.WriteLine(RequestInputConstant.AccountStatement);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;

            var parts = input.Split(' ');

            if (!AccountStatementInputValidator.Validate(parts, out var date, out var errorMessage))
            {
                Console.WriteLine(errorMessage);
                return;
            }

            var accountId = parts[0];
            if (!_accounts.TryGetValue(accountId, out Account? account))
            {
                Console.WriteLine(ValidationConstant.AccountNotFound);
                return;
            }

            PrintResultService.PrintAccountStatement(account, _interestRules, date);
        }

    }
}
