namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet8 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.8 - Purchase Price";
        public string Description { get; } = "Write a program that takes as input the purchase price of an item (P), its expected number of years of service (Y) and its expected salvage value (S). Then outputs the yearly depreciation for the item (D). Use the formula: D = (P - S) / Y.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count < 3)
            {
                Output.Add("Error: Three inputs (Price, Years, Salvage Value) are required.");
                return;
            }

            decimal P = Inputs[0]; // Purchase Price
            decimal Y = Inputs[1]; // Years of Service
            decimal S = Inputs[2]; // Salvage Value

            if (Y <= 0)
            {
                Output.Add("Error: Years of service (Y) must be greater than zero for depreciation calculation.");
                return;
            }

            // D = (P - S) / Y
            decimal depreciation = (P - S) / Y;

            Output.Add($"Purchase Price (P): {P:N2}");
            Output.Add($"Years of Service (Y): {Y:N0}");
            Output.Add($"Salvage Value (S): {S:N2}");
            Output.Add($"The Yearly Depreciation (D) is: {depreciation:N2}");
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

            // Input P (Purchase Price)
            Console.Write("Enter Purchase Price (P): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal pValue))
                Inputs.Add(pValue);
            else
                Inputs.Add(0M);

            // Input Y (Years of Service)
            Console.Write("Enter Years of Service (Y): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal yValue))
                Inputs.Add(yValue);
            else
                Inputs.Add(0M);

            // Input S (Salvage Value)
            Console.Write("Enter Salvage Value (S): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal sValue))
                Inputs.Add(sValue);
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