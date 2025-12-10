namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet4 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.4 - Measurement Conversion";
        public string Description { get; } = "Write a program that converts an input inch (es) into its equivalent centimeters. Take note that one inch is equivalent to 2.54 cms.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No inches value provided for conversion.");
                return;
            }

            const decimal conversionFactor = 2.54m;
            decimal inches = Inputs[0];

            // Centimeters = Inches * Conversion Factor
            decimal centimeters = inches * conversionFactor;

            Output.Add($"{inches:N2} inch(es) is equivalent to {centimeters:N2} centimeters.");
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

            Console.Write("Enter length in inches (in): ");
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