namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet5 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.5 - Determine Type of Ship";
        public string Description { get; } = "Write a program that determines the class of the Ship depending on its class ID (identifier). Here are the criteria. The class ID serves as the input data and the Ship class as the output information.\n\nClass ID\tShip Class\nB or b\tBattleship\nC or c\tCruiser\nD or d\tDestroyer\nF or f\tFrigate";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        private string _charInput = string.Empty;

        public void Operation()
        {
            if (string.IsNullOrWhiteSpace(_charInput))
            {
                Output.Add("No Class ID was entered for analysis.");
                return;
            }

            char inputChar = _charInput[0];
            string shipClass;

            // Using switch statement to check for both uppercase and lowercase cases
            switch (inputChar)
            {
                case 'B':
                case 'b':
                    shipClass = "Battleship";
                    break;
                case 'C':
                case 'c':
                    shipClass = "Cruiser";
                    break;
                case 'D':
                case 'd':
                    shipClass = "Destroyer";
                    break;
                case 'F':
                case 'f':
                    shipClass = "Frigate";
                    break;
                default:
                    shipClass = "Unknown Ship Class ID";
                    break;
            }

            Output.Add($"Input Class ID: {inputChar}");
            Output.Add($"Ship Class: {shipClass}");
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
            _charInput = string.Empty;

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter a single Class ID (B, C, D, or F): ");
            string? inputLine = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(inputLine))
            {
                _charInput = inputLine[0].ToString();
                if (inputLine.Length > 1)
                {
                    Output.Add($"Note: Only the first character ('{_charInput}') will be analyzed.");
                }
            }

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