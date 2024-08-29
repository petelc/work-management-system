namespace Domain
{
    public class ProjectManager
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid ProjectId { get; set; }
        public Project Projects { get; set; }
    }
}