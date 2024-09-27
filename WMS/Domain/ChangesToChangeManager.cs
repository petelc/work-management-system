namespace Domain
{
    public class ChangesToChangeManager
    {
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid ChangeId { get; set; }
        public Change Change { get; set; }
        public bool IsNew { get; set; }
    }
}