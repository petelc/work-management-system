using System.ComponentModel.DataAnnotations;

// TODO - I need to expand on this class

namespace Domain
{
    public class Work
    {
        [Key]
        public int WorkId { get; set; }
        public string Name { get; set; } = null!;
        public int? ProjectRef { get; set; }
        public Project? Project { get; set; }
        public int? ChangeRef { get; set; }
        public Change? Change { get; set; }

        public ICollection<WorkToWorkItem> WorkItems { get; set; } = new List<WorkToWorkItem>();
    }
}