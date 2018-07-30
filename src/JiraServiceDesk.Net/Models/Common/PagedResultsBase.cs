namespace JiraServiceDesk.Net.Models.Common
{
    public abstract class PagedResultsBase : WithLinks
    {
        public int Size { get; set; }
        public bool IsLastPage { get; set; }
        public int Start { get; set; }
    }
}