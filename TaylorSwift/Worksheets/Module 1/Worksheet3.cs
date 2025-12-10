namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet3 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.3 - Peso-Dollar Conversion";
        public string Description { get; } = "Write a program that converts the input dollar to its peso exchange rate equivalent. Assume that the present exchange rate is 53.95 pesos against the dollar. Then display the peso equivalent exchange rate.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No dollar amount provided for conversion.");
                return;
            }

            const decimal exchangeRate = 53.95m;
            decimal dollars = Inputs[0];

            // Peso equivalent = Dollars * Exchange Rate
            decimal pesos = dollars * exchangeRate;

            Output.Add($"US${dollars:N2} is equivalent to PHP{pesos:N2} (at a rate of {exchangeRate} PHP/USD).");
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

            Console.Write("Enter amount in US Dollars ($): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
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