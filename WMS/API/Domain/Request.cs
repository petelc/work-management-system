using Domain.Enums;

namespace Domain
{
    /**
    * Defines a request submitted to system
    */

    public class Request
    {
        public Guid RequestId { get; set; }
        public string request { get; set; }
        public string description { get; set; }
        public RequestType type { get; set; }
        public Status status { get; set; }
        public Approvals approvals { get; set; }
        public ICollection<Requestor> Requestors { get; set; } = new List<Requestor>();



    }
}