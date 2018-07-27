using System.Collections.Generic;

namespace JiraServiceDesk.Net.Models.Common
{
    public class ErrorResponse
    {
        public IEnumerable<Error> Errors { get; set; }
    }
}
