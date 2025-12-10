namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet3 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.3 - Determine Temperature Value";
        public string Description { get; } = "Write a program that examines the value of a variable called temp. Then display the following messages, depending on the value assigned to temp.\n\nTemperature\t\tMessage\nLess than 0\t\tICE\nBetween 0 and 100\tWATER\nExceeds 100\t\tSTEAM";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No temperature value provided.");
                return;
            }

            decimal temp = Inputs[0];
            string message;

            // Using if-else if-else structure to check the ranges sequentially
            if (temp < 0)
            {
                message = "ICE";
            }
            else if (temp >= 0 && temp <= 100)
            {
                message = "WATER";
            }
            else // temp > 100
            {
                message = "STEAM";
            }

            Output.Add($"Temperature entered: {temp:N2}°C");
            Output.Add($"State Message: {message}");
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

            Console.Write("Enter temperature value (temp): ");
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