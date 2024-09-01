using Application.Core;

namespace Application.Requests
{
    public class RequestParams : PagingParams
    {
        public bool IsNew { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsComplete { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.Now;
    }
}