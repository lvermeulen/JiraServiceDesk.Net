using System.Collections.Generic;

namespace JiraServiceDesk.Net.Models.Common
{
    public class PagedResults<T> : PagedResultsBase
    {
        public int Limit { get; set; }
        public List<T> Values { get; set; }
        public int? NextPageStart { get; set; }
    }
}
