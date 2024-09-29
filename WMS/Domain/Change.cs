using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class Change
    {
        [Key]
        public Guid ChangeId { get; set; }
        public string ChangeName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public Guid RequestorRef { get; set; }
        public Employee Requestor { get; set; }
        public Guid RequestRef { get; set; }
        public Request Request { get; set; }
        public Category Category { get; set; }
        public ICollection<ChangesToChangeManager> ChangeManagers { get; set; } = new List<ChangesToChangeManager>();
        public ICollection<Work> Works { get; set; } = new List<Work>();
    }
}