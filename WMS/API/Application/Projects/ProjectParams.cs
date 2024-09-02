using Application.Core;

namespace Application.Projects
{
    public class ProjectParams : PagingParams
    {
        public bool IsComplete { get; set; }
        public bool IsSubmitted { get; set; }
    }
}