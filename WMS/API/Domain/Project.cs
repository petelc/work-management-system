using Domain.Enums;

namespace Domain
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string project { get; set; }
        public string description { get; set; }
        public Status status { get; set; }
        public Approvals approvals { get; set; }
        public AppUser requestor { get; set; }
        public Request request { get; set; }
        public Category category { get; set; }
        public Guid RequestId { get; set; }
        public Request Request { get; set; }
        public ICollection<ProjectManager> ProjectManagers { get; set; } = new List<ProjectManager>();

        public ICollection<Work> Works { get; set; }
    }
}