using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ApprovalStatus
    {
        [Key]
        public Guid ApprovalStatusId { get; set; }
        public string ApprovalStatusName { get; set; } = null!;
        public Guid RequestRef { get; set; }
        public Request? Request { get; set; }
        public Guid ProjectRef { get; set; }
        public Project? Project { get; set; }
        public Guid ChangeRef { get; set; }
        public Change? Change { get; set; }
    }
}