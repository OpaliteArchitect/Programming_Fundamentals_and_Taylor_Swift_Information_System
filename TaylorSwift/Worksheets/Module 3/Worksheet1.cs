using System;
using System.Collections.Generic;

namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet1 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.1 - Calculate Looping Sequence Number";
        public string Description { get; } = "Write a program that calculates and produces these two columns sequence numbers using the three looping statements:\n\nSequence nos.\tSquared\n1\t\t1\n2\t\t4\n3\t\t9\n4\t\t16\n5\t\t25";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            Output.Clear();
            Output.Add(string.Format("{0,-15}{1,-10}", "SEQUENCE NOS.", "SQUARED"));

            // --- 1. FOR Loop Implementation ---
            Output.Add("\n--- FOR Loop Results ---");
            for (int i = 1; i <= 5; i++)
            {
                decimal sequenceNo = i;
                decimal squared = sequenceNo * sequenceNo;
                Output.Add(string.Format("{0,-15}{1,-10}", sequenceNo, squared));
            }

            // --- 2. WHILE Loop Implementation ---
            Output.Add("\n--- WHILE Loop Results ---");
            int j = 1;
            while (j <= 5)
            {
                decimal sequenceNo = j;
                decimal squared = sequenceNo * sequenceNo;
                Output.Add(string.Format("{0,-15}{1,-10}", sequenceNo, squared));
                j++;
            }

            // --- 3. DO-WHILE Loop Implementation ---
            Output.Add("\n--- DO-WHILE Loop Results ---");
            int k = 1;
            do
            {
                decimal sequenceNo = k;
                decimal squared = sequenceNo * sequenceNo;
                Output.Add(string.Format("{0,-15}{1,-10}", sequenceNo, squared));
                k++;
            }
            while (k <= 5);
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

            // No user input required for this worksheet, but maintaining the structure
            // Console.ForegroundColor = ConsoleColor.White;
            // Console.Write("Enter input (N/A): "); 

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
