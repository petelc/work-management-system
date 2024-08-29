using Domain.Enums;

namespace Domain
{
    /**
    * Defines a request submitted to system
    */

    public class Requests
    {
        public Guid rId { get; set; }
        public string request { get; set; }
        public string description { get; set; }
        public RequestType type { get; set; }
        public Status status { get; set; }
        public Approvals approvals { get; set; }
        public AppUser appUser { get; set; }

    }
}