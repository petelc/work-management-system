using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public partial class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }
        public Change? Change { get; set; }
        public Guid ChangeRef { get; set; }
        public Project? Project { get; set; }
        public Guid ProjectRef { get; set; }
    }
}