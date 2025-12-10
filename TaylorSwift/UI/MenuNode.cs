// --- MenuNode Class: Represents a node in the navigation tree ---
/// <summary>
/// Represents a navigable page or menu item in the console application.
/// </summary>
namespace TaylorSwift.UI
{
    public class MenuNode
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<MenuNode> Children { get; set; }
        public Action CustomAction { get; set; }

        public MenuNode(string title, string content = null, Action customAction = null)
        {
            Content = content ?? "";
            Title = title;
            Children = [];
            CustomAction = customAction;
        }

        /// <summary>
        /// Checks if the node is a leaf node (no further navigation children).
        /// </summary>
        public bool IsLeaf => Children.Count == 0 && CustomAction == null;
        public object? ActivityInstance { get; set; }
    }
}