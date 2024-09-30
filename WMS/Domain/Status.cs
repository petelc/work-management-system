using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class Status
    {
        [Key]
        public Guid StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public Guid RequestRef { get; set; }
        public Request Request { get; set; }
        public Guid ProjectRef { get; set; }
        public Project Project { get; set; }
        public Guid ChangeRef { get; set; }
        public Change Change { get; set; }
    }
}