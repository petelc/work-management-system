using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class WorkItem
    {
        [Key]
        public Guid WorkItemId { get; set; }
        public string CardIDNum { get; set; } = null!;
        public string Header { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee Assignee { get; set; }
        public Priority Priority { get; set; }
        public ICollection<WorkToWorkItem> Work { get; set; } = new List<WorkToWorkItem>();

        // TODO - Connected Card, Icon, and Tag
    }
}