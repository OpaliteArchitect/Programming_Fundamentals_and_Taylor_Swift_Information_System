namespace TaylorSwift.Worksheets.Module_1
{
    internal class Worksheet1 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 1.1 - Volume of Sphere";
        public string Description { get; } = "Create a program to compute the volume of a sphere. Use the formula: V= (4/3)* πr³ where π is equal to 3.1416 approximately. The variable r is the radius. Display the volume of a sphere.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            const decimal pi = 3.1416m;
            const decimal num1 = 4, num2 = 3;

            decimal volume = num1 / num2 * pi * Inputs[0] * Inputs[0] * Inputs[0];
            Output.Add($"The volume of the sphere is {volume:F2}");
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

            Console.Write("Enter radius: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                Inputs.Add(value);

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
