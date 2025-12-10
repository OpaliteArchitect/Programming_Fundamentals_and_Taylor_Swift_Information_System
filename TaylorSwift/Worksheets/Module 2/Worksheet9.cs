using System;

namespace TaylorSwift.Worksheets.Module_2
{
    internal class Worksheet9 : IActivity<decimal>
    {
        public string Title { get; } = "Worksheet 2.9 - Compute and Assess Tuition Fee";
        public string Description { get; } = "Write a program that computes and assesses the tuition fee of the students in one trimester, based on the given mode of payment below:\n\nPlan (key)\tDiscount (-) or Interest (+)\nCash (1)\t10% discount\nTwo-Installment (2)\t5% discount\nThree-Installment(3)\t10% interest\n\nThe first input data is the tuition fee, and the second input data is the mode of payment.";
        public List<decimal> Inputs { get; set; } = [];
        public List<string> Output { get; set; } = [];

        public void Operation()
        {
            if (Inputs.Count < 2)
            {
                Output.Add("Error: Both Tuition Fee and Mode of Payment key are required.");
                return;
            }

            decimal tuitionFee = Inputs[0];
            int paymentKey = (int)Inputs[1]; // Mode of payment key (1, 2, or 3)
            decimal totalFee;
            string assessment;

            // Using switch statement to process the mode of payment key
            switch (paymentKey)
            {
                case 1: // Cash (10% discount)
                    decimal discount10 = tuitionFee * 0.10M;
                    totalFee = tuitionFee - discount10;
                    assessment = $"Mode: Cash (1) | 10% Discount applied ({discount10:N2})";
                    break;

                case 2: // Two-Installment (5% discount)
                    decimal discount5 = tuitionFee * 0.05M;
                    totalFee = tuitionFee - discount5;
                    assessment = $"Mode: Two-Installment (2) | 5% Discount applied ({discount5:N2})";
                    break;

                case 3: // Three-Installment (10% interest)
                    decimal interest10 = tuitionFee * 0.10M;
                    totalFee = tuitionFee + interest10;
                    assessment = $"Mode: Three-Installment (3) | 10% Interest applied ({interest10:N2})";
                    break;

                default:
                    Output.Add($"Error: Invalid Mode of Payment key '{paymentKey}'. Please use 1, 2, or 3.");
                    return;
            }

            Output.Add($"Initial Tuition Fee: {tuitionFee:N2}");
            Output.Add(assessment);
            Output.Add($"Your total tuition fee is: {totalFee:N2}");
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

            // Input 1: Tuition Fee
            Console.Write("Enter tuition fee: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal feeValue))
                Inputs.Add(feeValue);
            else
                Inputs.Add(0M);

            // Input 2: Mode of Payment Key
            Console.Write("Enter mode of payment (Press 1 for Cash, 2 for Two-Installment, 3 for Three-Installment): ");
            if (int.TryParse(Console.ReadLine(), out int keyValue))
                Inputs.Add(keyValue);
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