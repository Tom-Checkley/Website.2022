namespace TomCheckley.Core.Models.Base
{
    public class PaginatedList<T>
    {
        public virtual List<T> Items { get; set; }
        public virtual int TotalItems { get; set; }
        public virtual int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public PaginatedList()
        {
            Items = new List<T>();
        }
    }
}
