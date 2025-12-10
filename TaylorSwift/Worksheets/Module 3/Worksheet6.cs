namespace TaylorSwift.Worksheets.Module_3
{
    internal class Worksheet6 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 3.6 - Calculate Power Value";
        public string Description { get; } = "Write a program that calculates the power value of the input base number and exponent number. Apply three solutions using the three looping statements:\n\nSample input/output dialogue\nEnter base no. 5\nEnter exponent no. 3\nPower value: 125";
        public System.Collections.Generic.List<decimal> Inputs { get; set; } = new System.Collections.Generic.List<decimal>();
        public System.Collections.Generic.List<string> Output { get; set; } = new System.Collections.Generic.List<string>();

        public void Operation()
        {
            Output.Clear();

            if (Inputs.Count < 2 || Inputs[1] < 0 || Inputs[1] % 1 != 0)
            {
                Output.Add("Error: Both base and a non-negative whole number exponent are required.");
                return;
            }

            decimal baseNo = Inputs[0];
            int exponentNo = (int)Inputs[1];

            // Handle the trivial case of exponent 0
            if (exponentNo == 0)
            {
                Output.Add($"Calculating {baseNo} raised to the power of {exponentNo}:");
                Output.Add("Power value: 1");
                Output.Add("All loop implementations result in 1 for an exponent of 0.");
                return;
            }

            Output.Add($"Calculating {baseNo} raised to the power of {exponentNo}:");

            // --- 1. FOR Loop Implementation ---
            decimal resultFor = 1m;

            for (int i = 0; i < exponentNo; i++)
            {
                resultFor *= baseNo;
            }
            Output.Add("\n--- FOR Loop Result ---");
            Output.Add($"Power value: {resultFor}");

            // --- 2. WHILE Loop Implementation ---
            decimal resultWhile = 1m;
            int j = 0;

            while (j < exponentNo)
            {
                resultWhile *= baseNo;
                j++;
            }
            Output.Add("\n--- WHILE Loop Result ---");
            Output.Add($"Power value: {resultWhile}");

            // --- 3. DO-WHILE Loop Implementation ---
            decimal resultDoWhile = 1m;
            int k = 0;

            do
            {
                resultDoWhile *= baseNo;
                k++;
            }
            while (k < exponentNo);

            Output.Add("\n--- DO-WHILE Loop Result ---");
            Output.Add($"Power value: {resultDoWhile}");
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

            // Input 1: Base
            System.Console.Write("Enter base number: ");
            if (System.Decimal.TryParse(System.Console.ReadLine(), out System.Decimal baseValue))
                Inputs.Add(baseValue);
            else
                Inputs.Add(0M);

            // Input 2: Exponent
            System.Console.Write("Enter exponent number: ");
            if (System.Decimal.TryParse(System.Console.ReadLine(), out System.Decimal expValue))
                Inputs.Add(expValue);
            else
                Inputs.Add(0M);

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
