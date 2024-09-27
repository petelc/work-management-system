using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Priority
    {
        [Key]
        public string PriorityId { get; set; } = null!;
        public string PriorityName { get; set; } = null!;
        public Guid RequestRef { get; set; }
        public Request Request { get; set; }
        public Guid ProjectRef { get; set; }
        public Project Project { get; set; }
        public Guid ChangeRef { get; set; }
        public Change Change { get; set; }
        public Guid WorkItemRef { get; set; }
        public WorkItem WorkItem { get; set; }
    }
}