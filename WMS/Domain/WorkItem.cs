using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain
{
    public class WorkItem
    {
        [Key]
        public int WorkItemId { get; set; }
        public string CardIDNum { get; set; } = null!;
        public string Header { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? EmployeeRef { get; set; }
        public Employee? Assignee { get; set; }
        public int? PriorityRef { get; set; }
        public Priority? Priority { get; set; }
        public ICollection<WorkToWorkItem> Work { get; set; } = new List<WorkToWorkItem>();

        // TODO - Connected Card, Icon, and Tag
    }
}