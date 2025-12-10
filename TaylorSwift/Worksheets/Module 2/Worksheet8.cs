namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet8 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.8 - Ordinary Numbers to Roman Numerals";
        public string Description { get; } = "Write a program that accepts an ordinary number and outputs its equivalent Roman numerals. The ordinary numbers and their equivalent Roman numerals are given below:\n\nOrdinary Numbers\tRoman Numerals\n1\tI\n5\tV\n10\tX\n50\tL\n100\tC\n500\tD\n1000\tM\n\nNote that the maximum input number is 3000";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        private string NumberToRoman(int number)
        {
            if (number < 1 || number > 3000)
            {
                return "Error: Input must be between 1 and 3000 for Roman numeral conversion.";
            }

            string roman = "";
            int temp = number;

            // Using explicit conditional statements (no arrays or maps)

            // 1. Thousands
            while (temp >= 1000) { roman += "M"; temp -= 1000; }

            // 2. Hundreds (900, 500, 400, 100)
            if (temp >= 900) { roman += "CM"; temp -= 900; }
            else if (temp >= 500) { roman += "D"; temp -= 500; }
            if (temp >= 400) { roman += "CD"; temp -= 400; }
            while (temp >= 100) { roman += "C"; temp -= 100; }

            // 3. Tens (90, 50, 40, 10)
            if (temp >= 90) { roman += "XC"; temp -= 90; }
            else if (temp >= 50) { roman += "L"; temp -= 50; }
            if (temp >= 40) { roman += "XL"; temp -= 40; }
            while (temp >= 10) { roman += "X"; temp -= 10; }

            // 4. Units (9, 5, 4, 1)
            if (temp >= 9) { roman += "IX"; temp -= 9; }
            else if (temp >= 5) { roman += "V"; temp -= 5; }
            if (temp >= 4) { roman += "IV"; temp -= 4; }
            while (temp >= 1) { roman += "I"; temp -= 1; }

            return roman;
        }

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No number provided.");
                return;
            }

            // Validation check
            int number;
            if (Inputs[0] % 1 != 0 || Inputs[0] > 3000 || Inputs[0] < 1)
            {
                Output.Add("Error: Invalid input. Please enter a whole number between 1 and 3000.");
                return;
            }
            number = (int)Inputs[0];

            string roman = NumberToRoman(number);

            Output.Add($"Entered number: {number}");
            Output.Add($"Output: {roman}");
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

            Console.Write("Enter a number (maximum 3000): ");
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