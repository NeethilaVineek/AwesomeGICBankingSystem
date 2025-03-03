using AwesomeGICBankingSystem;
using AwesomeGICBankingSystem.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a host builder
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // Register your services here
                services.AddAppDI();
            })
            .Build();

        var bankService = host.Services.GetRequiredService<BankService>();

        StartBankingSystem(bankService);
    }
    public static void StartBankingSystem(BankService bankService)
    {
        while (true)
        {
            Console.WriteLine("Welcome to AwesomeGIC Bank! What would you like to do?");
            Console.WriteLine("[T] Input transactions");
            Console.WriteLine("[I] Define interest rules");
            Console.WriteLine("[P] Print statement");
            Console.WriteLine("[Q] Quit");
            Console.Write("> ");
            var choice = Console.ReadLine()?.ToUpper();

            switch (choice)
            {
                case "T":
                    bankService.InputTransactions();
                    break;
                case "I":
                    bankService.DefineInterestRules();
                    break;
                case "P":
                    bankService.PrintStatement();
                    break;
                case "Q":
                    Console.WriteLine("Thank you for banking with AwesomeGIC Bank.");
                    Console.WriteLine("Have a nice day!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
