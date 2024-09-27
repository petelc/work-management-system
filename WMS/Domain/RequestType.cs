using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class RequestType
    {
        [Key]
        public string RequestTypeId { get; set; } = null!;
        public string RequestTypeName { get; set; } = null!;
        public Guid RequestRef { get; set; }
        public Request Request { get; set; }
        public Guid ProjectRef { get; set; }
        public Project Project { get; set; }
        public Guid ChangeRef { get; set; }
        public Change Change { get; set; }
    }
}