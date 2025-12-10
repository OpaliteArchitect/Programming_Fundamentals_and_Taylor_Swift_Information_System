using TaylorSwift.UI;
using TaylorSwift.Worksheets;
using static TaylorSwift.UI.TaylorSwiftAnimation;

namespace TaylorSwift
{
    // --- Main Program Class: Handles the navigation and input loop ---
    public class Program
    {
        private static bool _isRunning = true;
        private static MenuNode _currentNode;
        private static Stack<MenuNode> _history = new Stack<MenuNode>();

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Title = "Taylor Swift Information System & Module Worksheets";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Initial setup and app structure creation
            MenuNode mainMenu = AppInitializer.InitializeAppStructure(ExitProgram);
            _currentNode = mainMenu;

            Play(3); // Initial entrance animation

            // Main Application Loop
            while (_isRunning)
            {
                try
                {
                    RenderCurrentPage();
                    HandleInput();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[ERROR] An unexpected error occurred: {ex.Message}");
                    Console.WriteLine("Press any key to return to the previous menu...");
                    Console.ReadKey(true);
                    // Attempt to go back on error
                    if (_history.Count > 0)
                    {
                        _currentNode = _history.Pop();
                    }
                    else
                    {
                        _currentNode = mainMenu;
                    }
                    Play(2);
                }
            }

            FinalExitMessage();
        }

        /// <summary>
        /// Renders the current page using the ConsoleRenderer.
        /// </summary>
        private static void RenderCurrentPage()
        {
            string path = GetNavigationPath();
            ConsoleRenderer.DrawPage(_currentNode, path);
        }

        /// <summary>
        /// Constructs the path breadcrumb for the current page.
        /// </summary>
        private static string GetNavigationPath()
        {
            var pathList = _history.Reverse().Select(n => n.Title).ToList();
            pathList.Add(_currentNode.Title);
            // Only show up to 3 segments for clarity
            if (pathList.Count > 3)
            {
                pathList = new List<string> { "...", pathList[pathList.Count - 2], pathList[pathList.Count - 1] };
            }
            return string.Join(" > ", pathList);
        }

        /// <summary>
        /// Handles user input for navigation.
        /// </summary>
        private static void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            string input = key.KeyChar.ToString().ToUpper();

            // Check for common commands
            if (input == "Q" && _currentNode.Title == "Main Menu")
            {
                ExitProgram();
                return;
            }

            // 1. Check for Go Back (B)
            if (input == "B" || (_currentNode.IsLeaf && input != "B")) // Leaf nodes implicitly treat any non-option input as 'B'
            {
                if (_history.Count > 0)
                {
                    _currentNode = _history.Pop();
                }
                return;
            }

            // 2. Check for numeric choice
            if (int.TryParse(input, out int choice))
            {
                if ((choice > 0 && choice <= _currentNode.Children.Count) ||
                    (choice == 0 && _currentNode.Children.Count == 10))
                {
                    // If choice is 0 and count is 10, use index 9; otherwise, use standard 1-based indexing (choice - 1).
                    int index = (choice == 0) ? 9 : choice - 1;
                    var chosenNode = _currentNode.Children[index];

                    // If a custom action exists (like the Exit option), execute it
                    if (chosenNode.CustomAction != null)
                    {
                        chosenNode.CustomAction.Invoke();
                        return;
                    }

                    // If node has an attached activity, execute it instead of navigating
                    if (chosenNode.ActivityInstance is IActivity activity)
                    {
                        activity.Execute();
                        Play(1, true);
                        return;
                    }

                    // Otherwise continue normal navigation
                    _history.Push(_currentNode);
                    _currentNode = chosenNode;
                    return;
                }
            }

            // 3. Handle Invalid Input
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[INVALID INPUT] Please enter a valid option (1-{_currentNode.Children.Count}) or 'B' to go back.");
            Console.ReadKey(true); // Wait for key press to clear message
        }

        /// <summary>
        /// Action method to exit the program.
        /// </summary>
        private static void ExitProgram()
        {
            _isRunning = false;
        }

        /// <summary>
        /// Displays a final styled exit message.
        /// </summary>
        private static void FinalExitMessage()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;

            // Use fixed BOX_WIDTH for consistency
            string line = new('#', Console.WindowWidth);

            int topPadding = Console.WindowHeight / 2 - 2;

            for (int i = 0; i < topPadding; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine(line);
            Console.WriteLine(ConsoleRenderer.CenterString("PROGRAM TERMINATED", Console.WindowWidth));
            Console.WriteLine(line);
            Console.ResetColor();
            Thread.Sleep(1000);
        }
    }
}