using Domain.Identity;

namespace Domain
{
    public class RequestToRequestors
    {
        public int? EmployeeId { get; set; } // I think this should be changed to EmployeeId
        public Employee? Employee { get; set; }
        public int? RequestId { get; set; }
        public Request? Request { get; set; }
        public bool? IsNew { get; set; }
    }
}