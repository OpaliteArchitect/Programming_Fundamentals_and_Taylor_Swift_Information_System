namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet7 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.7 - Three Variables Declaration";
        public string Description { get; } = "You can solve the worded-problem number 5 with the use of three variables declaration. Now try to solve it with only two variables declaration. Formulate with an equation that exchanges the value of variable x and y. The hint is: use 3 equations that involve with plus and minus operations.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count < 2)
            {
                Output.Add("Error: Two input values (X and Y) are required to perform the swap.");
                return;
            }

            decimal X = Inputs[0];
            decimal Y = Inputs[1];

            Output.Add($"Original State: X = {X}, Y = {Y}");

            X = X + Y;
            Output.Add($"Step 1 (X = X + Y): X is now {X}, Y is {Y}");

            Y = X - Y;
            Output.Add($"Step 2 (Y = X - Y): X is now {X}, Y is {Y} (Y is correct)");

            X = X - Y;
            Output.Add($"Step 3 (X = X - Y): X is now {X}, Y is {Y} (X is correct)");

            Output.Add("--- Swap Complete ---");
            Output.Add($"Swapped Values: X = {X}, Y = {Y}");
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