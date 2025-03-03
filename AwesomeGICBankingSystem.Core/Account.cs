using AwesomeGICBankingSystem.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AwesomeGICBankingSystem.Core
{
    public class Account(string id)
    {
        private readonly Dictionary<string, int> _transactionCounters = [];

        public string Id { get; } = id;
        public decimal Balance => Transactions.Sum(t => t.Type == ValidationConstant.Deposit ? t.Amount : -t.Amount);
        public List<Transaction> Transactions { get; } = [];

        public void AddTransaction(DateTime date, string type, decimal amount)
        {
            var dateKey = date.ToString("yyyyMMdd");
            if (_transactionCounters.TryGetValue(dateKey, out int count))
            {
                _transactionCounters[dateKey] = count + 1;
            }
            else
            {
                _transactionCounters[dateKey] = 1;
            }
            var transactionId = $"{dateKey}-{_transactionCounters[dateKey]:D2}";
            Transactions.Add(new Transaction(date, transactionId, type, amount, Balance + (type == ValidationConstant.Deposit ? amount : -amount)));
        }
    }
}
