namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet9 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.9 - Economic Order Quantity (EOQ)";
        public string Description { get; } = "Determine the most economical quantity to be stocked (EOQ) using the formula: EOQ = sqrt( (2 * R * S) / I ). Where R is the total yearly requirement, S is the setup cost per order, and I is the inventory carrying cost per unit.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count < 3)
            {
                Output.Add("Error: Three inputs (Requirement (R), Setup Cost (S), Carrying Cost (I)) are required.");
                return;
            }

            decimal R = Inputs[0]; // Yearly Production Requirement
            decimal S = Inputs[1]; // Setup Cost per Order
            decimal I = Inputs[2]; // Inventory Carrying Cost per Unit

            if (I <= 0)
            {
                Output.Add("Error: Inventory Carrying Cost (I) must be greater than zero.");
                return;
            }
            if (R < 0 || S < 0)
            {
                Output.Add("Error: Requirement (R) and Setup Cost (S) cannot be negative.");
                return;
            }

            // Calculation: EOQ = sqrt( (2 * R * S) / I )
            const decimal num2 = 2m;
            decimal numerator = num2 * R * S;
            decimal fraction = numerator / I;

            // Use Math.Sqrt, casting decimal to double for the function, and back to decimal.
            decimal eoq = (decimal)Math.Sqrt((double)fraction);

            Output.Add($"Yearly Requirement (R): {R:N0} units");
            Output.Add($"Setup Cost (S): ${S:N2}");
            Output.Add($"Inventory Carrying Cost (I): ${I:N2}");
            Output.Add($"The Economic Order Quantity (EOQ) is: {eoq:N0} units (rounded to nearest whole unit)");
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

            // Input R (Yearly Requirement)
            Console.Write("Enter Yearly Requirement (R) in units: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal rValue))
                Inputs.Add(rValue);
            else
                Inputs.Add(0M);

            // Input S (Setup Cost)
            Console.Write("Enter Setup Cost per Order (S): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal sValue))
                Inputs.Add(sValue);
            else
                Inputs.Add(0M);

            // Input I (Inventory Carrying Cost)
            Console.Write("Enter Inventory Carrying Cost per Unit (I): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal iValue))
                Inputs.Add(iValue);
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