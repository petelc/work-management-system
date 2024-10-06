namespace Application.Requests
{
    public class RequestorDto
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Region { get; set; }
        public string Institution { get; set; }
        public string Extension { get; set; }
        public int ReportsTo { get; set; }
        public bool IsRequestor { get; set; }
    }
}