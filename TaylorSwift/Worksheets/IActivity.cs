namespace TaylorSwift.Worksheets
{
    public interface IActivity
    {
        string Title { get; }
        string Description { get; }
        void Execute();
    }
    public interface IActivity<T> : IActivity
    {
        List<T> Inputs { get; set; }
        List<string> Output { get; set; }
        void Operation();
    }
}
