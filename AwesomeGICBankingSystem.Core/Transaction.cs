using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Core
{
    public class Transaction(DateTime date, string id, string type, decimal amount, decimal balance)
    {
        public DateTime Date { get; } = date;
        public string Id { get; } = id;
        public string Type { get; } = type;
        public decimal Amount { get; } = amount;
        public decimal Balance { get; } = balance;
    }
}
