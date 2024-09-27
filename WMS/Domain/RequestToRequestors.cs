namespace Domain
{
    public class RequestToRequestors
    {
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid RequestId { get; set; }
        public Request Request { get; set; }
        public bool IsNew { get; set; }
    }
}