namespace Domain
{
    public class RequestToRequestors
    {
        public int? Id { get; set; }
        public Employee? Employee { get; set; }
        public int? RequestId { get; set; }
        public Request? Request { get; set; }
        public bool? IsNew { get; set; }
    }
}