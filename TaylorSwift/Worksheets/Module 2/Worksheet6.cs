namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet6 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.6 - Determine Earthquake Range";
        public string Description { get; } = "The National Earthquake Information Center has the following criteria to determine the earthquake's damage. Here are the given Richter scale criteria and their corresponding characterization. The Richter scale serves as the input data and the characterization as output information.\n\nRichter Numbers (n)\tCharacterization\nLess than 5.0\tLittle or no damage\n5.0 <= n < 5.5\tSome damage\n5.5 <= n < 6.5\tSerious damage\n6.5 <= n < 7.5\tDisaster\nHigher (n >= 7.5)\tCatastrophe";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No Richter scale value provided.");
                return;
            }

            decimal richterScale = Inputs[0];
            string message;

            // Using if-else if-else structure to determine the category based on the progressive scale
            // The conditions are checked from highest magnitude downwards for efficiency and clarity.
            if (richterScale >= 7.5M)
            {
                message = "Catastrophe";
            }
            else if (richterScale >= 6.5M)
            {
                message = "Disaster";
            }
            else if (richterScale >= 5.5M)
            {
                message = "Serious damage";
            }
            else if (richterScale >= 5.0M)
            {
                message = "Some damage";
            }
            else // richterScale < 5.0M
            {
                message = "Little or no damage";
            }

            Output.Add($"Richter Scale Magnitude: {richterScale:N2}");
            Output.Add($"Damage Characterization: {message}");
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

            Console.Write("Enter Richter Scale reading (n): ");
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