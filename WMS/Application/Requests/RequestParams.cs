using Application.Core;

namespace Application.Requests
{
    public class RequestParams : PagingParams
    {
        public bool IsNew { get; set; }
    }
}