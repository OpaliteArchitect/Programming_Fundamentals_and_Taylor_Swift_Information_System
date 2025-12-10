namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet2 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.2 - Temp Conversion";
        public string Description { get; } = "Write a program that converts the input Celsius degree into its equivalent Fahrenheit degree. Use the formula: F = (9/5) * C + 32.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No Celsius value provided.");
                return;
            }

            decimal celsius = Inputs[0];
            const decimal num9 = 9, num5 = 5, num32 = 32;

            // F = (9/5) * C + 32
            decimal fahrenheit = (num9 / num5) * celsius + num32;

            Output.Add($"{celsius} degrees Celsius is equivalent to {fahrenheit:F2} degrees Fahrenheit.");
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
            Console.Write("Enter temperature in Celsius (C): ");

            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                Inputs.Add(value);
            else
                Inputs.Add(0M); // Add a default value if parsing fails to avoid index out of range

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