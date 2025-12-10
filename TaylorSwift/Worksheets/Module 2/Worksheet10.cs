namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet10 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.10 - Grade Equivalent";
        public string Description { get; } = "Write a program that accepts an input grade in percentile form and output its grade equivalent; based on the given range of percentile and grade equivalent table below:\n\nRange\tGrade\n98-100\t1.00\n95-97\t1.25\n92-94\t1.50\n89-91\t1.75\n85-88\t2.00\n82-84\t2.25\n80-81\t2.50\n77-79\t2.75\n75-76\t3.0\nOther Grades\tOut of Range";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count == 0)
            {
                Output.Add("Error: No percentile grade provided.");
                return;
            }

            decimal percentile = Inputs[0];
            string gradeEquivalent;

            // Using if-else if structure to check ranges from highest to lowest percentile.
            if (percentile >= 98M && percentile <= 100M)
            {
                gradeEquivalent = "1.00";
            }
            else if (percentile >= 95M && percentile <= 97M)
            {
                gradeEquivalent = "1.25";
            }
            else if (percentile >= 92M && percentile <= 94M)
            {
                gradeEquivalent = "1.50";
            }
            else if (percentile >= 89M && percentile <= 91M)
            {
                gradeEquivalent = "1.75";
            }
            else if (percentile >= 85M && percentile <= 88M)
            {
                gradeEquivalent = "2.00";
            }
            else if (percentile >= 82M && percentile <= 84M)
            {
                gradeEquivalent = "2.25";
            }
            else if (percentile >= 80M && percentile <= 81M)
            {
                gradeEquivalent = "2.50";
            }
            else if (percentile >= 77M && percentile <= 79M)
            {
                gradeEquivalent = "2.75";
            }
            else if (percentile >= 75M && percentile <= 76M)
            {
                gradeEquivalent = "3.0";
            }
            else
            {
                gradeEquivalent = "Out of Range";
            }

            Output.Add($"Input Percentile Grade: {percentile:N2}");
            Output.Add($"Grade Equivalent: {gradeEquivalent}");
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

            Console.Write("Enter grade in percentile form: ");
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