namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet10 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.10 - Radius of a Circle";
        public string Description { get; } = "Write a program to compute the radius of a circle. Derive your formula from the given equation: A = πr², then display the output.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No Area (A) value provided.");
                return;
            }

            const decimal pi = 3.1416m;
            decimal area = Inputs[0];

            if (area < 0)
            {
                Output.Add("Error: Area cannot be negative.");
                return;
            }

            // r = sqrt(Area / π)
            decimal fraction = area / pi;

            // Use Math.Sqrt, casting decimal to double for the function, and back to decimal.
            decimal radius = (decimal)Math.Sqrt((double)fraction);

            Output.Add($"Area (A) entered: {area:N2}");
            Output.Add($"The calculated Radius (r) is: {radius:N4}");
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

            Console.Write("Enter the Area of the circle (A): ");
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