using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class Project
    {
        [Key]
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Status Status { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public Employee Requestor { get; set; }
        public Guid RequestRef { get; set; }
        public Request Request { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public ICollection<ProjectToProjectManager> ProjectManagers { get; set; } = new List<ProjectToProjectManager>();
        public ICollection<Work> Works { get; set; }
    }
}