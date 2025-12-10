namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet5 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.5 - Two Variables";
        public string Description { get; } = "Write a program that exchanges the value of two variables: x and y. The output must be: The value of variable y will become the value of variable x, and vice versa.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count < 2)
            {
                Output.Add("Error: Two input values (X and Y) are required to perform the swap.");
                return;
            }

            // Retrieve the two input values
            decimal x = Inputs[0];
            decimal y = Inputs[1];

            Output.Add($"Original State: X = {x}, Y = {y}");

            // Standard swapping logic using a temporary variable
            decimal temp = x;
            x = y;
            y = temp;

            Output.Add("--- Swapping values ---");
            Output.Add($"New State: X = {x}, Y = {y}");
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

            // Input for variable X
            Console.Write("Enter value for variable X: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valueX))
                Inputs.Add(valueX);
            else
                Inputs.Add(0M);

            // Input for variable Y
            Console.Write("Enter value for variable Y: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal valueY))
                Inputs.Add(valueY);
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