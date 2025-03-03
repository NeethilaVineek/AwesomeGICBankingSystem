using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Core
{
    public class InterestRule(DateTime date, string ruleId, decimal rate)
    {
        public DateTime Date { get; } = date;
        public string RuleId { get; } = ruleId;
        public decimal Rate { get; } = rate;
    }
}
