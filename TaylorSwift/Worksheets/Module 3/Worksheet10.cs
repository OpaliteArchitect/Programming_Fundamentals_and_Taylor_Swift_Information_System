using System;
using System.Collections.Generic;

namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet10 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.10 - Sum of Power N";
        public string Description { get; } = "Write a program to scan a number n and then output the sum of the powers from 1 to n. Thus, if the input is 4, the output should be 288 because: 1^1+2^2+3^3+4^4 = 1 + 4 + 27 + 256 = 288. (Apply the three loop statements in your solutions)";
        public List<decimal> Inputs { get; set; } = new List<decimal>();
        public List<string> Output { get; set; } = new List<string>();

        // Helper function to calculate base^exponent using loops
        private long CalculatePower(int baseNum, int exponent)
        {
            if (exponent == 0) return 1;
            if (baseNum == 0) return 0;

            long result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }

        public void Operation()
        {
            Output.Clear();

            if (Inputs.Count == 0 || Inputs[0] < 1 || Inputs[0] > 10 || Inputs[0] % 1 != 0)
            {
                // Limiting n to 10 to prevent long overflow for n^n calculation (10^10 is large)
                Output.Add("Error: Please enter a positive whole number (n) between 1 and 10.");
                return;
            }

            int n = (int)Inputs[0];
            Output.Add($"Calculating the sum of powers from 1^1 to {n}^{n}:");

            // --- 1. FOR Loop Implementation ---
            long sumFor = 0;
            for (int i = 1; i <= n; i++)
            {
                sumFor += CalculatePower(i, i);
            }
            Output.Add("\n--- 1. FOR Loop Result ---");
            Output.Add($"Sum of Powers: {sumFor}");

            // --- 2. WHILE Loop Implementation ---
            long sumWhile = 0;
            int j = 1;

            while (j <= n)
            {
                sumWhile += CalculatePower(j, j);
                j++;
            }
            Output.Add("\n--- 2. WHILE Loop Result ---");
            Output.Add($"Sum of Powers: {sumWhile}");

            // --- 3. DO-WHILE Loop Implementation ---
            long sumDoWhile = 0;
            int k = 1;

            do
            {
                sumDoWhile += CalculatePower(k, k);
                k++;
            }
            while (k <= n);

            Output.Add("\n--- 3. DO-WHILE Loop Result ---");
            Output.Add($"Sum of Powers: {sumDoWhile}");
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

            Console.Write("Enter a number (n): ");
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
