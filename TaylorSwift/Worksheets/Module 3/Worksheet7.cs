using System;
using System.Collections.Generic;

namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet7 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.7 - Sum of Square of Numbers";
        public string Description { get; } = "Write a program to scan a number n and then output the sum of the squares from 1 to n. Thus, if the input is 4, the output should be 30 because: 1^2+2^2+3^2+4^2 = 1+4+9+16 = 30.";
        public List<decimal> Inputs { get; set; } = new List<decimal>();
        public List<string> Output { get; set; } = new List<string>();

        public void Operation()
        {
            Output.Clear();

            if (Inputs.Count == 0 || Inputs[0] < 1 || Inputs[0] % 1 != 0)
            {
                Output.Add("Error: Please enter a positive whole number (n).");
                return;
            }

            int n = (int)Inputs[0];
            Output.Add($"Calculating the sum of squares from 1^2 to {n}^2:");
            Output.Add($"(i.e., 1^2 + 2^2 + ... + {n}^2)");

            // --- 1. FOR Loop Implementation ---
            long sumFor = 0;
            for (int i = 1; i <= n; i++)
            {
                sumFor += (long)i * i;
            }
            Output.Add("\n--- FOR Loop Result ---");
            Output.Add($"Sum of Squares: {sumFor}");

            // --- 2. WHILE Loop Implementation ---
            long sumWhile = 0;
            int j = 1;

            while (j <= n)
            {
                sumWhile += (long)j * j;
                j++;
            }
            Output.Add("\n--- WHILE Loop Result ---");
            Output.Add($"Sum of Squares: {sumWhile}");

            // --- 3. DO-WHILE Loop Implementation ---
            long sumDoWhile = 0;
            int k = 1;

            // The do-while loop needs special handling for n=0, but n is validated to be >= 1.
            // For n=1, this loop runs once (k=1, sum=1, k=2, condition fails).
            do
            {
                sumDoWhile += (long)k * k;
                k++;
            }
            while (k <= n);

            Output.Add("\n--- DO-WHILE Loop Result ---");
            Output.Add($"Sum of Squares: {sumDoWhile}");
        }

        public void Execute()
        {
            Console.Clear();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Title);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Description);
            Console.WriteLine();

            Output.Clear();
            Inputs.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter a number (n) for the sum of squares: ");
            if (Decimal.TryParse(Console.ReadLine(), out Decimal value))
                Inputs.Add(value);
            else
                Inputs.Add(0M);

            Operation();

            foreach (var line in Output)
                Console.WriteLine(line);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey(true);
            Console.ResetColor();
        }
    }
}
