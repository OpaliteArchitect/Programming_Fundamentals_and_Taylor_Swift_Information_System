namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet4 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.4 - Calculate Factorial Value";
        public string Description { get; } = "Write a program to calculate the factorial value of the input number n. Use the incrementation formula (i++) for your solution instead of decrementation formula (i--). Apply the three looping statements for your solutions.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            Output.Clear();

            // Input validation: Must be a non-negative whole number, and constrained due to factorial growth (20! is the max for 'long').
            if (Inputs.Count == 0 || Inputs[0] < 0 || Inputs[0] > 20 || Inputs[0] % 1 != 0)
            {
                Output.Add("Error: Please enter a whole number (n) between 0 and 20.");
                return;
            }

            int n = (int)Inputs[0];
            Output.Add($"Calculating Factorial for n = {n}");

            // --- 1. FOR Loop Implementation (using i++) ---
            Int64 resultFor = 1;
            Output.Add("\n--- FOR Loop Result (i++) ---");
            for (int i = 1; i <= n; i++)
            {
                resultFor *= i;
            }
            Output.Add($"Factorial ({n}!) = {resultFor}");

            // --- 2. WHILE Loop Implementation (using i++) ---
            Int64 resultWhile = 1;
            int j = 1;
            Output.Add("\n--- WHILE Loop Result (i++) ---");
            while (j <= n)
            {
                resultWhile *= j;
                j++;
            }
            Output.Add($"Factorial ({n}!) = {resultWhile}");

            // --- 3. DO-WHILE Loop Implementation (using i++) ---
            Int64 resultDoWhile = 1;
            int k = 1;
            Output.Add("\n--- DO-WHILE Loop Result (i++) ---");

            if (n == 0)
            {
                // Factorial of 0 is 1. The loop for k=1 to 0 would not run.
                resultDoWhile = 1;
            }
            else
            {
                do
                {
                    resultDoWhile *= k;
                    k++;
                }
                while (k <= n);
            }

            Output.Add($"Factorial ({n}!) = {resultDoWhile}");
        }

        public void Execute()
        {
            System.Console.Clear();
            System.Console.ResetColor();

            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine(Title);
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(Description);
            System.Console.WriteLine();

            Output.Clear();
            Inputs.Clear();

            System.Console.ForegroundColor = System.ConsoleColor.White;

            System.Console.Write("Enter a number (n) to calculate its factorial (0-20 recommended): ");
            if (Decimal.TryParse(System.Console.ReadLine(), out Decimal value))
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
