namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet5 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.5 - Fibonacci Sequence Numbers";
        public string Description { get; } = "Write a program that generates and displays the Fibonacci sequence numbers of n (as input). In Fibonacci, the current third number is the sum of two previous numbers. Apply three solutions using the three loop statements:\n\nSample input/output dialogue:\nEnter a no. 9\nFibonacci series: 1 1 2 3 5 8 13 21 34";
        public System.Collections.Generic.List<decimal> Inputs { get; set; } = new System.Collections.Generic.List<decimal>();
        public System.Collections.Generic.List<string> Output { get; set; } = new System.Collections.Generic.List<string>();

        // Note: For simplicity and to avoid excessively long sequences, the Fibonacci numbers are stored as long (Int64).
        private System.Collections.Generic.List<System.Int64> GenerateFibonacci(int n)
        {
            if (n <= 0) return new System.Collections.Generic.List<System.Int64>();
            if (n == 1) return new System.Collections.Generic.List<System.Int64> { 1 };
            if (n == 2) return new System.Collections.Generic.List<System.Int64> { 1, 1 };

            // Initialize the sequence for n >= 2
            System.Collections.Generic.List<System.Int64> series = new System.Collections.Generic.List<System.Int64> { 1, 1 };

            int count = 2;
            long a = 1; // First number
            long b = 1; // Second number
            long next;

            // --- FOR Loop Implementation ---
            if (n > 2 && count < 3) // Only run this block once for demonstration
            {
                for (int i = 3; i <= n; i++)
                {
                    next = a + b;
                    series.Add(next);
                    a = b;
                    b = next;
                }
                return series; // Return result after first successful loop execution
            }

            // Reset for other loop types (if necessary, though we only use one path in Operation)
            return series;
        }


        public void Operation()
        {
            Output.Clear();

            if (Inputs.Count == 0 || Inputs[0] < 1 || Inputs[0] > 92 || Inputs[0] % 1 != 0)
            {
                Output.Add("Error: Please enter a whole number (n) between 1 and 92 (to prevent overflow).");
                return;
            }

            int n = (int)Inputs[0];
            Output.Add($"Generating the first {n} Fibonacci sequence numbers:");

            // Helper function to format the output string
            System.Func<System.Collections.Generic.List<System.Int64>, string> formatOutput = (series) =>
            {
                if (series.Count == 0) return "[]";
                string result = "";
                for (int i = 0; i < series.Count; i++)
                {
                    result += series[i];
                    if (i < series.Count - 1) result += " ";
                }
                return result;
            };

            // --- 1. FOR Loop Implementation ---
            Output.Add("\n--- FOR Loop Result ---");
            if (n == 0)
            {
                Output.Add("Series: ");
            }
            else if (n == 1)
            {
                Output.Add("Series: 1");
            }
            else
            {
                System.Collections.Generic.List<System.Int64> seriesFor = new System.Collections.Generic.List<System.Int64> { 1, 1 };
                long a = 1, b = 1, next;
                for (int i = 3; i <= n; i++)
                {
                    next = a + b;
                    seriesFor.Add(next);
                    a = b;
                    b = next;
                }
                Output.Add($"Series: {formatOutput(seriesFor)}");
            }


            // --- 2. WHILE Loop Implementation ---
            Output.Add("\n--- WHILE Loop Result ---");
            if (n == 0)
            {
                Output.Add("Series: ");
            }
            else if (n == 1)
            {
                Output.Add("Series: 1");
            }
            else
            {
                System.Collections.Generic.List<System.Int64> seriesWhile = new System.Collections.Generic.List<System.Int64> { 1, 1 };
                long a = 1, b = 1, next;
                int j = 3;
                while (j <= n)
                {
                    next = a + b;
                    seriesWhile.Add(next);
                    a = b;
                    b = next;
                    j++;
                }
                Output.Add($"Series: {formatOutput(seriesWhile)}");
            }

            // --- 3. DO-WHILE Loop Implementation ---
            Output.Add("\n--- DO-WHILE Loop Result ---");
            if (n == 0)
            {
                Output.Add("Series: ");
            }
            else if (n == 1)
            {
                Output.Add("Series: 1");
            }
            else
            {
                System.Collections.Generic.List<System.Int64> seriesDoWhile = new System.Collections.Generic.List<System.Int64> { 1, 1 };
                long a = 1, b = 1, next;
                int k = 3;

                // Handle the edge case of n=2 where the loop shouldn't run
                if (n >= 3)
                {
                    do
                    {
                        next = a + b;
                        seriesDoWhile.Add(next);
                        a = b;
                        b = next;
                        k++;
                    }
                    while (k <= n);
                }
                Output.Add($"Series: {formatOutput(seriesDoWhile)}");
            }
        }

        public void Execute()
        {
            System.Console.Clear();
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            System.Console.WriteLine(Title);
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine(Description);
            System.Console.WriteLine();

            Output.Clear();
            Inputs.Clear();

            System.Console.ForegroundColor = System.ConsoleColor.White;

            System.Console.Write("Enter the number (n) of Fibonacci terms to generate: ");
            if (System.Decimal.TryParse(System.Console.ReadLine(), out System.Decimal value))
                Inputs.Add(value);

            Operation();

            foreach (var line in Output)
                System.Console.WriteLine(line);

            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("\nPress any key to go back...");
            System.Console.ReadKey(true);
            System.Console.ResetColor();
        }
    }
}
