namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet6 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.6 - Circumference of a Circle";
        public string Description { get; } = "Design a program to find the circumference of a circle. Use the formula: C = 2πr, where π is approximately equivalent to 3.1416.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No radius value provided for calculation.");
                return;
            }

            const decimal pi = 3.1416m;
            const decimal num2 = 2m;
            decimal radius = Inputs[0];

            // C = 2 * π * r
            decimal circumference = num2 * pi * radius;

            Output.Add($"The radius (r) is: {radius:N2}");
            Output.Add($"The circumference (C) is: {circumference:N4}");
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

            Console.Write("Enter the circle's radius (r): ");
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