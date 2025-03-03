using AwesomeGICBankingSystem.Application;
using AwesomeGICBankingSystem.Core.Constants;
using AwesomeGICBankingSystem.Test.Fixture;
namespace AwesomeGICBankingSystem.Test
{
    public class InputTransactionTests 
    {
        [Theory]
        [MemberData(nameof(InputTransaction_ErrorExpectation_TestCases.TTestData), MemberType = typeof(InputTransaction_ErrorExpectation_TestCases))]
        public void Validate_Transactions_Constraints(InputTransaction_ErrorExpectation_TestCases fixture) 
        {
            // Arrange
            var bankService = new BankService();
            var inputReader = new StringReader(fixture.Input);
            Console.SetIn(inputReader);
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            // Act
            bankService.InputTransactions();

            // Assert
            var output = outputWriter.ToString();
            var transactionValidationMessages = output.Split(Environment.NewLine)
                                           .Where(line => line.Contains(ValidationConstant.InputShouldContainExactly4Parts) ||
                                                          line.Contains(ValidationConstant.DateFormatIsInvalid) ||
                                                          line.Contains(ValidationConstant.FormatIsInvalid) ||
                                                          line.Contains(ValidationConstant.AmountMustBeGreaterThanZero) ||
                                                          line.Contains(ValidationConstant.AmountMustHaveAtMostTwoDecimalPlaces) ||
                                                          line.Contains(ValidationConstant.InvalidTransactionType) ||
                                                          line.Contains(ValidationConstant.TransactionDeclined))

                                           .ToList();
            Assert.Equal(fixture.ExpectedError, transactionValidationMessages.FirstOrDefault()?? string.Empty);
        }

    }
}
