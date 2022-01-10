using System;

namespace ChangeCalculator
{
    class Program
    {
        static void Main()
        {
            do
            {
                Console.WriteLine("--------------------------------");

                var purchasePrice = GetValue("How much is the total purchase price?");
                var tenderedAmount = GetValue("How much was tendered?");

                try
                {
                    var change = Calculator.CalculateChange(purchasePrice, tenderedAmount);

                    Console.WriteLine("Change required is");

                    foreach (var item in change)
                    {
                        Console.WriteLine($"{item.Item2} {item.Item1.GetEnumDisplayName()}{(item.Item2 > 1 ? "s" : "")}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        private static decimal GetValue(string message)
        {
            Console.WriteLine(message);

            do
            {
                var value = Console.ReadLine();

                if (!decimal.TryParse(value, out decimal amount))
                {
                    Console.WriteLine("Please enter a valid amount");
                    continue;
                }

                if (amount <= decimal.Zero)
                {
                    Console.WriteLine("Amount must be greater than 0");
                    continue;
                }

                return decimal.Round(amount, 2);
            } while (true);
        }
    }
}
