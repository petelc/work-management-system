using Domain.Enums;

namespace Domain
{
    public class Change
    {
        public Guid ChangeId { get; set; }
        public string change { get; set; }
        public string description { get; set; }
        public Priority priority { get; set; }
        public Status status { get; set; }
        public Approvals approvals { get; set; }
        public AppUser requestor { get; set; }
        public Request requests { get; set; }
        public Category category { get; set; }

        public ICollection<ChangeManager> ChangeManagers { get; set; } = new List<ChangeManager>();

        public ICollection<Work> Works { get; set; }

    }
}