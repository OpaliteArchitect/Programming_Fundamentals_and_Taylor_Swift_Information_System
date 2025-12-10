using System;
using System.Collections.Generic;

namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet9 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.9 - Reverse Input Number";
        public string Description { get; } = "Write a program that reverses the input number n. Formulate an equation to come up with the answer: (Apply the three loop statements in your solutions)\n\nSample Input/output dialogue:\nEnter a number. 1238\nReverse number: 8321";
        public List<decimal> Inputs { get; set; } = new List<decimal>();
        public List<string> Output { get; set; } = new List<string>();

        public void Operation()
        {
            Output.Clear();

            if (Inputs.Count == 0 || Inputs[0] < 0 || Inputs[0] % 1 != 0)
            {
                Output.Add("Error: Please enter a non-negative whole number (n).");
                return;
            }

            // Using long to safely handle the reversal process on the input number.
            long originalNumber = (long)Inputs[0];
            Output.Add($"Input Number (n): {originalNumber}");

            // --- 1. FOR Loop Implementation ---
            long reversedFor = 0;
            long tempFor = originalNumber;

            Output.Add("\n--- 1. FOR Loop Result ---");
            if (tempFor == 0)
            {
                Output.Add("Reverse number: 0");
            }
            else
            {
                // The loop structure relies on the 'increment' portion for division.
                for (; tempFor > 0; tempFor /= 10)
                {
                    long digit = tempFor % 10;
                    reversedFor = reversedFor * 10 + digit;
                }
                Output.Add($"Reverse number: {reversedFor}");
            }


            // --- 2. WHILE Loop Implementation (The standard way) ---
            long reversedWhile = 0;
            long tempWhile = originalNumber;

            Output.Add("\n--- 2. WHILE Loop Result ---");
            if (tempWhile == 0)
            {
                Output.Add("Reverse number: 0");
            }
            else
            {
                while (tempWhile > 0)
                {
                    long digit = tempWhile % 10;
                    reversedWhile = reversedWhile * 10 + digit;
                    tempWhile /= 10;
                }
                Output.Add($"Reverse number: {reversedWhile}");
            }


            // --- 3. DO-WHILE Loop Implementation ---
            long reversedDoWhile = 0;
            long tempDoWhile = originalNumber;

            Output.Add("\n--- 3. DO-WHILE Loop Result ---");
            if (tempDoWhile == 0)
            {
                // Handle 0 separately for clarity, though single digit inputs work with the loop.
                Output.Add("Reverse number: 0");
            }
            else
            {
                do
                {
                    long digit = tempDoWhile % 10;
                    reversedDoWhile = reversedDoWhile * 10 + digit;
                    tempDoWhile /= 10;
                }
                while (tempDoWhile > 0);

                Output.Add($"Reverse number: {reversedDoWhile}");
            }
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

            Console.Write("Enter a number to reverse (n): ");
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
