using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class Request
    {
        [Key]
        public int RequestId { get; set; }
        public string RequestTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsNew { get; set; }
        public int? RequestTypeId { get; set; }
        public RequestType? RequestType { get; set; } // one to one relationship
        public int? StatusId { get; set; }
        public Status? Status { get; set; } // one to one relationship
        public int? ApprovalStatusId { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; } // one to one relationship
        public int? ChangeId { get; set; }
        public Change? Change { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public ICollection<RequestToRequestors>? Requestors { get; set; } = new List<RequestToRequestors>();
    }
}