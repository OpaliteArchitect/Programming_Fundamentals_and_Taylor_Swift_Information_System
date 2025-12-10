namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet1 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.1 - Determine Vowel or Consonant";
        public string Description { get; } = "Write a program that determines if the input letter is a VOWEL or CONSONANT. The vowels are: A E I O U. Your program must be able to handle a capital or small input letter.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        private string _charInput = string.Empty;

        public void Operation()
        {
            if (string.IsNullOrWhiteSpace(_charInput))
            {
                Output.Add("No character was entered for analysis.");
                return;
            }

            char inputChar = _charInput[0];

            if (char.IsLetter(inputChar))
            {
                // Use switch statement to handle both uppercase and lowercase cases without ToUpper()
                switch (inputChar)
                {
                    case 'A':
                    case 'a':
                    case 'E':
                    case 'e':
                    case 'I':
                    case 'i':
                    case 'O':
                    case 'o':
                    case 'U':
                    case 'u':
                        Output.Add($"The letter '{inputChar}' is a VOWEL.");
                        break;
                    default:
                        // If it is a letter but does not match any vowel case, it is a consonant
                        Output.Add($"The letter '{inputChar}' is a CONSONANT.");
                        break;
                }
            }
            else
            {
                Output.Add($"The character '{inputChar}' is not a letter. Please enter a letter.");
            }
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

            Console.Write("Enter a single letter: ");
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