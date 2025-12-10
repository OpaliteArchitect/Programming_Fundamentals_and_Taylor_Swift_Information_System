namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet2 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.2 - Determine Data Value";
        public string Description { get; } = "Write a program that accepts dates written in numerical form and then output them as a complete form. For example, the input: 2 26 1986 should produce the output: February 26, 1986";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        private string _dateInput = string.Empty;

        public void Operation()
        {
            Output.Clear();
            if (string.IsNullOrWhiteSpace(_dateInput))
            {
                Output.Add("Error: No date input provided.");
                return;
            }

            string[] parts = _dateInput.Split(new char[] { ' ', '/', '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                Output.Add("Error: Date must be entered in three parts (Month Day Year), e.g., '2 26 1986'.");
                return;
            }

            if (!int.TryParse(parts[0], out int month) ||
                !int.TryParse(parts[1], out int day) ||
                !int.TryParse(parts[2], out int year))
            {
                Output.Add("Error: All date parts must be valid numbers.");
                return;
            }

            string monthName;

            // Using switch statement as required for conditional logic
            switch (month)
            {
                case 1: monthName = "January"; break;
                case 2: monthName = "February"; break;
                case 3: monthName = "March"; break;
                case 4: monthName = "April"; break;
                case 5: monthName = "May"; break;
                case 6: monthName = "June"; break;
                case 7: monthName = "July"; break;
                case 8: monthName = "August"; break;
                case 9: monthName = "September"; break;
                case 10: monthName = "October"; break;
                case 11: monthName = "November"; break;
                case 12: monthName = "December"; break;
                default:
                    Output.Add($"Error: Invalid month number ({month}). Must be between 1 and 12.");
                    return;
            }

            // Simple validation (not comprehensive for all date rules, but sufficient for basic check)
            if (day < 1 || day > 31)
            {
                Output.Add($"Error: Invalid day number ({day}). Must be between 1 and 31.");
                return;
            }
            if (year < 1)
            {
                Output.Add("Error: Invalid year.");
                return;
            }

            Output.Add($"The complete form is: {monthName} {day}, {year}");
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
            _dateInput = string.Empty;

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter date in M D Y numerical form (e.g., 2 26 1986): ");
            _dateInput = Console.ReadLine() ?? string.Empty;

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