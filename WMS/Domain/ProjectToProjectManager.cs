using Domain.Identity;

namespace Domain
{
    public class ProjectToProjectManager
    {
        public int? Id { get; set; }
        public Employee? Employee { get; set; }
        public int? ProjectId { get; set; }
        public Project? Project { get; set; }
        public bool IsNew { get; set; }
    }
}