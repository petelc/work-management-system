namespace Domain
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Change> Changes { get; set; }
    }
}