using AwesomeGICBankingSystem.Application;
using AwesomeGICBankingSystem.Core;
using AwesomeGICBankingSystem.Core.Constants;
using AwesomeGICBankingSystem.Test.Fixture;
using System;
using System.Collections.Generic;
using System.Data;
using Xunit;

namespace AwesomeGICBankingSystem.Test
{
    public class InterestRuleTests
    {
        [Theory]
        [MemberData(nameof(InterestRule_ErrorExpectation_TestCases.TestData), MemberType = typeof(InterestRule_ErrorExpectation_TestCases))]
        public void Validate_InterestRules_Constraints(InterestRule_ErrorExpectation_TestCases fixture)
        {
            // Arrange
            var bankService = new BankService();
            var inputReader = new StringReader(fixture.Input);
            Console.SetIn(inputReader);
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            // Act
            bankService.DefineInterestRules();

            // Assert
            var output = outputWriter.ToString();
            var interestRateValidationMessages = output.Split(Environment.NewLine)
                                           .Where(line => line.Contains(ValidationConstant.InputShouldContainExactly3Parts) ||
                                                          line.Contains(ValidationConstant.DateFormatIsInvalid) ||
                                                          line.Contains(ValidationConstant.FormatIsInvalid) ||
                                                          line.Contains(ValidationConstant.InterestRateMustBeBetween0And100))
                                           .ToList();
            Assert.Equal(fixture.ExpectedError, interestRateValidationMessages.FirstOrDefault() ?? string.Empty);
        }

        [Theory]
        [MemberData(nameof(InterestRule_Creation_TestCases.TestData), MemberType = typeof(InterestRule_Creation_TestCases))]
        public void Validate_InterestRules_Creation(InterestRule_Creation_TestCases fixture)
        {
            // Arrange
            var bankService = new BankService();
            var inputReader = new StringReader(fixture.Input);
            Console.SetIn(inputReader);
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            // Act
            bankService.DefineInterestRules();

            // Assert
            var rule = bankService._interestRules.FirstOrDefault(x => x.RuleId == fixture.ExpectedRuleId);
            Assert.Equal(fixture.ExpectedDate, rule!.Date);
            Assert.Equal(fixture.ExpectedRuleId, rule.RuleId);
            Assert.Equal(fixture.ExpectedRate, rule.Rate);
        }
    }
}
