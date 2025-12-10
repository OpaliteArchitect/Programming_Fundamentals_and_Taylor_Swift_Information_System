namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet7 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.7 - Number to Word Conversion";
        public string Description { get; } = "Write a program that accepts a number and outputs its equivalent in\n\nwords. Enter a number: 1380\n\nOutput: One Thousand Three Hundred Eighty\n\nTake note that the maximum input number is 3000.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        private string GetWords(int number)
        {
            if (number < 1 || number > 3000)
            {
                return "Error: Input must be between 1 and 3000.";
            }

            if (number == 3000) return "Three Thousand";

            string result = "";
            int temp = number;

            // 1. Thousands and Hundreds Logic
            int thousands = temp / 1000;
            switch (thousands)
            {
                case 1: result += "One Thousand"; break;
                case 2: result += "Two Thousand"; break;
            }
            temp %= 1000;
            if (thousands > 0 && temp > 0) result += " ";

            int hundreds = temp / 100;
            switch (hundreds)
            {
                case 1: result += "One Hundred"; break;
                case 2: result += "Two Hundred"; break;
                case 3: result += "Three Hundred"; break;
                case 4: result += "Four Hundred"; break;
                case 5: result += "Five Hundred"; break;
                case 6: result += "Six Hundred"; break;
                case 7: result += "Seven Hundred"; break;
                case 8: result += "Eight Hundred"; break;
                case 9: result += "Nine Hundred"; break;
            }
            temp %= 100;
            if (hundreds > 0 && temp > 0) result += " ";

            // 2. Teens Logic (must be handled before tens/units)
            if (temp >= 10 && temp <= 19)
            {
                switch (temp)
                {
                    case 10: result += "Ten"; break;
                    case 11: result += "Eleven"; break;
                    case 12: result += "Twelve"; break;
                    case 13: result += "Thirteen"; break;
                    case 14: result += "Fourteen"; break;
                    case 15: result += "Fifteen"; break;
                    case 16: result += "Sixteen"; break;
                    case 17: result += "Seventeen"; break;
                    case 18: result += "Eighteen"; break;
                    case 19: result += "Nineteen"; break;
                }
                return result;
            }

            // 3. Tens and Units Logic
            int tens = temp / 10;
            switch (tens)
            {
                case 2: result += "Twenty"; break;
                case 3: result += "Thirty"; break;
                case 4: result += "Forty"; break;
                case 5: result += "Fifty"; break;
                case 6: result += "Sixty"; break;
                case 7: result += "Seventy"; break;
                case 8: result += "Eighty"; break;
                case 9: result += "Ninety"; break;
            }
            temp %= 10;
            if (tens > 0 && temp > 0) result += " ";

            int units = temp;
            switch (units)
            {
                case 1: result += "One"; break;
                case 2: result += "Two"; break;
                case 3: result += "Three"; break;
                case 4: result += "Four"; break;
                case 5: result += "Five"; break;
                case 6: result += "Six"; break;
                case 7: result += "Seven"; break;
                case 8: result += "Eight"; break;
                case 9: result += "Nine"; break;
            }

            return result;
        }

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No number provided.");
                return;
            }

            int number;
            if (Inputs[0] % 1 != 0 || Inputs[0] > 3000 || Inputs[0] < 1)
            {
                Output.Add("Error: Invalid input. Please enter a whole number between 1 and 3000.");
                return;
            }
            number = (int)Inputs[0];

            string words = GetWords(number);

            Output.Add($"Input: {number}");
            Output.Add($"Output: {words}");
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