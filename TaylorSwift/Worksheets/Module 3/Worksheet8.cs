using System;
using System.Collections.Generic;

namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet8 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.8 - Calculate Sum of Sequence of Numbers";
        public string Description { get; } = "Write a program to calculate the sum of the sequence no. from 1 to n. Thus if the input is 6, the output should be 21 because: (Apply the three looping statements in your solutions) 1+2+3+4+5+6=21.";
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
            Output.Add($"Calculating the sum of sequence numbers from 1 to {n}:");
            Output.Add($"(i.e., 1 + 2 + 3 + ... + {n})");

            // --- 1. FOR Loop Implementation ---
            long sumFor = 0;
            for (int i = 1; i <= n; i++)
            {
                sumFor += i;
            }
            Output.Add("\n--- FOR Loop Result ---");
            Output.Add($"Sum of Sequence: {sumFor}");

            // --- 2. WHILE Loop Implementation ---
            long sumWhile = 0;
            int j = 1;

            while (j <= n)
            {
                sumWhile += j;
                j++;
            }
            Output.Add("\n--- WHILE Loop Result ---");
            Output.Add($"Sum of Sequence: {sumWhile}");

            // --- 3. DO-WHILE Loop Implementation ---
            long sumDoWhile = 0;
            int k = 1;

            // Note: Since n >= 1 is guaranteed by input validation, the do-while loop will execute at least once.
            do
            {
                sumDoWhile += k;
                k++;
            }
            while (k <= n);

            Output.Add("\n--- DO-WHILE Loop Result ---");
            Output.Add($"Sum of Sequence: {sumDoWhile}");
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

            Console.Write("Enter a number (n) for the sequence sum: ");
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
