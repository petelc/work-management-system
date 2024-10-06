using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Project // Parent
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
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
        public int? PriorityRef { get; set; }
        public Priority? Priority { get; set; }
        public ICollection<ProjectToProjectManager>? ProjectManagers { get; set; } = new List<ProjectToProjectManager>();
        public ICollection<Work>? Works { get; set; }
    }
}