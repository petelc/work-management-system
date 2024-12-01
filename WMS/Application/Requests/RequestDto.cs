using Domain;
using Domain.Identity;

namespace Application.Requests
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public string RequestTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsNew { get; set; }
        public string RequestorUsername { get; set; }
        public RequestType RequestType { get; set; } // one to one relationship
        public Status Status { get; set; } // one to one relationship
        public ApprovalStatus ApprovalStatus { get; set; } // one to one relationship
        public Change Change { get; set; }
        public Project Project { get; set; }
        public Employee Requestor { get; set; }
        //public ICollection<RequestToRequestors> Requestors { get; set; } = new List<RequestToRequestors>();
    }
}