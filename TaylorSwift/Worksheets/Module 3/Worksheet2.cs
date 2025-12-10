namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet2 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.2 - Produce Number Sequence";
        public string Description { get; } = "Write a program which produces the given sequence nos. (in alternate arrangement) using the three looping statements: 1, 5, 2, 4, 3, 3, 4, 2, 5, 1,";
        public System.Collections.Generic.List<decimal> Inputs { get; set; } = new System.Collections.Generic.List<decimal>();
        public System.Collections.Generic.List<string> Output { get; set; } = new System.Collections.Generic.List<string>();

        public void Operation()
        {
            Output.Clear();

            // --- 1. FOR Loop Implementation ---
            Output.Add("--- FOR Loop Results ---");
            string resultFor = "";
            for (int i = 1; i <= 5; i++)
            {
                // Concatenates the current number (i) and its inverse (6-i)
                resultFor += i.ToString() + ", " + (6 - i).ToString();
                if (i < 5) resultFor += ", ";
            }
            Output.Add($"Sequence: {resultFor}");

            // --- 2. WHILE Loop Implementation ---
            Output.Add("\n--- WHILE Loop Results ---");
            string resultWhile = "";
            int j = 1;
            while (j <= 5)
            {
                // Concatenates the current number (j) and its inverse (6-j)
                resultWhile += j.ToString() + ", " + (6 - j).ToString();
                if (j < 5) resultWhile += ", ";
                j++;
            }
            Output.Add($"Sequence: {resultWhile}");

            // --- 3. DO-WHILE Loop Implementation ---
            Output.Add("\n--- DO-WHILE Loop Results ---");
            string resultDoWhile = "";
            int k = 1;
            do
            {
                // Concatenates the current number (k) and its inverse (6-k)
                resultDoWhile += k.ToString() + ", " + (6 - k).ToString();
                if (k < 5) resultDoWhile += ", ";
                k++;
            }
            while (k <= 5);
            Output.Add($"Sequence: {resultDoWhile}");
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
