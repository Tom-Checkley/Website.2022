namespace TomCheckley.Core.Models.PageTypes.Base
{
    public interface IPageBase
    {
        //string PageHeading { get; }
        Guid Id { get; }
        string Url { get; }
    }
}
