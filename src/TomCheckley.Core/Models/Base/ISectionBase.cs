namespace TomCheckley.Core.Models.Base
{
    public interface ISectionBase
    {
        Guid Id { get; }
        string RazorView { get; }
        string Heading { get; }
        bool HasHeading { get; }
        List<IModuleBase> Modules { get; }
    }
}
