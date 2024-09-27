using System.ComponentModel.DataAnnotations;

// TODO - I need to expand on this class

namespace Domain
{
    public class Work
    {
        [Key]
        public Guid WorkId { get; set; }
        public string Name { get; set; } = null!;
        public Project Project { get; set; }
        public Change Change { get; set; }

        public ICollection<WorkToWorkItem> WorkItems { get; set; } = new List<WorkToWorkItem>();
    }
}