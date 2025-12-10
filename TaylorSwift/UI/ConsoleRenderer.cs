namespace TaylorSwift.UI
{
    public static class ConsoleRenderer
    {
        private static readonly ConsoleColor AccentColor = ConsoleColor.Magenta;
        private static readonly ConsoleColor TitleColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor TextColor = ConsoleColor.White;
        private static readonly ConsoleColor OptionColor = ConsoleColor.Yellow;
        private static readonly ConsoleColor BackColor = ConsoleColor.Red;

        public const int BOX_WIDTH = 100;
        private const int INNER_CONTENT_WIDTH = BOX_WIDTH - 2;

        public static void DrawPage(MenuNode node, string navigationPath)
        {
            Console.Clear();
            DrawBox(node, navigationPath);
            DrawExternalFooter(Console.WindowWidth);
        }

        public static string CenterString(string s, int width)
        {
            if (s.Length >= width) return s;
            int leftPadding = (width - s.Length) / 2;
            return new string(' ', leftPadding) + s + new string(' ', width - s.Length - leftPadding);
        }

        private static List<string> WrapText(string text, int width)
        {
            if (string.IsNullOrEmpty(text)) return new List<string>();
            var lines = new List<string>();
            var words = text.Split(' ');
            var currentLine = "";

            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(currentLine))
                {
                    currentLine = word;
                }
                else if ((currentLine + " " + word).Length <= width)
                {
                    currentLine += " " + word;
                }
                else
                {
                    lines.Add(currentLine);
                    currentLine = word;
                }
            }
            lines.Add(currentLine);
            return lines;
        }

        private static void DrawBorderedLine(string content, string outerPadding, ConsoleColor contentColor, bool centerContent = false)
        {
            string innerContent;
            if (centerContent)
            {
                innerContent = CenterString(content, INNER_CONTENT_WIDTH);
            }
            else
            {
                innerContent = "  " + content.PadRight(INNER_CONTENT_WIDTH - 2);
            }

            Console.ForegroundColor = AccentColor;
            Console.Write(outerPadding + "║");
            Console.ForegroundColor = contentColor;
            Console.Write(innerContent);
            Console.ForegroundColor = AccentColor;
            Console.WriteLine("║");
        }

        private static void DrawBox(MenuNode node, string navigationPath)
        {
            const int HEADER_HEIGHT = 2;
            const int FIXED_HEIGHT_LINES = 3;

            int contentLineCount = 0;
            if (!string.IsNullOrEmpty(node.Content))
            {
                int contentWrapWidth = BOX_WIDTH - 4;
                contentLineCount = (int)Math.Ceiling((double)node.Content.Length / contentWrapWidth);
                contentLineCount += 1;
            }

            int optionLineCount = node.Children.Count + 5;

            int boxHeight = FIXED_HEIGHT_LINES + HEADER_HEIGHT + contentLineCount + optionLineCount;

            int topPaddingLines = Math.Max(0, (Console.WindowHeight - boxHeight) / 2);

            for (int i = 0; i < topPaddingLines; i++)
            {
                Console.WriteLine();
            }

            int totalConsoleWidth = Console.WindowWidth;
            int leftPadding = Math.Max(0, (totalConsoleWidth - BOX_WIDTH) / 2);
            string padding = new string(' ', leftPadding);

            Console.ForegroundColor = AccentColor;
            Console.WriteLine($"{padding}╔{new string('═', BOX_WIDTH - 2)}╗");

            DrawHeader(node.Title, navigationPath, padding);

            DrawContent(node.Content, padding);

            Console.ForegroundColor = AccentColor;
            Console.WriteLine($"{padding}╟{new string('─', BOX_WIDTH - 2)}╢");

            DrawOptions(node, padding);

            Console.ForegroundColor = AccentColor;
            Console.WriteLine($"{padding}╚{new string('═', BOX_WIDTH - 2)}╝");

            Console.ResetColor();
        }


        private static void DrawHeader(string title, string navigationPath, string padding)
        {
            DrawBorderedLine(title, padding, TitleColor, centerContent: true);

            Console.ForegroundColor = AccentColor;
            Console.WriteLine($"{padding}╠{new string('═', BOX_WIDTH - 2)}╣");

            string pathContent = $"Path: {navigationPath}";
            DrawBorderedLine(pathContent, padding, ConsoleColor.DarkGray, centerContent: true);

            DrawBorderedLine("", padding, TextColor);
        }

        private static void DrawContent(string content, string padding)
        {
            if (!string.IsNullOrEmpty(content))
            {
                var lines = WrapText(content, INNER_CONTENT_WIDTH - 2);
                foreach (var line in lines)
                {
                    DrawBorderedLine(line, padding, TextColor);
                }
            }
            DrawBorderedLine("", padding, TextColor);
        }

        private static void DrawOptions(MenuNode node, string padding)
        {
            DrawBorderedLine("OPTIONS", padding, AccentColor, centerContent: true);
            Console.ForegroundColor = AccentColor;
            Console.WriteLine($"{padding}╟{new string('─', BOX_WIDTH - 2)}╢");


            for (int i = 0; i < node.Children.Count; i++)
            {
                string optionText = $"[{(i + 1) % 10}] - {node.Children[i].Title}";
                DrawBorderedLine(optionText, padding, OptionColor);
            }

            DrawBorderedLine("", padding, TextColor);
            string backText;
            if (node.IsLeaf)
            {
                backText = "[B] - Go Back (Press B)";
            }
            else if (node.Title == "Main Menu")
            {
                backText = "[4] / [Q] - Exit Program";
            }
            else
            {
                backText = "[B] - Go Back (Press B)";
            }
            DrawBorderedLine(backText, padding, BackColor);
            DrawBorderedLine("", padding, TextColor);
        }

        private static void DrawExternalFooter(int width)
        {
            const string FOOTER_TEXT2 = "© 2025 Lastname, Firstname All Rights Reserved.";

            Console.ForegroundColor = ConsoleColor.DarkGray;

            int boxLeftPadding = Math.Max(0, (width - BOX_WIDTH) / 2);
            string boxPadding = new string(' ', boxLeftPadding);

            //string centeredFooter1 = CenterString(FOOTER_TEXT1, BOX_WIDTH);
            string centeredFooter2 = CenterString(FOOTER_TEXT2, BOX_WIDTH);

            //Console.WriteLine($"{boxPadding}{centeredFooter1}");
            Console.WriteLine($"{boxPadding}{centeredFooter2}");

            Console.ResetColor();
        }
    }
}
