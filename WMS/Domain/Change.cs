using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class Change
    {
        [Key]
        public int ChangeId { get; set; }
        public string ChangeName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? PriorityRef { get; set; }
        public Priority? Priority { get; set; }
        public int? StatusRef { get; set; }
        public Status? Status { get; set; }
        public int? ApprovalStatusRef { get; set; }
        public ApprovalStatus? ApprovalStatus { get; set; }
        public int? EmployeeRef { get; set; }
        public Employee? Requestor { get; set; }
        public int? RequestRef { get; set; }
        public Request? Request { get; set; }
        public int? CategoryRef { get; set; }
        public Category? Category { get; set; }
        public ICollection<ChangesToChangeManager>? ChangeManagers { get; set; } = new List<ChangesToChangeManager>();
        public ICollection<Work>? Works { get; set; } = new List<Work>();
    }
}