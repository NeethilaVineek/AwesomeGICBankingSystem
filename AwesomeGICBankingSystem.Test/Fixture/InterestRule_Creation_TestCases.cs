using AwesomeGICBankingSystem.Core.Constants;
using AwesomeGICBankingSystem.Test.NewFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Test.Fixture
{
    public class InterestRule_Creation_TestCases
    {
        public required string Name { get; set; }
        public required string Input { get; set; }
        public required string ExpectedRuleId { get; set; }
        public required DateTime ExpectedDate { get; set; }
        public required decimal ExpectedRate { get; set; }

        public static readonly object[][] TestData =
        [
                [
                            new InterestRule_Creation_TestCases
                            {
                                Name = "When Input string is valid - Positive",
                                Input =  "20230101 RULE01 1.95",
                                ExpectedRuleId = "RULE01",
                                ExpectedDate = new DateTime(2023, 1, 1),
                                ExpectedRate = 1.95M
                            }
                        ],
                        [
                            new InterestRule_Creation_TestCases
                            {
                                Name = "When Input string is valid - Positive",
                                Input =  "20230102 RULE02 2.80",
                                ExpectedRuleId = "RULE02",
                                ExpectedDate = new DateTime(2023, 1, 2),
                                ExpectedRate = 2.80M
                            }
                        ],
                        [
                            new InterestRule_Creation_TestCases
                            {
                                Name = "When there is existing rule on the same day - Negative",
                                Input =  "20230101 RULE01 3.95",
                                ExpectedRuleId = "RULE01",
                                ExpectedDate = new DateTime(2023, 1, 1),
                                ExpectedRate = 3.95M
                            }
                        ]
        ];
    }
}
