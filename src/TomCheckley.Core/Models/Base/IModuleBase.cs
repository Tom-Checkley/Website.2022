namespace TomCheckley.Core.Models.Base
{
    public interface IModuleBase
    {
        Guid Id { get; }
        string RazorView { get; }
        ISectionBase ParentSection { get; }
    }
}
