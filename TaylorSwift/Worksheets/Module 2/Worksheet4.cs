namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet4 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.4 - Determine Type of Aircraft";
        public string Description { get; } = "Write a program for the Air Force to label an aircraft as military or civilian. The program is to be given the plane's observed speed in km/h and its estimated length In meters. For Planes traveling in excess of 1100 km/h, and longer than 52 meters, you should label them as \"civilian\" aircraft, and shorter such as 500 km/h and 20 meters as \"military\" aircraft. For planes traveling at slower speeds, you will issue an \"It's a bird\" message.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count < 2)
            {
                Output.Add("Error: Both speed and length inputs are required.");
                return;
            }

            decimal speed = Inputs[0];  // Speed in km/h
            decimal length = Inputs[1]; // Length in meters
            string label;

            // Condition 1: Civilian
            if (speed > 1100M && length > 52M)
            {
                label = "Civilian Aircraft";
            }
            // Condition 2: Military (using exact specific values as requested)
            else if (speed > 500M && length > 20M)
            {
                label = "Military Aircraft";
            }
            // All other cases (including those not matching the specific criteria)
            else
            {
                label = "It's a bird";
            }

            Output.Add($"Observed Speed: {speed:N0} km/h");
            Output.Add($"Estimated Length: {length:N2} meters");
            Output.Add($"Label: {label}");
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

            // Input Speed
            Console.Write("Enter observed speed (km/h): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal speedValue))
                Inputs.Add(speedValue);
            else
                Inputs.Add(0M);

            // Input Length
            Console.Write("Enter estimated length (meters): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal lengthValue))
                Inputs.Add(lengthValue);
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