using AwesomeGICBankingSystem.Core.Constants;
using AwesomeGICBankingSystem.Test.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Test.Fixture
{
    public class InterestRule_ErrorExpectation_TestCases : Base_Fixture
    {
        public static readonly object[][] TestData =
        [
                [
                    new InterestRule_ErrorExpectation_TestCases
                    {
                        Name = "When Input string is valid - Positive",
                        Input =  "20230101 RULE01 1.95",
                        ExpectedError = string.Empty
                    }
                ],
                [
                    new InterestRule_ErrorExpectation_TestCases
                    {
                        Name = "When Input string does not contain 3 Parts - Negative",
                        Input = "20230101 RULE01",
                        ExpectedError = ValidationConstant.InputShouldContainExactly3Parts
                    }
                ],
                [
                    new InterestRule_ErrorExpectation_TestCases
                    {
                        Name = "When Date Format contains YYYYMM - Negative",
                        Input = "202301 RULE01 1.95",
                        ExpectedError = ValidationConstant.DateFormatIsInvalid
                    }
                ],
                [
                    new InterestRule_ErrorExpectation_TestCases
                    {
                        Name = "When Interest Rate greater than 100 - Negative",
                        Input = "20230101 RULE01 200",
                        ExpectedError = ValidationConstant.InterestRateMustBeBetween0And100
                    }
                ],
                [
                    new InterestRule_ErrorExpectation_TestCases
                    {
                        Name = "When Interest Rate less than 0 - Negative",
                        Input = "20230101 RULE01 -4.5",
                        ExpectedError = ValidationConstant.InterestRateMustBeBetween0And100
                    }
                ],
                [
                    new InterestRule_ErrorExpectation_TestCases
                    {
                        Name = "When Interest Rate is in invalid format - Negative",
                        Input = "20230101 RULE01 A",
                        ExpectedError = $"Interest Rate {ValidationConstant.FormatIsInvalid}"
                    }
                ]
        ];
    }
}
