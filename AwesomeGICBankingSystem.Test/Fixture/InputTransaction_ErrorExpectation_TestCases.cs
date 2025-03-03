using AwesomeGICBankingSystem.Core.Constants;
using AwesomeGICBankingSystem.Test.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGICBankingSystem.Test.Fixture
{
    public class InputTransaction_ErrorExpectation_TestCases
    {
        public required string Name { get; set; }
        public required string Input { get; set; }
        public required string ExpectedError { get; set; }

        public static readonly object[][] TTestData =
        [
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Input string is valid - Positive",
                        Input = "20230507 AC001 D 100",
                        ExpectedError = string.Empty
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Input string does not contain 4 Parts - Negative",
                        Input = "20230505 AC001 W",
                        ExpectedError = ValidationConstant.InputShouldContainExactly4Parts
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Date Format contains YYYYMM - Negative",
                        Input = "202305 AC001 W 100",
                        ExpectedError = ValidationConstant.DateFormatIsInvalid
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Date is invalid - Negative",
                        Input = "20250231 AC001 W 100",
                        ExpectedError = ValidationConstant.DateFormatIsInvalid
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Amount is in invalid format - Negative",
                        Input = "20230505 AC001 W A",
                        ExpectedError = $"Amount {ValidationConstant.FormatIsInvalid}"
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Amount is negative number - Negative",
                        Input = "20230505 AC001 W -1",
                        ExpectedError = ValidationConstant.AmountMustBeGreaterThanZero
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Input string does not contain 4 Parts - Negative",
                        Input = "20230505 AC001 W 200.343",
                        ExpectedError = ValidationConstant.AmountMustHaveAtMostTwoDecimalPlaces
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Input string does not contain 4 Parts - Negative",
                        Input = "20230505 AC001 I 100",
                        ExpectedError = ValidationConstant.InvalidTransactionType
                    }
                ],
                [
                    new InputTransaction_ErrorExpectation_TestCases
                    {
                        Name = "When Input string does not contain 4 Parts - Negative",
                        Input = "20230505 AC001 W 100",
                        ExpectedError = ValidationConstant.TransactionDeclined
                    }
                ]
        ];
    }
}
